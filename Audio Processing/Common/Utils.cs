using AudioProcessing.Audio;

namespace AudioProcessing.Common
{
    public static class Utils
    {

        #region String formats

        public static string FormatTimeElapsed(long currentSample, TimeFormat format)
        {
            TimeSpan timeElapsed = TimeSpan.FromSeconds(currentSample / (float)AudioProcessor.SAMPLE_RATE);

            switch (format)
            {
                case TimeFormat.Samples:
                    return currentSample.ToString("000,000,000");
                case TimeFormat.Seconds:
                    return timeElapsed.TotalSeconds.ToString("000,000");
                case TimeFormat.Milliseconds:
                    return timeElapsed.TotalMilliseconds.ToString("000,000,000");
                case TimeFormat.Total:
                    return timeElapsed.Minutes.ToString("00") + ":" + timeElapsed.Seconds.ToString("00") + "," + timeElapsed.Milliseconds.ToString("000");
                default:
                    return "";
            }
        }

        public static string FormatMusicalNote(double frequency, bool europeanNotation = true)
        {
            if (frequency < 10)
            {
                return "---";
            }

            double offset = 3.5;
            double referenceFrequency = 440.0;
            double semitoneDifference = (int)(12.0 * Math.Log2(frequency / referenceFrequency));

            int noteIndex = (int)(Math.Round(semitoneDifference) % 12 - offset);
            while (noteIndex < 0)
            {
                noteIndex += 12;
            }

            int octave = 4 + (int)Math.Floor((semitoneDifference + 9.5f) / 12);

            string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string[] europeanNoteNames = { "DO", "DO#", "RE", "RE#", "MI", "FA", "FA#", "SOL", "SOL#", "LA", "LA#", "SI" };

            int index = Math.Clamp(noteIndex, 0, 11);
            return (europeanNotation ? europeanNoteNames[index] : noteNames[index]) + octave.ToString();
        }

        #endregion

        #region Enums

        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return new List<T>(Enum.GetValues(typeof(T)) as T[]);
        }

        #endregion

        #region Lists and generic objects

        public static List<object> ConvertListToObjects<T>(List<T> inputList)
        {
            return inputList.Cast<object>().ToList();
        }

        public static object[] ConvertArrayToObjects<T>(T[] inputArray)
        {
            return inputArray.Cast<object>().ToArray();
        }

        #endregion

        #region Events
        public static void CheckboxCheckedChangedAction(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Tag is Action<bool> action)
                {
                    action(checkBox.Checked);
                }
            }
        }

        public static void ComboboxIndexChangedAction(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.Tag is Action<object> action)
                {
                    action(comboBox.SelectedItem);
                }
            }
        }
        #endregion
    }
}
