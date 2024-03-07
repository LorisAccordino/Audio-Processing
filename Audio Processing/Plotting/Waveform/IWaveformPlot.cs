using AudioProcessing.Events;

namespace AudioProcessing.Plotting.Waveform
{
    public interface IWaveformPlot
    {
        void Update(float[] floatBuffer);
        void OnZoomChanged(object? sender, ValueChangedEventArgs e);
    }
}