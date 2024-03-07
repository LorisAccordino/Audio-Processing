using AudioProcessing.Events;
using NAudio.Gui;
using System.ComponentModel;

namespace AudioProcessing.GUI
{
    public class PrecisionPot : Control
    {
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        private Pot pot;
        private Label descriptionLabel;
        private Label valueLabel;

        private bool isUpdatingValue = false;


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

        private int index = -1;
        public int PotIndex
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }


        [DefaultValue(-1)]
        public double Minimum
        {
            get { return pot.Minimum; }
            set
            {
                pot.Minimum = value;
            }
        }

        [DefaultValue(1)]
        public double Maximum
        {
            get { return pot.Maximum; }
            set
            {
                pot.Maximum = value;
            }
        }

        [DefaultValue(0)]
        public double Value
        {
            get { return pot.Value; }
            set
            {
                if (!isUpdatingValue)
                {
                    isUpdatingValue = true;

                    pot.Value = value;
                    UpdateValueLabel();

                    isUpdatingValue = false;
                }
            }
        }

        private string valueSuffix;
        public string ValueSuffix
        {
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

        public bool ShowValue
        {
            get
            {
                return valueLabel.Visible;
            }
            set
            {
                valueLabel.Visible = value;
            }
        }

        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        public PrecisionPot()
        {
            // Initialize controls
            pot = new Pot();
            descriptionLabel = new Label();
            valueLabel = new Label();

            descriptionLabel.AutoSize = true;
            valueLabel.AutoSize = true;

            // Add events
            pot.ValueChanged += (sender, e) =>
            {
                if (!isUpdatingValue)
                {
                    isUpdatingValue = true;

                    // Update pot value
                    Value = pot.Value;

                    // Update the value label
                    UpdateValueLabel();

                    // Raise event
                    OnValueChanged(new ValueChangedEventArgs((float)Value));

                    isUpdatingValue = false;
                }
            };
            Resize += (sender, e) => AdjustControls();

            // Reset properties
            Minimum = -1.0f;
            Value = 0.0f;
            Maximum = 1.0f;
            Text = "Value: ";
            PotIndex = -1;

            Width = 65;
            Height = 95;

            pot.Width = 54;
            pot.Height = 61;

            // Add controls to the PrecisionPot component
            Controls.Add(pot);
            Controls.Add(descriptionLabel);
            Controls.Add(valueLabel);

            // Update controls
            AdjustControls();
            UpdateValueLabel();

            OnValueChanged(new ValueChangedEventArgs((float)Value));
        }

        private void UpdateValueLabel()
        {
            valueLabel.Text = $"{Value:F1}{ValueSuffix}";
        }

        private void AdjustControls()
        {
            int valueLabelHeight = ShowValue ? valueLabel.Height : 0;

            // Center the pot
            pot.Location = new Point((Width - pot.Width) / 2, (Height - pot.Height + descriptionLabel.Height - valueLabelHeight) / 2);

            // Position the descriptionLabel above the pot
            descriptionLabel.Location = new Point((Width - descriptionLabel.Width) / 2, pot.Top - descriptionLabel.Height);

            // Position the value below the pot
            valueLabel.Location = new Point((Width - valueLabel.Width) / 2, pot.Bottom - 5);
        }
    }
}