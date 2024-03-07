namespace AudioProcessing.Plotting.Waveform.Strategy
{
    public class LeftChannelWaveformPlotStrategy : IWaveformPlotStrategy
    {
        public void UpdatePlot(float[] floatBuffer, WaveformPlot plot)
        {
            for (int i = 0; i < floatBuffer.Length; i += 2)
            {
                // Add even values to left channel
                plot.AddPoint(floatBuffer[i]);
            }
        }
    }
}