using AudioProcessing.Plotting.Waveform.Strategy;
using AudioProcessing.Audio;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using ScottPlot.Plottables;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting.Waveform
{
    public class WaveformPlot : IWaveformPlot
    {
        public FormsPlot FormsPlot { get; private set; }
        public DataStreamer WavePlot { get; private set; }
        public Control ParentControl { get; private set; }


        private IWaveformPlotStrategy channelStrategy;


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

        public WaveformPlot(FormsPlot formsPlot, string title, Mixer.AudioChannel channel)
        {
            FormsPlot = formsPlot;
            ParentControl = formsPlot.Parent;

            // Assign the correct channel to the plot
            AssignChannel(channel);

            // Initialize plot
            InitializeWaveformPlot(title);
        }

        private void AssignChannel(Mixer.AudioChannel channel)
        {
            switch (channel)
            {
                case Mixer.AudioChannel.STEREO:
                    channelStrategy = new StereoWaveformPlotStrategy();
                    break;
                case Mixer.AudioChannel.LEFT_CHANNEL:
                    channelStrategy = new LeftChannelWaveformPlotStrategy();
                    break;
                case Mixer.AudioChannel.RIGHT_CHANNEL:
                    channelStrategy = new RightChannelWaveformPlotStrategy();
                    break;
                default:
                    break;
            }
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
            WavePlot = FormsPlot.Plot.Add.DataStreamer(AudioProcessor.CHUNK_SIZE);
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

        public void Update(float[] floatBuffer)
        {
            channelStrategy.UpdatePlot(floatBuffer, this);

            // Refresh plots
            RefreshPlot();
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

        public void OnZoomChanged(object? sender, ValueChangedEventArgs e)
        {
            Zoom = (int)e.NewValue;
        }
    }
}
