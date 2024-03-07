using AudioProcessing.Plotting;
using AudioProcessing.GUI;
using NAudio.Wave;
using AudioProcessing.Audio.DSP;

namespace AudioProcessing.Audio
{
    public class AudioProcessor
    {
        // Consts
        public const int CHUNK_SIZE = 4096;
        public const int SAMPLE_RATE = 44100;
        public const int CHANNELS = 2;

        public static readonly WaveFormat WAVE_FORMAT = new WaveFormat(SAMPLE_RATE, CHANNELS);

        // Audio reading/streaming
        public PlaybackManager PlaybackManager { get; private set; }
        private Thread readThread;

        // Audio processing/mixing
        public Mixer Mixer { get; private set; }
        public VuMeter VuMeter { get; private set; }

        // Plotters
        private WaveformPlotter waveformPlotter;
        private FFTPlotter fftPlotter;

        public AudioProcessor(ISampleProvider sourceProvider)
        {
            PlaybackManager = new PlaybackManager(sourceProvider, WAVE_FORMAT);
            Mixer = new Mixer(PlaybackManager.SMB);
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

                floatBuffer = ConvertBytesToFloat(buffer);

                // Update waveforms and fft plots
                waveformPlotter.UpdateWaveformPlots(floatBuffer);
                fftPlotter.UpdateFFTPlot(floatBuffer, PlaybackManager.PlaybackSpeed);

                // Wait for the buffer to empty enough
                while (PlaybackManager.IsBufferOverfull() && PlaybackManager.IsAlive())
                {
                    Thread.Sleep(10);
                }


                // TO TEST!!!
                float speed = PlaybackManager.PlaybackSpeed;
                int dynamicChunkSize = (int)((CHUNK_SIZE * speed) / 4) * 4;
                floatBuffer = new float[dynamicChunkSize];
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