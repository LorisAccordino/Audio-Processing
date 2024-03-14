using AudioProcessing.Plotting.Waveform;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using NAudio.Wave;
using ScottPlot.WinForms;
using AudioProcessing.Common;

namespace AudioProcessing.Plotting
{
    public class WaveformPlotter
    {
        // Plots
        private List<IWaveformPlot> plots = new List<IWaveformPlot>();

        // Events
        public event EventHandler<ValueEventArgs<float>>? ZoomChanged;

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
                OnZoomChanged(new ValueEventArgs<float>(value));
            }
        }

        public WaveformPlotter()
        {
            //frameTimer.Start();
        }

        public void AddWaveformPlot(FormsPlot plot, string title, AudioChannel channel)
        {
            AddPlot(new WaveformPlot(plot, title, channel));
        }

        public void AddEQWaveformPlot(FormsPlot plot, string title, EqualizerBand[] bands)
        {
            AddEQWaveformPlot(plot, title, bands, AudioChannel.Stereo);
        }

        public void AddEQWaveformPlot(FormsPlot plot, string title, EqualizerBand[] bands, AudioChannel channel)
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
                    if (plot.parentControl == currentPage)
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
                plot.wavePlot.Clear();
                plot.formsPlot.Refresh();
            }
        }

        protected virtual void OnZoomChanged(ValueEventArgs<float> e)
        {
            ZoomChanged?.Invoke(this, e);
        }
    }
}
