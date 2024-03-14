using AudioProcessing.Common;
using AudioProcessing.Events;
using NAudio.Wave;

namespace AudioProcessing.Audio
{
    public class PlaybackManager
    {
        // Consts
        const int FFT_SIZE = 4096;
        const long OSAMP = 8L;

        // Events
        public event EventHandler<EventArgs>? PlaybackStarted;
        public ActionWithInvoke? PlaybackStartedAction { get; set; }

        public event EventHandler<EventArgs>? PlaybackStopped;
        public ActionWithInvoke? PlaybackStoppedAction { get; set; }

        public event EventHandler<EventArgs>? SpeedChanged;
        public Action<float>? SpeedChangedAction;

        public event EventHandler<EventArgs>? PitchChanged;
        public Action<float>? PitchChangedAction;


        public event EventHandler<ValueEventArgs<string>>? TimeUpdated;
        public ActionWithInvoke<string>? TimeUpdatedAction { get; set; }


        private void OnPlaybackStarted(EventArgs e)
        {
            PlaybackStarted?.Invoke(this, e);
            PlaybackStartedAction?.Execute();
        }

        private void OnPlaybackStopped(EventArgs e)
        {
            PlaybackStopped?.Invoke(this, e);
            PlaybackStoppedAction?.Execute();
        }

        private void OnSpeedChanged(ValueEventArgs<float> e)
        {
            SpeedChanged?.Invoke(this, e);
            SpeedChangedAction?.Invoke(e.Value);
        }

        private void OnPitchChanged(ValueEventArgs<float> e)
        {
            PitchChanged?.Invoke(this, e);
            PitchChangedAction?.Invoke(e.Value);
        }

        private void OnTimeUpdated(ValueEventArgs<string> e)
        {
            TimeUpdated?.Invoke(this, e);
            TimeUpdatedAction?.Execute(e.Value);
        }


        private WaveOutEvent waveOut = new WaveOutEvent { DesiredLatency = 150, NumberOfBuffers = 3 };
        private BufferedWaveProvider bufferedWaveProvider;

        public TimeFormat PlaybackTimeFormat { get; set; } = TimeFormat.Samples;
        public WaveFormat WaveFormat { get; private set; }
        public SMBPitchShiftingSampleProvider SMB { get; private set; }

        // Parameters
        public PlaybackState PlaybackState
        {
            get
            {
                return waveOut.PlaybackState;
            }
            private set { }
        }
        public float PitchFactor
        {
            get
            {
                return SMB.PitchFactor;
            }
            set
            {
                if (SMB != null)
                {
                    SMB.PitchFactor = value;
                    OnPitchChanged(new ValueEventArgs<float>(value));
                }
            }
        }

        private float speed;
        public float PlaybackSpeed 
        { 
            get 
            {
                return speed;
            } 
            set 
            {
                speed = value;
                OnSpeedChanged(new ValueEventArgs<float>(value));
            } 
        }

        public float TimeStrech
        {
            get
            {
                float error = (PlaybackSpeed * PitchFactor) - 1f;
                return error < 0.01f ? PlaybackSpeed : -1;
            }
            set
            {
                PlaybackSpeed = value;
                PitchFactor = 1 / value;
            }
        }

        public long CurrentSample { get; private set; }

        public PlaybackManager(ISampleProvider sourceProvider, WaveFormat waveFormat)
        {
            // Initialize streams
            WaveFormat = waveFormat;
            SMB = new SMBPitchShiftingSampleProvider(sourceProvider, FFT_SIZE, OSAMP, 1.0f);

            // Initialize buffer and wave output
            bufferedWaveProvider = new BufferedWaveProvider(WaveFormat);
            bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(5);

            waveOut.Init(bufferedWaveProvider);

            // Add handler for PlaybackStopped event
            waveOut.PlaybackStopped += (sender, e) =>
            {
                OnPlaybackStopped(EventArgs.Empty);
            };

            // Reset values to default
            PlaybackSpeed = 1.0f;
            PitchFactor = 1.0f;
        }

        public void StartPlayback()
        {
            waveOut.Play();
            OnPlaybackStarted(EventArgs.Empty);
        }

        public void PausePlayback()
        {
            waveOut.Pause();
        }

        public void StopPlayback()
        {
            waveOut.Stop();
            OnPlaybackStopped(EventArgs.Empty);
        }

        public void TogglePlaybackState()
        {
            if (IsPaused() || !IsAlive())
            {
                StartPlayback();
            }
            else
            {
                PausePlayback();
            }
        }

        public bool IsAlive()
        {
            return PlaybackState != PlaybackState.Stopped;
        }

        public bool IsPaused()
        {
            return PlaybackState == PlaybackState.Paused;
        }

        public bool IsBufferOverfull(int samples = 44100)
        {
            return bufferedWaveProvider.BufferedBytes > samples * PlaybackSpeed;
        }

        public byte[] ApplySpeed(byte[] data)
        {
            CurrentSample += data.Length / 4;
            OnTimeUpdated(new ValueEventArgs<string>(PlaybackTimeFormat.ToString() + ": " + Utils.FormatTimeElapsed(CurrentSample, PlaybackTimeFormat)));

            if (bufferedWaveProvider != null)
            {
                if (Math.Abs(PlaybackSpeed - 1) > double.Epsilon)
                {
                    // Resample audio if playback speed changed
                    var newRate = Convert.ToInt32(WaveFormat.SampleRate / PlaybackSpeed);
                    var wf = new WaveFormat(newRate, 16, WaveFormat.Channels);
                    var resampleInputMemoryStream = new MemoryStream(data) { Position = 0 };

                    WaveStream ws = new RawSourceWaveStream(resampleInputMemoryStream, WaveFormat);
                    var wfcs = new WaveFormatConversionStream(wf, ws) { Position = 0 };
                    var b = new byte[ws.WaveFormat.AverageBytesPerSecond];

                    int bo = wfcs.Read(b, 0, ws.WaveFormat.AverageBytesPerSecond);
                    while (bo > 0)
                    {
                        bufferedWaveProvider.AddSamples(b, 0, bo);
                        bo = wfcs.Read(b, 0, ws.WaveFormat.AverageBytesPerSecond);
                    }

                    wfcs.Dispose();
                    ws.Dispose();

                    return b;
                }
                else
                {
                    bufferedWaveProvider.AddSamples(data, 0, data.Length);
                }
            }

            return data;
        }

        public void Close()
        {
            // Make sure to stop audio output and dispose resources before closing the application
            StopPlayback();
            waveOut.Dispose();
        }
    }
}
