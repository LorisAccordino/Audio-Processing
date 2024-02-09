namespace AudioProcessing.Audio
{
    public class Mixer
    {
        public static readonly EqualizerBand[] LOW_MID_HIGH = { 
            // Low
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 100
            }, 

            // Mid
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 1000
            }, 

            // High
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 5000
            },
        };

        public static EqualizerBand[] MultipleBands(params EqualizerBand[] bands)
        {
            return bands.ToArray();
        }
    }
}
