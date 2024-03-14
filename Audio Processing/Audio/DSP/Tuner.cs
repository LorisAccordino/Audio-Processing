using AudioProcessing.Common;
using AudioProcessing.Events;

namespace AudioProcessing.Audio.DSP
{
    public class Tuner
    {
        // Events
        public event EventHandler<ValueEventArgs<string>>? ToneChanged;
        public ActionWithInvoke<string>? ToneChangedAction { get; set; }
        public void OnToneUpdated(ValueEventArgs<string> e)
        {
            ToneChanged?.Invoke(this, e);
            ToneChangedAction?.Execute(e.Value);
        }

        public Tuner()
        {

        }

        public void UpdateTone(FastFourierTransform.FFTResult fftResult)
        {
            double currentTone = ToneFromFFT(fftResult);
            string formattedString = Utils.FormatMusicalNote(currentTone) + " / " + Utils.FormatMusicalNote(currentTone, true) + $"\n ({(int)currentTone} Hz)";
            OnToneUpdated(new ValueEventArgs<string>(formattedString));
        }

        public double ToneFromFFT(FastFourierTransform.FFTResult fftResult)
        {
            // Find the index of the maximum value in the spectrum array
            int maxIndex = Array.IndexOf(fftResult.spectrum, fftResult.spectrum.Max());

            // Return the corresponding frequency with the maximum amplitude (current tone)
            return fftResult.frequencies[maxIndex];
        }
    }
}
