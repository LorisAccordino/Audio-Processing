namespace AudioProcessing.Audio.DSP
{
    public class Tuner
    {
        private Label toneLabel;

        public Tuner(Label toneLabel)
        {
            this.toneLabel = toneLabel;
        }

        public void UpdateTone(FastFourierTransform.FFTResult fftResult)
        {
            double currentTone = ToneFromFFT(fftResult);
            toneLabel.Invoke((MethodInvoker)delegate
            {
                toneLabel.Text = FrequencyToNote(currentTone);
            });
        }

        public double ToneFromFFT(FastFourierTransform.FFTResult fftResult)
        {
            // Find the index of the maximum value in the spectrum array
            int maxIndex = Array.IndexOf(fftResult.spectrum, fftResult.spectrum.Max());

            // Return the corresponding frequency with the maximum amplitude (current tone)
            return fftResult.frequencies[maxIndex];
        }

        private string FrequencyToNote(double frequency)
        {
            if (frequency <= 0)
            {
                return toneLabel.Text;
            }

            // Reference frequency for A4 (La4) in Hz
            double referenceFrequency = 440.0;

            // Calculate semitone difference compared to A4
            double semitoneDifference = 12.0 * Math.Log2(frequency / referenceFrequency);

            // Semitone mapping to note
            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

            int noteIndex = (int)Math.Round(semitoneDifference) % 12;
            if (noteIndex < 0)
            {
                noteIndex += 12;
            }

            int octave = 4 + (int)Math.Floor((semitoneDifference + 9) / 12); // A4 is in the 4th octave

            // Format note as string
            string formattedNote = $"{noteNames[noteIndex]}{octave}";

            // Add Italian note name (e.g., "C" -> "DO")
            string italianNoteName = TranslateToItalian(noteNames[noteIndex]);
            formattedNote += $" / {italianNoteName}{octave}";

            // Return the formatted string with frequency and note (limited to 1 decimal place)
            return $"{formattedNote} ({frequency:F1} Hz)";
        }

        private string TranslateToItalian(string englishNoteName)
        {
            // Mappings of English/Italian notes names
            Dictionary<string, string> italianNoteNames = new Dictionary<string, string>
            {
                { "C", "DO" },
                { "C#", "DO#" },
                { "D", "RE" },
                { "D#", "RE#" },
                { "E", "MI" },
                { "F", "FA" },
                { "F#", "FA#" },
                { "G", "SOL" },
                { "G#", "SOL#" },
                { "A", "LA" },
                { "A#", "LA#" },
                { "B", "SI" }
            };

            return italianNoteNames.TryGetValue(englishNoteName, out string italianNote) ? italianNote : englishNoteName;
        }
    }
}
