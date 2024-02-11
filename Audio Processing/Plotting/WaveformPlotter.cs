using AudioProcessing.Audio;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class WaveformPlotter
    {
        // Plots
        private WaveformPlot stereoWavePlot;
        private WaveformPlot leftChannelPlot;
        private WaveformPlot rightChannelPlot;

        private WaveformPlot lowEQplot;
        private WaveformPlot midEQplot;
        private WaveformPlot highEQplot;

        // EQs
        private Equalizer lowEQ;
        private Equalizer midEQ;
        private Equalizer highEQ;

        private int waveformZoom;
        public int Zoom
        {
            get
            {
                return waveformZoom;
            }
            set
            {
                waveformZoom = value;
                stereoWavePlot.Zoom = value;
                leftChannelPlot.Zoom = value;
                rightChannelPlot.Zoom = value;
                lowEQplot.Zoom = value;
                midEQplot.Zoom = value;
                highEQplot.Zoom = value;
            }
        }

        public WaveformPlotter(FormsPlot stereoPlot, FormsPlot leftPlot, FormsPlot rightPlot)
        {
            // Plots
            stereoWavePlot = new WaveformPlot(stereoPlot, "Waveform (Stereo)");
            leftChannelPlot = new WaveformPlot(leftPlot, "Left Channel");
            rightChannelPlot = new WaveformPlot(rightPlot, "Right Channel");
        }

        public void InitEQ(SMBPitchShiftingSampleProvider SMB)
        {
            lowEQ = new Equalizer(SMB, Mixer.ISOLATED_LOW);
            lowEQ.Update();

            midEQ = new Equalizer(SMB, Mixer.ISOLATED_MID);
            midEQ.Update();

            highEQ = new Equalizer(SMB, Mixer.ISOLATED_HIGH);
            highEQ.Update();
        }

        //public void InitEQplots(SMBPitchShiftingSampleProvider SMB, FormsPlot lowPlot, FormsPlot midPlot, FormsPlot highPlot)
        public void AddEQplots(FormsPlot lowPlot, FormsPlot midPlot, FormsPlot highPlot)
        {
            // Plots
            lowEQplot = new WaveformPlot(lowPlot, "Low Frequencies");
            midEQplot = new WaveformPlot(midPlot, "Mid Frequencies");
            highEQplot = new WaveformPlot(highPlot, "High Frequencies");

            // Init EQs
            /*lowEQ = new Equalizer(SMB, Mixer.ISOLATED_LOW);
            midEQ = new Equalizer(SMB, Mixer.ISOLATED_MID);
            highEQ = new Equalizer(SMB, Mixer.ISOLATED_HIGH);*/
        }

        public void UpdateCurrentPlotTab(object? sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage currentPage = tabControl.SelectedTab;
            WaveformPlot[] waveformPlots = GetWaveformPlotsAsArray();

            foreach (WaveformPlot waveformPlot in waveformPlots)
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
                    stereoWavePlot.AddPoint((floatBuffer[i] + floatBuffer[i + 1]) / 2);
                }

                // Add even values to left channel
                if (i % 2 == 0)
                {
                    leftChannelPlot.AddPoint(floatBuffer[i]);
                }

                // Add odd values to left channel
                if (i % 2 != 0)
                {
                    rightChannelPlot.AddPoint(floatBuffer[i]);
                }
            }

            // Refresh plots
            stereoWavePlot.RefreshPlot();
            leftChannelPlot.RefreshPlot();
            rightChannelPlot.RefreshPlot();
        }

        public void UpdateEQplots(float[] floatBuffer)
        {
            float[] lowEQbuffer = new float[floatBuffer.Length];
            float[] midEQbuffer = new float[floatBuffer.Length];
            float[] highEQbuffer = new float[floatBuffer.Length];

            Array.Copy(floatBuffer, lowEQbuffer, floatBuffer.Length);
            Array.Copy(floatBuffer, midEQbuffer, floatBuffer.Length);
            Array.Copy(floatBuffer, highEQbuffer, floatBuffer.Length);

            lowEQ.ApplyToBuffer(lowEQbuffer);
            midEQ.ApplyToBuffer(midEQbuffer);
            highEQ.ApplyToBuffer(highEQbuffer);

            for (int i = 0; i < floatBuffer.Length; i++)
            {
                if (i % 2 == 0)
                {
                    lowEQplot.AddPoint((lowEQbuffer[i] + lowEQbuffer[i + 1]) / 2);
                    midEQplot.AddPoint((midEQbuffer[i] + midEQbuffer[i + 1]) / 2);
                    highEQplot.AddPoint((highEQbuffer[i] + highEQbuffer[i + 1]) / 2);
                }
            }

            // Refresh plots
            lowEQplot.RefreshPlot();
            midEQplot.RefreshPlot();
            highEQplot.RefreshPlot();
        }

        public void ClearAll()
        {
            WaveformPlot[] plots = GetWaveformPlotsAsArray();

            foreach(WaveformPlot plot in plots)
            {
                plot.WavePlot.Clear();
                plot.FormsPlot.Refresh();
            }
        }

        private WaveformPlot[] GetWaveformPlotsAsArray()
        {
            return [stereoWavePlot, leftChannelPlot, rightChannelPlot, lowEQplot, midEQplot, highEQplot];
        }

        public void ZoomChanged(object? sender, ValueChangedEventArgs e)
        {
            Zoom = (int)Math.Max(1.0f, e.NewValue);
        }
    }
}
