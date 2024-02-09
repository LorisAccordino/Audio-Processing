using AudioProcessing.Plotting;
using AudioProcessing;
using AudioProcessing.GUI;
using NAudio.Wave;

namespace AudioProcessing.Audio
{
    public class AudioProcessor
    {
        // Consts
        public const int CHUNK_SIZE = 4096;
        public const int SAMPLE_RATE = 44100;

        const int FFT_SIZE = 4096;
        const long OSAMP = 8L;

        // Audio streaming and processing/mixing
        //public ISampleProvider SourceStream { get; private set; }
        public IWaveProvider SourceStream { get; private set; }
        public Equalizer EQ { get; private set; }
        public VuMeter VuMeter { get; private set; }
        public EqualizerBand[] Bands { get; set; }
        public SMBPitchShiftingSampleProvider SMB { get; set; }

        private WaveOutEvent waveOut = new WaveOutEvent { DesiredLatency = 150, NumberOfBuffers = 3 };
        private BufferedWaveProvider bufferedWaveProvider;
        private Thread readThread;


        // Parameters
        public float PitchFactor
        {
            get
            {
                return SMB.PitchFactor;
            }
            set
            {
                SMB.PitchFactor = value;
            }
        }
        public PlaybackState PlaybackState
        {
            get
            {
                return waveOut.PlaybackState;
            }
            private set { }
        }

        public float Volume { get; set; }
        public float SpeedMultiplier { get; set; }
        public float Pan { get; set; }

        public bool IsStereo { get; set; }

        //public int CurrentSample { get; set; }


        private WaveformPlotter waveformPlotter;
        private SpectrumPlotter spectrumPlotter;

        public AudioProcessor(ISampleProvider sourceProvider, IWaveProvider waveFileProvider, EqualizerBand[] equalizerBands, WaveformPlotter waveformPlotter, SpectrumPlotter spectrumPlotter)
        {
            this.waveformPlotter = waveformPlotter;
            this.spectrumPlotter = spectrumPlotter;

            SourceStream = waveFileProvider;
            SMB = new SMBPitchShiftingSampleProvider(sourceProvider, FFT_SIZE, OSAMP, 1.0f);
            Bands = equalizerBands;
            UpdateEQ();

            // Initialize buffer and wave output
            bufferedWaveProvider = new BufferedWaveProvider(SourceStream.WaveFormat);
            bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(5);
            waveOut.Init(bufferedWaveProvider);

            // Reset values
            PitchFactor = 1.0f;
            SpeedMultiplier = 1.0f;
            Pan = 0.0f;
            Volume = 1.0f;
            IsStereo = true;
        }

        public void Start()
        {
            // Start stream reading in separate thread
            readThread = new Thread(ReadStream);
            readThread.Start();
        }

        public void InitVuMeter(VolumeMeter leftVolume, VolumeMeter rightVolume)
        {
            // Initialize VU meter
            VuMeter = new VuMeter(leftVolume, rightVolume);
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
            waveOut.Pause();
        }

        private void ReadStream()
        {
            byte[] buffer = new byte[CHUNK_SIZE * sizeof(float)];
            float[] floatBuffer = new float[CHUNK_SIZE];
            //short[] shortBuffer = new short[CHUNK_SIZE];

            //while (Mixer.EQ.Read(floatBuffer, 0, floatBuffer.Length) > 0 && waveOut.PlaybackState != PlaybackState.Stopped)
            while (EQ.Read(floatBuffer, 0, floatBuffer.Length) > 0 && waveOut.PlaybackState != PlaybackState.Stopped)
            {

                // Wait for resume
                /*while (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    Thread.Sleep(10);
                }*/

                // Apply volume and get VU meter level
                VuMeter.ApplyVolumeAndPan(floatBuffer, Volume, Pan, IsStereo);

                short[] shortBuffer = ConversionUtils.ConvertFloatArrayToShortArray(floatBuffer);
                buffer = ConversionUtils.ConvertShortArrayToByteArray(shortBuffer);


                // Apply speed on playback
                byte[] resampledBuffer = VarispeedPlayback(buffer, (double)SpeedMultiplier);

                // Update waveforms and spectrum plots
                waveformPlotter.UpdateWaveformPlots(floatBuffer);
                spectrumPlotter.UpdateSpectrumPlot(floatBuffer);

                // Wait for resume
                while (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    Thread.Sleep(10);
                }


                if (bufferedWaveProvider.BufferedBytes > bufferedWaveProvider.BufferLength / 10)
                {
                    Thread.Sleep(65);
                }
                Thread.Sleep(10);
            }
            waveOut.Stop();
        }



        private byte[] VarispeedPlayback(byte[] data, double PlaybackRate)
        {
            if (bufferedWaveProvider != null)
            {
                if (Math.Abs(PlaybackRate - 1) > double.Epsilon)
                {
                    // Resample audio if playback speed changed
                    var newRate = Convert.ToInt32(SourceStream.WaveFormat.SampleRate / PlaybackRate);
                    var wf = new WaveFormat(newRate, 16, SourceStream.WaveFormat.Channels);
                    var resampleInputMemoryStream = new MemoryStream(data) { Position = 0 };

                    WaveStream ws = new RawSourceWaveStream(resampleInputMemoryStream, SourceStream.WaveFormat);
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

        private void UpdateEQ()
        {
            EQ = new Equalizer(SMB, Bands);
        }

        public void UpdateEQ(EqualizerBand[] bands)
        {
            Bands = bands;
            EQ = new Equalizer(SMB, Bands);
        }


        public void Close()
        {
            // Make sure to stop audio output and dispose resources before closing the application
            waveOut.Stop();
            waveOut.Dispose();

            // Wait for the read thread to finish before closing the form
            readThread.Join();
        }
    }
}
