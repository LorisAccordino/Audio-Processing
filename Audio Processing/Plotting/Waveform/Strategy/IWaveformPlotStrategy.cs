namespace AudioProcessing.Plotting.Waveform.Strategy
{
    public interface IWaveformPlotStrategy
    {
        void UpdatePlot(float[] floatBuffer, WaveformPlot plot);
    }
}