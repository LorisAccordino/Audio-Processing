using AudioProcessing.Events;
using System.ComponentModel;

namespace AudioProcessing.GUI
{
    public enum PrecisionScale
    {
        Linear,
        Logarithmic,
        Exponential
    }

    public class PrecisionSlider : PrecisionControl
    {
        private TrackBar trackBar;
        private Label descriptionLabel;
        private Label valueLabel;

        private bool isUpdatingValue = false;

        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return trackBar.Orientation; }
            set 
            { 
                trackBar.Orientation = value;

                if (value == Orientation.Horizontal)
                {
                    Height = 56;
                    Width = 300;
                }
                else
                {
                    Width = 56;
                    Height = 300;
                }

                AdjustControls();
            }
        }

        public int TickFrequency 
        { 
            get { return trackBar.TickFrequency; }
            set { trackBar.TickFrequency = value; }
        }

        [DefaultValue("Value: ")]
        public override string Text
        {
            get { return descriptionLabel.Text; }
            set
            {
                descriptionLabel.Text = value;
                AdjustControls();
            }
        }


        private float precision = 0.01f;
        [DefaultValue(0.01f)]
        public float Precision
        {
            get { return precision; }
            set
            {
                precision = value;
                UpdateTrackBarRange();
            }
        }

        private PrecisionScale precisionScale;
        public PrecisionScale PrecisionScale
        {
            get { return precisionScale; }
            set { precisionScale = value; }
        }

        private float minimum;
        [DefaultValue(0)]
        public float Minimum 
        { 
            get { return minimum; } 
            set 
            {
                minimum = value;
                UpdateTrackBarRange();
            } 
        }
        private float maximum;
        [DefaultValue(10)]
        public float Maximum
        {
            get { return maximum; }
            set
            {
                maximum = value;
                UpdateTrackBarRange();
            }
        }

        private double internalValue;
        [DefaultValue(2.5)]
        public double Value
        {
            get { return internalValue; }
            set
            {
                if (!isUpdatingValue)
                {
                    isUpdatingValue = true;

                    // Set the new internal value
                    internalValue = Math.Clamp(value, Minimum, Maximum);

                    // Normalize the value to the TrackBar scale
                    int normalizedValue = CalculateTrackBarValue(internalValue);

                    // Make sure the value is within the range of the TrackBar
                    normalizedValue = Math.Clamp(normalizedValue, trackBar.Minimum, trackBar.Maximum);

                    // Sets the normalized value without triggering the TrackBar event
                    trackBar.Value = normalizedValue;

                    // Raise event
                    OnValueChanged(new ValueEventArgs<double>(internalValue));

                    // Update the value label
                    UpdateValueLabel();

                    isUpdatingValue = false;
                }
            }
        }

        private int CalculateTrackBarValue(double value)
        {
            switch (PrecisionScale)
            {
                case PrecisionScale.Logarithmic:
                    return (int)MapLogToLinear(value, Minimum, Maximum);
                case PrecisionScale.Exponential:
                    return (int)MapExpToLinear(value, Minimum, Maximum);
                default:
                    return (int)(value / Precision);
            }
        }

        private double CalculateInternalValue(int trackBarValue)
        {
            switch (PrecisionScale)
            {
                case PrecisionScale.Logarithmic:
                    return MapLinearToLog(trackBarValue, trackBar.Minimum, trackBar.Maximum);
                case PrecisionScale.Exponential:
                    return MapLinearToExp(trackBarValue, trackBar.Minimum, trackBar.Maximum);
                default:
                    return trackBarValue * Precision;
            }
        }

        private double MapLinearToLog(double originalValue, double min, double max)
        {
            double normalizedValue = NormalizeValue(originalValue, min, max, 1, 10);
            double log = Math.Log10(normalizedValue);
            return NormalizeValue(log, 0, 1, min * Precision, max * Precision);
        }

        private double MapLinearToExp(double originalValue, double min, double max)
        {
            double normalizedValue = NormalizeValue(originalValue, min, max, 0, 1);
            double pow = Math.Pow(10, normalizedValue);
            return NormalizeValue(pow, 1, 10, min * Precision, max * Precision);
        }

        private double MapExpToLinear(double normalizedValue, double minOriginal, double maxOriginal)
        {
            double value = NormalizeValue(normalizedValue, minOriginal, maxOriginal, 1, 10);
            double log = Math.Log10(value);
            return NormalizeValue(log, 0, 1, minOriginal / Precision, maxOriginal / Precision);
        }

        private double MapLogToLinear(double normalizedValue, double minOriginal, double maxOriginal)
        {
            double value = NormalizeValue(normalizedValue, minOriginal, maxOriginal, 0, 1);
            double pow = Math.Pow(10, value);
            return NormalizeValue(pow, 1, 10, minOriginal / Precision, maxOriginal / Precision);
        }

        private double NormalizeValue(double originalValue, double minOriginal, double maxOriginal, double minNew, double maxNew)
        {
            double normalizedValue = (originalValue - minOriginal) / (maxOriginal - minOriginal);
            return normalizedValue * (maxNew - minNew) + minNew;
        }

        private void UpdateTrackBarRange()
        {
            // Set up TrackBar range based on the precision
            trackBar.Minimum = (int)(Minimum / precision);
            trackBar.Maximum = (int)(Maximum / precision);
        }

        private string valueSuffix;
        public string ValueSuffix { 
            get 
            { 
                return valueSuffix;
            } 
            set 
            {
                valueSuffix = value;
                UpdateValueLabel();
                AdjustControls(); 
            } 
        }

        public PrecisionSlider()
        {
            // Initialize controls
            trackBar = new TrackBar();
            descriptionLabel = new Label();
            valueLabel = new Label();

            descriptionLabel.AutoSize = true;
            valueLabel.AutoSize = true;

            // Initializes the component properties and styles
            Orientation = Orientation.Horizontal;

            // Add events
            trackBar.ValueChanged += (sender, e) => {
                if (!isUpdatingValue)
                {
                    isUpdatingValue = true;

                    // Calculate the new internal value based on the TrackBar value
                    double newValue = CalculateInternalValue(trackBar.Value);

                    // Make sure the new value is in the correct range
                    newValue = Math.Clamp(newValue, Minimum, Maximum);

                    // Set new internal value (without triggering TrackBar event)
                    internalValue = newValue;

                    // Update the value label
                    UpdateValueLabel();

                    // Raise event
                    OnValueChanged(new ValueEventArgs<double>(newValue));

                    isUpdatingValue = false;
                }
            };
            Resize += (sender, e) => AdjustControls();

            // Reset properties
            Precision = 0.01f;
            Minimum = 0.0f;
            Maximum = 10f;
            Value = 2.5f;
            Text = "Value: ";
            valueSuffix = "";

            // Add controls to the PrecisionSlider component
            Controls.Add(trackBar);
            trackBar.Left = 50;
            Controls.Add(descriptionLabel);
            Controls.Add(valueLabel);

            // Update controls
            AdjustControls();
            UpdateValueLabel();

            OnValueChanged(new ValueEventArgs<double>(Value));
        }

        private void UpdateValueLabel()
        {
            valueLabel.Text = $"{Value:F2}{ValueSuffix}";
        }

        private void AdjustControls()
        {
            if (Orientation == Orientation.Horizontal)
            {
                // Update precision range
                UpdateTrackBarRange();

                // Adjust trackbar
                trackBar.Left = descriptionLabel.Width;
                trackBar.Width = Width - (descriptionLabel.Width + MaxValueLabelWidth());

                // Adjust labels
                descriptionLabel.Location = new Point(0, 0);
                valueLabel.Location = new Point(descriptionLabel.Width + trackBar.Width, 0);
            }
            else
            {
                // Update precision range
                UpdateTrackBarRange();

                // Adjust labels
                descriptionLabel.Visible = false;
                valueLabel.Location = new Point(0, Height - valueLabel.Height);

                // Adjust trackbar
                trackBar.Location = new Point(0, 0);
                trackBar.Height = Height - valueLabel.Height;
            }            
        }

        private int MaxValueLabelWidth()
        {
            // Max value
            valueLabel.Text = $"{Maximum:F2}{ValueSuffix}";
            int max = valueLabel.Width;

            // Min value
            valueLabel.Text = $"{Minimum:F2}{ValueSuffix}";
            int min = valueLabel.Width;

            // Reset value label text
            valueLabel.Text = $"{Value:F2}{ValueSuffix}";

            return Math.Max(min, max);
        }
    }
}