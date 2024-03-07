using AudioProcessing.Events;
using AudioProcessing.Plotting;
using Microsoft.VisualBasic;
using NAudio.Wave;

namespace AudioProcessing.Audio
{
    public class PlaybackManager
    {
        // Consts
        const int FFT_SIZE = 4096;
        const long OSAMP = 8L;

        // Events
        public event EventHandler<EventArgs> PlaybackStarted;
        public event EventHandler<EventArgs> PlaybackStopped;


        private WaveOutEvent waveOut = new WaveOutEvent { DesiredLatency = 150, NumberOfBuffers = 3 };
        private BufferedWaveProvider bufferedWaveProvider;

        private Label timeElapsedLabel;

        //public ISampleProvider SourceStream { get; private set; }
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
                }
            }
        }
        public float PlaybackSpeed { get; set; }

        public float TimeStrech
        {
            get
            {
                return PlaybackSpeed * PitchFactor == 1 ? PlaybackSpeed : 0;
            }
            set
            {
                PlaybackSpeed = value;
                PitchFactor = 1 / value;
            }
        }

        public long CurrentSample { get; private set; }


        // Events

        public void OnPlaybackStarted(EventArgs e)
        {
            PlaybackStarted?.Invoke(this, e);
        }

        public void OnPlaybackStopped(EventArgs e)
        {
            PlaybackStopped?.Invoke(this, e);
        }


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

        public PlaybackManager(WaveFormat waveFormat)
        {
            // Initialize buffer and wave output
            bufferedWaveProvider = new BufferedWaveProvider(waveFormat);
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

        public void AddTimeElapsedLabel(Label timeElapsedLabel)
        {
            this.timeElapsedLabel = timeElapsedLabel;
        }

        public void StartPlayback()
        {
            waveOut.Play();
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

        public byte[] AdjustSpeed(byte[] data)
        {
            CurrentSample += data.Length / 4;
            UpdateTimeElapsedLabel();

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

        private void UpdateTimeElapsedLabel()
        {
            TimeSpan timeElapsed = TimeSpan.FromSeconds(CurrentSample / 44100);
            timeElapsedLabel.Invoke((MethodInvoker)delegate
            {
                timeElapsedLabel.Text = "Samples: " + CurrentSample + "\n" + "Time: " + timeElapsed.ToString();
            });
        }

        public void Close()
        {
            // Make sure to stop audio output and dispose resources before closing the application
            waveOut.Stop();
            waveOut.Dispose();
        }
    }
}
