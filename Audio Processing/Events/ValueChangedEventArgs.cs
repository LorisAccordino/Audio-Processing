namespace AudioProcessing.Events
{
    public class ValueChangedEventArgs : EventArgs
    {
        public float NewValue { get; }

        public ValueChangedEventArgs(float newValue)
        {
            NewValue = newValue;
        }
    }
}
