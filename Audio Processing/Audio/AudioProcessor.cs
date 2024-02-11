using AudioProcessing.Plotting;
using AudioProcessing.GUI;
using NAudio.Wave;
using AudioProcessing.Audio.DSP;
using OpenTK.Graphics.OpenGL;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AudioProcessing.Audio
{
    public class AudioProcessor
    {
        // Consts
        public const int CHUNK_SIZE = 4096;
        public const int SAMPLE_RATE = 44100;

        // Audio reading/streaming
        public PlaybackManager PlaybackManager { get; private set; }
        private Thread readThread;

        private WaveIn waveIn;
        private WaveOut waveOut;

        // Audio processing/mixing
        public Mixer Mixer { get; private set; }
        public VuMeter VuMeter { get; private set; }

        // Plotters
        private WaveformPlotter waveformPlotter;
        private FFTPlotter fftPlotter;

        public AudioProcessor(ISampleProvider sourceProvider, IWaveProvider waveFileProvider)
        {
            PlaybackManager = new PlaybackManager(sourceProvider, waveFileProvider);
            Mixer = new Mixer(PlaybackManager.SMB);
        }

        private BufferedWaveProvider bufferedWaveProvider;

        public AudioProcessor()
        {
            waveIn = new WaveIn();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(SAMPLE_RATE, 1);
            waveIn.BufferMilliseconds = (int)((double)CHUNK_SIZE / (double)SAMPLE_RATE * 1000.0);
            waveIn.DataAvailable += WaveIn_DataAvailable;

            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            bufferedWaveProvider.BufferLength = CHUNK_SIZE * 2;
            bufferedWaveProvider.DiscardOnBufferOverflow = true;

            waveOut = new WaveOut();
            waveOut.Init(bufferedWaveProvider);
        }

        public void StartProfiling()
        {
            waveIn.StartRecording();
            waveOut.Play();
        }

        public void Start()
        {
            // Start stream reading in separate thread
            readThread = new Thread(ReadStream);
            readThread.Start();
        }

        public void AddVuMeter(VolumeMeter leftVolume, VolumeMeter rightVolume)
        {
            VuMeter = new VuMeter(leftVolume, rightVolume);
        }

        public void AddPlotters(WaveformPlotter waveformPlotter, FFTPlotter fftPlotter)
        {
            this.waveformPlotter = waveformPlotter;
            this.fftPlotter = fftPlotter;
        }

        public float[] ConvertBytesToFloat(byte[] byteArray)
        {
            // Determina il numero di byte per campione (ad esempio, 2 byte per PCM a 16 bit)
            int bytesPerSample = 2;

            // Calcola il numero di campioni nel buffer di byte
            int numSamples = byteArray.Length / bytesPerSample;

            // Inizializza l'array di float
            float[] floatArray = new float[numSamples];

            // Effettua la conversione da byte a float
            for (int i = 0; i < numSamples; i++)
            {
                // Leggi il valore a 16 bit dal buffer di byte
                short sampleValue = BitConverter.ToInt16(byteArray, i * bytesPerSample);

                // Normalizza il valore a float nell'intervallo -1.0 a 1.0
                float normalizedValue = sampleValue / 32768.0f;

                // Assegna il valore normalizzato all'array di float
                floatArray[i] = normalizedValue;
            }

            return floatArray;
        }


        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] buffer = e.Buffer;
            float[] floatBuffer = ConvertBytesToFloat(buffer);

            // Apply volume and get VU meter level
            VuMeter.ApplyVolumeAndPan(floatBuffer);

            //short[] shortBuffer = ConversionUtils.ConvertFloatArrayToShortArray(floatBuffer);
            //buffer = ConversionUtils.ConvertShortArrayToByteArray(shortBuffer);

            // Apply varispeed on playback
            //PlaybackManager.AdjustSpeed(buffer);

            // Update waveforms and fft plots
            //waveformPlotter.UpdateWaveformPlots(floatBuffer);
            fftPlotter.UpdateFFTPlot(floatBuffer);
            //waveformPlotter.UpdateEQplots(floatBuffer);

            // Wait for the buffer to empty enough
            /*while (PlaybackManager.IsBufferOverfull() && PlaybackManager.IsAlive())
            {
                Thread.Sleep(10);
            }*/

            bufferedWaveProvider.AddSamples(buffer, 0, buffer.Length);
        }

        private void ReadStream()
        {
            byte[] buffer = new byte[CHUNK_SIZE * sizeof(float)];
            float[] floatBuffer = new float[CHUNK_SIZE];

            while (Mixer.Read(floatBuffer, 0, floatBuffer.Length) > 0 && PlaybackManager.IsAlive())
            {
                // Apply volume and get VU meter level
                VuMeter.ApplyVolumeAndPan(floatBuffer);

                short[] shortBuffer = ConversionUtils.ConvertFloatArrayToShortArray(floatBuffer);
                buffer = ConversionUtils.ConvertShortArrayToByteArray(shortBuffer);

                // Apply varispeed on playback
                PlaybackManager.AdjustSpeed(buffer);

                // Update waveforms and fft plots
                waveformPlotter.UpdateWaveformPlots(floatBuffer);
                fftPlotter.UpdateFFTPlot(floatBuffer);
                waveformPlotter.UpdateEQplots(floatBuffer);

                // Wait for the buffer to empty enough
                while (PlaybackManager.IsBufferOverfull() && PlaybackManager.IsAlive())
                {
                    Thread.Sleep(10);
                }
            }
        }

        private void UpdateEQ(EqualizerBand[] equalizerBands)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            PlaybackManager.Close();
            // Wait for the read thread to finish before closing the form
            readThread.Join();
        }
    }
}
