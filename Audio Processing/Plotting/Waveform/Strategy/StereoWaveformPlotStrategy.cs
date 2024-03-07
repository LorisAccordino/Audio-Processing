namespace AudioProcessing.Plotting.Waveform.Strategy
{
    public class StereoWaveformPlotStrategy : IWaveformPlotStrategy
    {
        public void UpdatePlot(float[] floatBuffer, WaveformPlot plot)
        {
            for (int i = 0; i < floatBuffer.Length; i += 2)
            {
                // Add every point to stereo plot
                plot.AddPoint((floatBuffer[i] + floatBuffer[i + 1]) / 2);
            }
        }
    }
}