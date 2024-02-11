using AudioProcessing.Audio;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class WaveformPlot
    {
        public FormsPlot FormsPlot { get; private set; }
        public DataStreamer WavePlot { get; private set; }
        public Control ParentControl { get; private set; }

        // Zoom
        private int waveformZoom = 1;
        public int Zoom
        {
            get
            {
                return waveformZoom;
            }
            set
            {
                waveformZoom = value;
            }
        }

        public bool RefreshRequested { get; set; } = true;

        public WaveformPlot(FormsPlot formsPlot, string title)
        {
            FormsPlot = formsPlot;
            ParentControl = formsPlot.Parent;

            // Initialize plot
            InitializeWaveformPlot(title);
        }

        private void InitializeWaveformPlot(string title)
        {
            ScottPlot.Version.ShouldBe(5, 0, 21);

            // Set formsPlot
            FormsPlot.Interaction.Disable();
            FormsPlot.Plot.HideGrid();
            FormsPlot.Plot.Title(title);
            FormsPlot.Plot.Axes.SetLimitsY(-1, 1);

            // Set waveform plot
            WavePlot = FormsPlot.Plot.Add.DataStreamer(AudioProcessor.CHUNK_SIZE, 1);
            FormsPlot.Plot.Axes.SetLimitsX(0, AudioProcessor.CHUNK_SIZE);
            WavePlot.ViewScrollLeft();
            WavePlot.ManageAxisLimits = false;
            Zoom = 1;
        }

        private long counter;

        public void AddPoint(double y)
        {
            if (counter % (waveformZoom * 2) == 0)
            {
                WavePlot.Add(y);
            }
            counter++;
        }

        // Thread safe
        public void RefreshPlot()
        {
            if (!RefreshRequested)
            {
                return;
            }

            FormsPlot.Invoke((MethodInvoker)delegate
            {
                FormsPlot.Refresh();
            });
        }
    }
}
