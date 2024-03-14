using AudioProcessing.Audio;
using AudioProcessing.Common;
using AudioProcessing.Events;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace AudioProcessing.GUI
{
    public class VolumeMeter : Control
    {
        private IContainer components;

        private float volume;

        /// <summary>
        /// Current volume level in dB.
        /// </summary>
        [DefaultValue(-3.0)]
        public float VolumeLevel
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;

                volume = Math.Clamp(value, MinDb, MaxDb);
                Invalidate();
            }
        }

        public AudioChannel Channel { get; set; }

        /// <summary>
        /// Minimum volume level in dB
        /// </summary>

        [DefaultValue(-40.0)]
        public float MinDb { get; set; }

        /// <summary>
        /// Maximum volume level in dB
        /// </summary>

        [DefaultValue(3.0)]
        public float MaxDb { get; set; }


        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation { get; set; }

        public VolumeMeter()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            MinDb = -40f;
            MaxDb = 3f;
            VolumeLevel = 0f;
            Orientation = Orientation.Vertical;
            Width = 30;
            Height = 100;

            InitializeComponent();
            OnForeColorChanged(EventArgs.Empty);
        }

        public void OnVolumeChanged(object? sender, ValueEventArgs<StereoVolume> e)
        {
            switch (Channel)
            {
                case AudioChannel.Stereo:
                    VolumeLevel = (e.Value.LeftVolume + e.Value.RightVolume) / 2;
                    break;
                case AudioChannel.LeftChannel:
                    VolumeLevel = e.Value.LeftVolume;
                    break;
                case AudioChannel.RightChannel:
                    VolumeLevel = e.Value.RightVolume;
                    break;
                default:
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.DrawRectangle(Pens.Black, 0, 0, base.Width - 1, base.Height - 1);

            //double num = 20.0 * Math.Log10(VolumeLevel);
            double num = VolumeLevel;

            double num2 = (num - (double)MinDb) / (double)(MaxDb - MinDb);
            int num3 = base.Width - 2;
            int num4 = base.Height - 2;

            // Define gradient colors
            Color[] gradientColors = { Color.DarkGreen, Color.Green, Color.Green, Color.Lime, Color.Yellow, Color.Orange, Color.Red };

            if (Orientation == Orientation.Horizontal)
            {

                // Create brush with gradient
                LinearGradientBrush foregroundBrush = new LinearGradientBrush(new Rectangle(1, 1, num3, num4), Color.Black, Color.Black, LinearGradientMode.Horizontal);
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = new float[] { 0.0f, 0.05f, 0.1f, 0.6f, 0.9f, 0.95f, 1.0f };
                colorBlend.Colors = gradientColors;
                foregroundBrush.InterpolationColors = colorBlend;

                // Fill only a percentage of the rectangle with brush
                pe.Graphics.FillRectangle(foregroundBrush, 1, 1, num3, num4);

                pe.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), (num3 * (float)num2) + 1, 1, num3 - (num3 * (float)num2), num4);
            }
            else
            {
                // Flip gradient colors for vertical orientation
                Array.Reverse(gradientColors);

                // Create brush with gradient
                LinearGradientBrush foregroundBrush = new LinearGradientBrush(new Rectangle(1, 1, num3, num4), Color.Black, Color.Black, LinearGradientMode.Vertical);
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = new float[] { 0.0f, 0.1f, 0.15f, 0.4f, 0.9f, 0.95f, 1.0f };
                colorBlend.Colors = gradientColors;
                foregroundBrush.InterpolationColors = colorBlend;

                // Fill only a percentage of the rectangle with brush
                pe.Graphics.FillRectangle(foregroundBrush, 1, 1, num3, num4);

                pe.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), 1, 1, num3, num4 - (num4 * (float)num2));
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }
    }
}
