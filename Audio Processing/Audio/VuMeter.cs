using AudioProcessing.Events;
using AudioProcessing.GUI;

namespace AudioProcessing.Audio
{
    public class VuMeter
    {
        public const int MAX_DECIBEL = 3;
        public const int MIN_DECIBEL = -40;

        private VolumeMeter leftVolume;
        private VolumeMeter rightVolume;
        public float LeftVuLevel
        {
            get
            {
                return leftVolume.VolumeLevel;
            }
            private set
            {
                leftVolume.VolumeLevel = value;
            }
        }
        public float RightVuLevel
        {
            get
            {
                return rightVolume.VolumeLevel;
            }
            private set
            {
                rightVolume.VolumeLevel = value;
            }
        }

        public float Volume { get; set; }
        public float Pan { get; set; }
        public bool IsStereo { get; set; }

        public VuMeter(VolumeMeter leftVolume, VolumeMeter rightVolume)
        {
            this.leftVolume = leftVolume;
            this.rightVolume = rightVolume;

            // Set values to default
            Pan = 0.0f;
            Volume = 1.0f;
            IsStereo = true;
        }

        public void ApplyVolumeAndPan(float[] buffer)
        {
            float LeftVuMeterLevel = MIN_DECIBEL;
            float RightVuMeterLevel = MIN_DECIBEL;

            float leftVolume = Math.Clamp((1.0f - (Pan + 1.0f) / 2.0f) * 2.0f, 0.0f, 1.0f);
            float rightVolume = Math.Clamp((1.0f + (Pan - 1.0f) / 2.0f) * 2.0f, 0.0f, 1.0f);

            for (int i = 0; i < buffer.Length; i++)
            {
                // Apply pan volume to left and right
                float currentVolume = i % 2 == 0 ? leftVolume : rightVolume;


                float unclampedVolume = IsStereo ? buffer[i] * Volume : (buffer[i] + buffer[i + 1]) * 0.5f * Volume;

                buffer[i] = Math.Clamp(unclampedVolume * currentVolume, -1, 1);


                if (!IsStereo)
                {
                    buffer[++i] = Math.Clamp(unclampedVolume * rightVolume, -1, 1);
                }

                // Update VU meter level
                if (i % 2 == 0)
                {
                    LeftVuMeterLevel = VuMeterVolume(unclampedVolume * leftVolume, LeftVuMeterLevel);
                }
                else
                {
                    RightVuMeterLevel = VuMeterVolume(unclampedVolume * rightVolume, RightVuMeterLevel);

                    if (!IsStereo)
                    {
                        LeftVuMeterLevel = VuMeterVolume(unclampedVolume * leftVolume, LeftVuMeterLevel);
                    }
                }
            }

            LeftVuLevel = LeftVuMeterLevel;
            RightVuLevel = RightVuMeterLevel;
        }

        private float VuMeterVolume(float unclampedVolume, float currentLevel)
        {
            float currentVolume = LinearVolumeToLogVolume(Math.Abs(unclampedVolume), MIN_DECIBEL);
            return Math.Max(currentLevel, currentVolume);
        }

        public float LinearVolumeToLogVolume(float amplitude, float minAmplitude)
        {
            return (float)Math.Log10(Math.Max(Math.Abs(amplitude), Math.Pow(10, minAmplitude / 20))) * 20.0f;
        }

        public static float LogVolumeToLinearVolume(float amplitude)
        {
            return (float)(Math.Pow(10, amplitude / 20) - Math.Pow(10, MIN_DECIBEL / 20));
        }

        public static double LogVolumeToLinearVolume(double amplitude)
        {
            return (double)(Math.Pow(10, amplitude / 20) - Math.Pow(10, MIN_DECIBEL / 20));
        }
    }
}
