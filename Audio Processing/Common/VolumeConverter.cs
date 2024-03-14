namespace AudioProcessing.Common
{
    /// <summary>
    /// Provides a converter from linear amplitude value to logarithmic dB volume and viceversa
    /// </summary>
    public static class VolumeConverter
    {
        public const int MAX_DECIBEL = 3;
        public const int MIN_DECIBEL = -40;
        private static double MinDbPower = Math.Pow(10, MIN_DECIBEL / 20);

        /// <summary>
        /// Converts the given linear amplitude to a logarithmic volume in dB.
        /// </summary>
        /// <remarks>
        /// A minimum volume threshold (<see cref="MIN_DECIBEL"/>) is used if <paramref name="amplitude"/> is too low.
        /// </remarks>
        /// <param name="amplitude">Linear amplitude to convert in dB</param>
        /// <returns>The converted volume in dB.</returns>
        public static double LinearAmplitudeToLogVolume(double amplitude)
        {
            return 20.0 * Math.Log10(Math.Max(Math.Abs(amplitude), MinDbPower));
        }

        /// <summary>
        /// Converts the given volume in dB to a linear amplitude.
        /// </summary>
        /// <remarks>
        /// A minimum volume threshold (<see cref="MIN_DECIBEL"/>) is used if <paramref name="volume"/> is too low.
        /// </remarks>
        /// <param name="volume"></param>
        /// <returns>The converted linear amplitude.</returns>
        public static double LogVolumeToLinearAmplitude(double volume)
        {
            return Math.Pow(10, volume / 20.0) - MinDbPower;
        }
    }
}
