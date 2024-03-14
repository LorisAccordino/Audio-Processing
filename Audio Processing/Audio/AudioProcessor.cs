using AudioProcessing.Plotting;
using NAudio.Wave;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Common;

namespace AudioProcessing.Audio
{
    public class AudioProcessor
    {
        // Instance
        private static AudioProcessor _instance;
        public static AudioProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AudioProcessor();
                }
                return _instance;
            }
        }

        // Consts
        public const int CHUNK_SIZE = 256;
        public const int SAMPLE_RATE = 44100; // 44.1 kHz
        public const int CHANNELS = 2; // Stereo Audio
        public const int TARGET_FPS = 30;
        public static readonly WaveFormat WAVE_FORMAT = new WaveFormat(SAMPLE_RATE, CHANNELS);  


        // Audio
        public Mixer Mixer { get; private set; }
        public PlaybackManager PlaybackManager { get; private set; }
        public VuMeter VuMeter { get; private set; } = new VuMeter();

        // Synth
        public Synthesizer Synthesizer { get { return synthesizerDialog.synthesizer; } }
        private SynthesizerDialog synthesizerDialog = new SynthesizerDialog();


        // Plotters
        public WaveformPlotter WaveformPlotter { get; private set; } = new WaveformPlotter();
        public FFTPlotter FFTplotter { get; set; }

        // Thread
        private Thread thread;
        private float[] floatBuffer;
        private bool shouldClose = false;

        public AudioProcessor()
        {
            floatBuffer = new float[CHUNK_SIZE];
        }

        public void StartWAV(ISampleProvider sourceProvider)
        {
            PlaybackManager = new PlaybackManager(sourceProvider, WAVE_FORMAT);
            PlaybackManager.SpeedChanged += OnSpeedChanged;
            Mixer = new Mixer(PlaybackManager.SMB);

            // Init waveform EQs
            WaveformPlotter.InitEQs(PlaybackManager.SMB); 
        }

        public void StartThread()
        {
            // Start thread
            thread = new Thread(ThreadRoutine);
            thread.Start();
        }

        public void StartSynth()
        {
            synthesizerDialog.Show();
        }

        private void OnSpeedChanged(object? sender, EventArgs e)
        {
            float speed = PlaybackManager.PlaybackSpeed;
            int dynamicChunkSize = (int)((CHUNK_SIZE * speed) / 4) * 4;
            floatBuffer = new float[Math.Max(4, dynamicChunkSize)];
        }

        private void ThreadRoutine()
        {
            byte[] buffer = new byte[CHUNK_SIZE];
            while (Mixer.Read(floatBuffer, 0, floatBuffer.Length) > 0 && PlaybackManager.IsAlive())
            {
                // Apply volume and get VU meter level
                VuMeter.ApplyVolumeAndPan(floatBuffer);

                // Update waveforms plots
                WaveformPlotter.UpdateWaveformPlots(floatBuffer);

                // Convert float buffer to bytes buffer to apply speed
                buffer = BufferConverter.ConvertFloatToByte(floatBuffer);

                // Apply speed
                PlaybackManager.ApplySpeed(buffer);

                // Convert bytes buffer to float buffer "again" (to avoid issues on FFT)
                floatBuffer = BufferConverter.ConvertByteToFloat(buffer);

                // Update fft plot
                FFTplotter.UpdateFFTPlot(floatBuffer, PlaybackManager.PlaybackSpeed);

                // Wait for the buffer to empty enough
                while (PlaybackManager.IsBufferOverfull() && PlaybackManager.IsAlive())
                {
                    Thread.Sleep(10);
                }
            }

            if (shouldClose)
            {
                Application.Exit();
            }
        }

        public void Close()
        {
            PlaybackManager.Close();
            shouldClose = true;
        }
    }
}