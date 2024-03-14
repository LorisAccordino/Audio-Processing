using AudioProcessing.Events;

namespace AudioProcessing.GUI
{
    public class PrecisionControl : Control
    {
        // Events
        public Action<float>? ValueAction { get; set; } // Using float to avoid cast issues
        public event EventHandler<ValueEventArgs<double>>? ValueChanged;

        protected virtual void OnValueChanged(ValueEventArgs<double> e)
        {
            ValueChanged?.Invoke(this, e);

            if (ValueAction != null)
            {
                ValueAction?.Invoke((float)e.Value);
            }   
        }
    }
}
