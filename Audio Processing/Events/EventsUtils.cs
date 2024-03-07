using AudioProcessing.GUI;

namespace AudioProcessing.Events
{
    public class EventsUtils
    {
        private static void ValueChanged(object? sender, EventArgs e)
        {
            switch (sender)
            {
                case PrecisionSlider slider:
                    HandleValueChanged(slider, slider.Value);
                    break;
                case PrecisionPot pot:
                    HandleValueChanged(pot, (float)pot.Value);
                    break;
                case CheckBox checkBox:
                    HandleValueChanged(checkBox, checkBox.Checked);
                    break;
            }
        }

        private static void HandleValueChanged<T>(Control control, T value)
        {
            if (control.Tag is Action<T> updateAction)
            {
                updateAction(value);
            }
        }

        public static void AttachValueChangedEvent(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                switch (control)
                {
                    case PrecisionSlider slider:
                        slider.ValueChanged += ValueChanged;
                        break;
                    case PrecisionPot pot:
                        pot.ValueChanged += ValueChanged;
                        break;
                    case CheckBox checkbox:
                        checkbox.CheckedChanged += ValueChanged;
                        break;
                }

                // If the current control is a container, execute the function recursively
                if (control.HasChildren)
                {
                    AttachValueChangedEvent(control);
                }
            }
        }

        public static void numericUpDown_MouseWheel(object? sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledArgs = (HandledMouseEventArgs)e;
            handledArgs.Handled = true;

            if (sender is NumericUpDown numericUpDown)
            {
                int delta = e.Delta / 120; // 120 is the default value for one notch of the mouse wheel

                if (delta > 0)
                {
                    // Scrolling up
                    numericUpDown.Value = Math.Min(numericUpDown.Maximum, numericUpDown.Value + numericUpDown.Increment);
                }
                else if (delta < 0)
                {
                    // Scrolling down
                    numericUpDown.Value = Math.Max(numericUpDown.Minimum, numericUpDown.Value - numericUpDown.Increment);
                }
            }            
        }
    }
}
