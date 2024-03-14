using NAudio.Wave;

namespace AudioProcessing.Audio.DSP
{
    public class Mixer
    {
        private Equalizer equalizer;
        private EqualizerBand[] bands = LOW_MID_HIGH;

        public Mixer(ISampleProvider sampleProvider)
        {
            equalizer = new Equalizer(sampleProvider, bands);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            return equalizer.Read(buffer, offset, count);
        }

        public static readonly EqualizerBand[] ISOLATED_LOW =
        {
            // Low
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 100,
                Gain = 0.0f
            }, 

            // Mid
            new EqualizerBand
            {
                Bandwidth = 0.5f,
                Frequency = 1000,
                Gain = -24.0f
            }, 

            // High
            new EqualizerBand
            {
                Bandwidth = 0.25f,
                Frequency = 5000,
                Gain = -48.0f
            },
        };

        public static readonly EqualizerBand[] ISOLATED_MID =
        {
            // Low
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 100,
                Gain = -48.0f
            }, 

            // Mid
            new EqualizerBand
            {
                Bandwidth = 0.5f,
                Frequency = 1000,
                Gain = 0.0f
            }, 

            // High
            new EqualizerBand
            {
                Bandwidth = 0.25f,
                Frequency = 8000,
                Gain = -24.0f
            },
        };

        public static readonly EqualizerBand[] ISOLATED_HIGH =
        {
            // Low
            new EqualizerBand
            {
                Bandwidth = 1.0f,
                Frequency = 100,
                Gain = -48.0f
            }, 

            // Mid
            new EqualizerBand
            {
                Bandwidth = 0.5f,
                Frequency = 800,
                Gain = -24.0f
            }, 

            // High
            new EqualizerBand
            {
                Bandwidth = 0.25f,
                Frequency = 5000,
                Gain = 0.0f
            },
        };

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
                Bandwidth = 0.5f,
                Frequency = 1000
            }, 

            // High
            new EqualizerBand
            {
                Bandwidth = 0.25f,
                Frequency = 5000
            },
        };

        public float[] GetGains()
        {
            float[] gains = new float[bands.Length];
            for (int i = 0; i < bands.Length; i++)
            {
                gains[i] = bands[i].Gain;
            }
            return gains;
        }

        public void UpdateGain(float gain, int index)
        {
            float[] gains = GetGains();
            gains[index] = gain;

            UpdateGains(gains);
        }

        public void UpdateGains(params float[] gains)
        {
            for (int i = 0; i < Math.Min(bands.Length, gains.Length); i++)
            {
                bands[i].Gain = gains[i];
            }
            equalizer.Update();
        }
    }
}
