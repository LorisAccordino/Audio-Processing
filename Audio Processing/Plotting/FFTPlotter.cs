using AudioProcessing.Audio;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class FFTPlotter
    {
        private FastFourierTransform fft;
        private Tuner tuner;

        public FormsPlot FormsPlot { get; private set; }
        private DataLogger fftPlot;

        public double MaxDbRange
        {
            get
            {
                return FormsPlot.Plot.Axes.GetLimits().YRange.Max;
            }
            set
            {
                FormsPlot.Plot.Axes.SetLimitsY(-40, value);
            }
        }

        public double MaxHzRange
        {
            get
            {
                return FormsPlot.Plot.Axes.GetLimits().XRange.Max;
            }
            set
            {
                FormsPlot.Plot.Axes.SetLimitsX(0, value);
            }
        }

        public void DbLimitsChanged(object? sender, ValueChangedEventArgs e)
        {
            MaxDbRange = e.NewValue;
        }

        public void HzLimitsChanged(object? sender, ValueChangedEventArgs e)
        {
            MaxHzRange = e.NewValue * 1000f;
        }

        public FFTPlotter(FormsPlot formsPlot, int sampleRate)
        {
            FormsPlot = formsPlot;
            fft = new FastFourierTransform(sampleRate);

            // Initialize plot
            InitializePlot();

            // Set values to default
            MaxDbRange = 3;
            MaxHzRange = 20000;
        }

        private void InitializePlot()
        {
            FormsPlot.Interaction.Disable();
            fftPlot = FormsPlot.Plot.Add.DataLogger();

            fftPlot.ViewFull();
            fftPlot.ManageAxisLimits = false;

            FormsPlot.Plot.Title("FFT Spectrum");
            FormsPlot.Plot.YLabel("Amplitude (dB)");
            FormsPlot.Plot.XLabel("Frequency (Hz)");
        }

        public void AddTuner(Label toneLabel)
        {
            tuner = new Tuner(toneLabel);
        }

        public void UpdateFFTPlot(float[] audioData)
        {
            FastFourierTransform.FFTResult fFTResult = fft.ComputeFFT(audioData);

            // Update plot
            for (int i = 0; i < fFTResult.frequencies.Length / 2; i++)
            {
                if (fftPlot.Data.Coordinates.Count > i)
                {
                    fftPlot.Data.Coordinates[i] = new ScottPlot.Coordinates(fFTResult.frequencies[i], VuMeter.LogVolumeToLinearVolume(fFTResult.spectrum[i]) + VuMeter.MIN_DECIBEL);
                }
                else
                {
                    fftPlot.Add(fFTResult.frequencies[i], VuMeter.LogVolumeToLinearVolume(fFTResult.spectrum[i]) + VuMeter.MIN_DECIBEL);
                }
            }

            tuner.UpdateTone(fFTResult);

            FormsPlot.Invoke((MethodInvoker)delegate
            {
                FormsPlot.Refresh();
            });
        }

        public void Clear()
        {
            fftPlot.Data.Clear();
            FormsPlot.Refresh();
        }
    }
}