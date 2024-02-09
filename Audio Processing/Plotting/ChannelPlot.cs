using NAudio.Wave;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting
{
    public class ChannelPlot
    {
        private DataLogger waveformPlot;
        public FormsPlot FormsPlot { get; private set; }
        public Control ParentControl { get; private set; }

        // Timing
        private readonly System.Windows.Forms.Timer UpdatePlotTimer = new() { Interval = 10, Enabled = true };


        // Zoom
        private float waveformZoom = 1.0f;
        public float Zoom
        {
            get
            {
                return waveformZoom;
            }
            set
            {
                waveformZoom = value;
                waveformPlot.ViewSlide(waveformZoom * 1000f);
            }
        }
        public bool RefreshRequested { get; set; } = true;

        public ChannelPlot(FormsPlot formsPlot, string title)
        {
            FormsPlot = formsPlot;
            ParentControl = formsPlot.Parent;

            // Initialize plot
            InitializeWaveformPlot(title);

            // Setup a timer to request a render periodically
            UpdatePlotTimer.Tick += (s, e) =>
            {
                if (waveformPlot.HasNewData)
                {
                    //formsPlot.Plot.Title("Processed points: " + waveformPlot.Data.CountTotal + " / " + (waveformPlot.Data.Coordinates.Count - (int)(Zoom * 1000f) * 2) + " / " + (int)(Zoom * 1000f * 2) + " / " + (waveformPlot.Data.CountTotal / AudioProcessor.SAMPLE_RATE));

                    if (waveformPlot.Data.CountTotal > Zoom * 1000)
                    {
                        waveformPlot.Data.Coordinates.RemoveRange(0, waveformPlot.Data.Coordinates.Count - (int)(Zoom * 1000));
                    }


                }
            };
        }

        private void InitializeWaveformPlot(string title)
        {
            ScottPlot.Version.ShouldBe(5, 0, 21);

            FormsPlot.Interaction.Disable();
            FormsPlot.Plot.HideGrid();
            FormsPlot.Plot.Title(title);
            FormsPlot.Plot.Axes.SetLimitsY(-1, 1);

            // Set waveform plot
            waveformPlot = FormsPlot.Plot.Add.DataLogger();
            waveformPlot.ManageAxisLimits = false;
            Zoom = 1.0f;
        }

        public void AddPoint(double x, double y)
        {
            waveformPlot.Add(x, y);
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
