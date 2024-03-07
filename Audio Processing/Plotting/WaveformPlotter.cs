using AudioProcessing.Plotting.Waveform;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using NAudio.Wave;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class WaveformPlotter
    {
        // Plots
        /*private List<WaveformPlot> waveformPlots = new List<WaveformPlot>();
        private List<EQWaveformPlot> EQplots = new List<EQWaveformPlot>();*/

        private List<IWaveformPlot> plots = new List<IWaveformPlot>();


        public event EventHandler<ValueChangedEventArgs> ZoomChanged;
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
                OnZoomChanged(new ValueChangedEventArgs(value));
            }
        }

        public WaveformPlotter()
        {

        }

        public void AddWaveformPlot(FormsPlot plot, string title, Mixer.AudioChannel channel)
        {
            AddPlot(new WaveformPlot(plot, title, channel));
        }

        public void AddEQWaveformPlot(FormsPlot plot, string title, EqualizerBand[] bands)
        {
            AddEQWaveformPlot(plot, title, bands, Mixer.AudioChannel.STEREO);
        }

        public void AddEQWaveformPlot(FormsPlot plot, string title, EqualizerBand[] bands, Mixer.AudioChannel channel)
        {
           AddPlot(new EQWaveformPlot(plot, title, bands, channel));     
        }

        private void AddPlot(IWaveformPlot plot)
        {
            ZoomChanged += plot.OnZoomChanged;
            plots.Add(plot);
        }

        public void InitEQs(ISampleProvider sourceProvider)
        {
            foreach (IWaveformPlot plot in plots)
            {
                if (plot is EQWaveformPlot EQplot)
                {
                    EQplot.InitEQ(sourceProvider);
                }
            }
        }

        public void UpdateCurrentPlotTab(object? sender, EventArgs e)
        {
            if (sender is TabControl tabControl)
            {
                TabPage? currentPage = tabControl.SelectedTab;
                foreach (WaveformPlot plot in plots)
                {
                    if (plot.ParentControl == currentPage)
                    {
                        plot.RefreshRequested = true;
                    }
                    else
                    {
                        plot.RefreshRequested = false;
                    }
                }
            }
        }

        public void UpdateWaveformPlots(float[] floatBuffer)
        {
            foreach (IWaveformPlot plot in plots)
            {
                if (plot is EQWaveformPlot EQplot)
                {
                    EQplot.Update(floatBuffer);
                }
                else
                {
                    plot.Update(floatBuffer);
                }
            }
        }

        public void ClearAll()
        {
            foreach(WaveformPlot plot in plots)
            {
                plot.WavePlot.Clear();
                plot.FormsPlot.Refresh();
            }
        }

        protected virtual void OnZoomChanged(ValueChangedEventArgs e)
        {
            ZoomChanged?.Invoke(this, e);
        }
    }
}
