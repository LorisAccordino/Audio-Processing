namespace AudioProcessing.Plotting.Waveform.Strategy
{
    public class RightChannelWaveformPlotStrategy : IWaveformPlotStrategy
    {
        public void UpdatePlot(float[] floatBuffer, WaveformPlot plot)
        {
            for (int i = 1; i < floatBuffer.Length; i += 2)
            {
                // Add odd values to right channel
                plot.AddPoint(floatBuffer[i]);
            }
        }
    }
}