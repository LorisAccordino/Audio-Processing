using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace AudioProcessing.Audio.DSP
{
    public class FastFourierTransform
    {
        private int sampleRate;
        public FastFourierTransform(int sampleRate)
        {
            this.sampleRate = sampleRate;
        }

        public FFTResult ComputeFFT(float[] audioData)
        {
            // Compute the FFT
            Complex[] fftResult = FFT(audioData);

            // Calculate frequencies spectrum (magnitude)
            double[] spectrum = CalculateSpectrum(fftResult);

            // Get the frequencies corresponding to the indexes of the spectrum
            double[] frequencies = Fourier.FrequencyScale(spectrum.Length, sampleRate);

            return new FFTResult(frequencies, spectrum);
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

        public struct FFTResult
        {
            public FFTResult(double[] frequencies, double[] spectrum)
            {
                this.frequencies = frequencies;
                this.spectrum = spectrum;
            }

            public double[] frequencies;
            public double[] spectrum;
        }
    }
}
