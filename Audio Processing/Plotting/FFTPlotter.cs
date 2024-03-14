using AudioProcessing.Audio;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Common;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using System.Diagnostics;

namespace AudioProcessing.Plotting
{
    public class FFTPlotter
    {
        private const int MAX_QUEUE_SIZE = 100;

        private Queue<float[]> audioDataQueue = new Queue<float[]>();
        private FastFourierTransform fft = new FastFourierTransform(AudioProcessor.SAMPLE_RATE);

        public Tuner Tuner { get; private set; } = new Tuner();
        public readonly FormsPlot formsPlot;
        private readonly DataLogger fftPlot;

        public double MaxDbRange
        {
            get
            {
                return formsPlot.Plot.Axes.GetLimits().YRange.Max;
            }
            set
            {
                formsPlot.Plot.Axes.SetLimitsY(-40, value);
            }
        }

        public double MaxHzRange
        {
            get
            {
                return formsPlot.Plot.Axes.GetLimits().XRange.Max;
            }
            set
            {
                formsPlot.Plot.Axes.SetLimitsX(0, value);
            }
        }

        // Timing
        private Stopwatch frameTimer = new Stopwatch();

        public FFTPlotter(FormsPlot formsPlot)
        {
            // Initialize forms plot
            this.formsPlot = formsPlot;
            formsPlot.Plot.Title("FFT Spectrum");
            formsPlot.Plot.YLabel("Amplitude (dB)");
            formsPlot.Plot.XLabel("Frequency (Hz)");
            formsPlot.Interaction.Disable();

            // Initialize plot
            fftPlot = formsPlot.Plot.Add.DataLogger();
            fftPlot.ViewFull();
            fftPlot.ManageAxisLimits = false;

            // Set values to default
            MaxDbRange = 3;
            MaxHzRange = 16000;

            // Start the frame timer
            frameTimer.Start();
        }

        public void UpdateFFTPlot(float[] audioData, float speed)
        {
            // Add the new frame to the queue
            audioDataQueue.Enqueue(audioData);

            // If the queue has reached the max size, remove the oldest frame
            if (audioDataQueue.Count > MAX_QUEUE_SIZE / speed)
            {
                while (audioDataQueue.Count > MAX_QUEUE_SIZE / speed)
                {
                    audioDataQueue.Dequeue();
                }
            }

            if (frameTimer.ElapsedMilliseconds < 1000f / AudioProcessor.TARGET_FPS)
            {
                return;
            }

            frameTimer.Restart();

            // Calculate FFT on queue of audio frames
            float[] concatenatedData = audioDataQueue.SelectMany(data => data).ToArray();

            //FastFourierTransform.FFTResult fFTResult = fft.ComputeFFT(audioData);
            FastFourierTransform.FFTResult fFTResult = fft.ComputeFFT(concatenatedData);

            // Update plot
            for (int i = 0; i < fFTResult.frequencies.Length / 2; i++)
            {
                if (fftPlot.Data.Coordinates.Count > i)
                {
                    fftPlot.Data.Coordinates[i] = new ScottPlot.Coordinates(fFTResult.frequencies[i], (float)VolumeConverter.LogVolumeToLinearAmplitude(fFTResult.spectrum[i]) + VolumeConverter.MIN_DECIBEL);
                }
                else
                {
                    fftPlot.Add(fFTResult.frequencies[i], VolumeConverter.LogVolumeToLinearAmplitude(fFTResult.spectrum[i]) + VolumeConverter.MIN_DECIBEL);
                }
            }

            Tuner.UpdateTone(fFTResult);

            formsPlot.Invoke((MethodInvoker)delegate
            {
                formsPlot.Refresh();
            });
        }

        public void Clear()
        {
            fftPlot.Data.Clear();
            formsPlot.Refresh();
        }
    }
}