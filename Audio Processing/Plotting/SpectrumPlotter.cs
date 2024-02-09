using System.Diagnostics;
using System.Numerics;
using AudioProcessing.Audio;
using MathNet.Numerics.IntegralTransforms;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class SpectrumPlotter
    {
        public FormsPlot FormsPlot { get; private set; }

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

        private DataLogger spectrumPlot;
        private readonly int sampleRate;

        public SpectrumPlotter(FormsPlot formsPlot, int sampleRate)
        {
            FormsPlot = formsPlot;
            this.sampleRate = sampleRate;

            // Initialize plot
            InitializePlot();

            MaxDbRange = 3;
            MaxHzRange = 20000;
        }

        private void InitializePlot()
        {
            FormsPlot.Interaction.Disable();
            spectrumPlot = FormsPlot.Plot.Add.DataLogger();

            spectrumPlot.ViewFull();
            spectrumPlot.ManageAxisLimits = false;

            FormsPlot.Plot.Title("FFT Spectrum");
            FormsPlot.Plot.YLabel("Amplitude (dB)");
            FormsPlot.Plot.XLabel("Frequency (Hz)");
        }

        private double maxValue = VuMeter.MIN_DECIBEL;

        public void UpdateSpectrumPlot(float[] audioData)
        {
            // Compute the FFT
            Complex[] fftResult = FFT(audioData);

            // Calculate frequencies spectrum (magnitude)
            double[] spectrum = CalculateSpectrum(fftResult);

            // Get the frequencies corresponding to the indexes of the spectrum
            //double[] frequencies = Fourier.FrequencyScale(sampleRate, spectrum.Length);
            double[] frequencies = Fourier.FrequencyScale(spectrum.Length, sampleRate);

            // Update plot
            //FormsPlot.Plot.Clear();
            //spectrumPlot.Data.Clear();

            for (int i = 0; i < frequencies.Length / 2; i++)
            {
                if (spectrumPlot.Data.Coordinates.Count > i)
                {
                    spectrumPlot.Data.Coordinates[i] = new ScottPlot.Coordinates(frequencies[i], VuMeter.LogVolumeToLinearVolume(spectrum[i]) + VuMeter.MIN_DECIBEL);
                    //spectrumPlot.Data.Coordinates[i] = new ScottPlot.Coordinates(frequencies[i], spectrum[i]);
                }
                else
                {
                    spectrumPlot.Add(frequencies[i], VuMeter.LogVolumeToLinearVolume(spectrum[i]) + VuMeter.MIN_DECIBEL);
                    //spectrumPlot.Add(frequencies[i], spectrum[i]);
                }

                if (spectrum[i] > maxValue)
                {
                    maxValue = spectrum[i];
                    Debug.WriteLine("MAX SPECTRUM VALUE: " + maxValue);
                }
            }

            //formsPlot.Plot.PlotScatter(frequencies, spectrum, markerSize: 3);
            //formsPlot.Render();

            FormsPlot.Invoke((MethodInvoker)delegate
            {
                FormsPlot.Refresh();
            });
        }


        private Complex[] FFT(float[] audioData)
        {
            Complex[] fftResult = new Complex[audioData.Length];
            for (int i = 0; i < audioData.Length; i++)
            {
                fftResult[i] = new Complex(audioData[i], 0);
            }

            Fourier.Forward(fftResult);

            return fftResult;
        }

        private double[] CalculateSpectrum(Complex[] fftResult)
        {
            double[] spectrum = new double[fftResult.Length / 2];

            for (int i = 0; i < spectrum.Length; i++)
            {
                // Calcola la magnitudine in dB
                spectrum[i] = 20 * Math.Log10(fftResult[i].Magnitude);
            }

            return spectrum;
        }
    }
}