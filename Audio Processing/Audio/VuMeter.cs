using AudioProcessing.Common;
using AudioProcessing.Events;
using System.Diagnostics;

namespace AudioProcessing.Audio
{
    public class VuMeter
    {

        // Properties
        public float Volume { get; set; }
        public float Pan { get; set; }
        public bool IsStereo { get; set; }

        // Timing
        private Stopwatch frameTimer = new Stopwatch();

        // Events
        public event EventHandler<ValueEventArgs<StereoVolume>>? VolumeChanged;
        public event EventHandler<ValueEventArgs<float>>? SpeakerUpdated;

        public void OnVolumeChanged(ValueEventArgs<StereoVolume> e)
        {
            VolumeChanged?.Invoke(this, e);
        }

        public void OnSpeakerUpdated(ValueEventArgs<float> e)
        {
            SpeakerUpdated?.Invoke(this, e);
        }

        public VuMeter()
        {
            // Set values to default
            Pan = 0.0f;
            Volume = 1.0f;
            IsStereo = true;

            // Start the frame timer
            frameTimer.Start();
        }

        public void ApplyVolumeAndPan(float[] buffer)
        {
            float LeftVuMeterLevel = float.MinValue;
            float RightVuMeterLevel = float.MinValue;

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
                    LeftVuMeterLevel = UpdateVuMeter(unclampedVolume * leftVolume, LeftVuMeterLevel);
                }
                else
                {
                    RightVuMeterLevel = UpdateVuMeter(unclampedVolume * rightVolume, RightVuMeterLevel);

                    if (!IsStereo)
                    {
                        LeftVuMeterLevel = UpdateVuMeter(unclampedVolume * leftVolume, LeftVuMeterLevel);
                    }
                }
            }

            if (frameTimer.ElapsedMilliseconds >= 1000f / AudioProcessor.TARGET_FPS)
            {
                OnSpeakerUpdated(new ValueEventArgs<float>(buffer[0]));
                OnVolumeChanged(new ValueEventArgs<StereoVolume>(new StereoVolume(LeftVuMeterLevel, RightVuMeterLevel)));
                frameTimer.Restart();
            }
        }

        private float UpdateVuMeter(float unclampedVolume, float previousVolume)
        {
            float currentVolume = (float)VolumeConverter.LinearAmplitudeToLogVolume(Math.Abs(unclampedVolume));
            return Math.Max(previousVolume, currentVolume);
        }
    }

    public struct StereoVolume
    {
        public float LeftVolume;
        public float RightVolume;

        public StereoVolume(float leftVolume, float rightVolume)
        {
            this.LeftVolume = leftVolume;
            this.RightVolume = rightVolume;
        }
    }
}
