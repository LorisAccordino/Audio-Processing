using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class WaveformPlotter
    {
        // Plots
        private ChannelPlot stereoChannelPlot;
        private ChannelPlot leftChannelPlot;
        private ChannelPlot rightChannelPlot;


        private float waveformZoom;
        public float Zoom
        {
            get
            {
                return waveformZoom;
            }
            set
            {
                waveformZoom = value;
                stereoChannelPlot.Zoom = value;
                leftChannelPlot.Zoom = value;
                rightChannelPlot.Zoom = value;
            }
        }

        private int currentSample = 0;

        public WaveformPlotter(FormsPlot stereoPlot, FormsPlot leftPlot, FormsPlot rightPlot)
        {
            stereoChannelPlot = new ChannelPlot(stereoPlot, "Waveform (Stereo)");
            leftChannelPlot = new ChannelPlot(leftPlot, "Left Channel");
            rightChannelPlot = new ChannelPlot(rightPlot, "Right Channel");
        }

        public void UpdateCurrentPlotTab(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage currentPage = tabControl.SelectedTab;
            ChannelPlot[] waveformPlots = GetWaveformPlotsAsArray();

            foreach (ChannelPlot waveformPlot in waveformPlots)
            {
                if (waveformPlot.ParentControl == currentPage)
                {
                    waveformPlot.RefreshRequested = true;
                }
                else
                {
                    waveformPlot.RefreshRequested = false;
                }
            }
        }

        public void UpdateWaveformPlots(float[] floatBuffer)
        {
            for (int i = 0; i < floatBuffer.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // Add every point to stereo plot
                    stereoChannelPlot.AddPoint(currentSample, (floatBuffer[i] + floatBuffer[i + 1]) / 2);
                }

                // Add even values to left channel
                if (i % 2 == 0)
                {
                    leftChannelPlot.AddPoint(currentSample, floatBuffer[i]);
                }

                // Add odd values to left channel
                if (i % 2 != 0)
                {
                    rightChannelPlot.AddPoint(currentSample, floatBuffer[i]);
                }

                currentSample++;
            }

            // Refresh plots
            stereoChannelPlot.RefreshPlot();
            leftChannelPlot.RefreshPlot();
            rightChannelPlot.RefreshPlot();
        }

        private ChannelPlot[] GetWaveformPlotsAsArray()
        {
            return [stereoChannelPlot, leftChannelPlot, rightChannelPlot];
        }

    }
}
