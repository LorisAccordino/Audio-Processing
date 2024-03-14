using AudioProcessing.Plotting.Waveform.Strategy;
using AudioProcessing.Audio;
using AudioProcessing.Events;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using System.Diagnostics;
using AudioProcessing.Common;

namespace AudioProcessing.Plotting.Waveform
{
    public class WaveformPlot : IWaveformPlot
    {
        // Readonly properties
        public readonly FormsPlot formsPlot;
        public readonly DataStreamer wavePlot;
        public readonly Control? parentControl;

        // Timing
        private Stopwatch frameTimer = new Stopwatch();

        private IWaveformPlotStrategy channelStrategy;


        // Zoom
        private float zoomMultiplier = 1;
        private bool zoomFlag = false;
        private float waveformZoom = 1;
        public float Zoom
        {
            get
            {
                return waveformZoom;
            }
            set
            {
                waveformZoom = value;
                if (!zoomFlag)
                {
                    zoomFlag = true;
                    OnZoomChanged(this, new ValueEventArgs<float>(value));
                    zoomFlag = false;
                }
            }
        }

        public bool RefreshRequested { get; set; } = true;

        public WaveformPlot(FormsPlot plot, string title, AudioChannel channel)
        {
            // Check version
            ScottPlot.Version.ShouldBe(5, 0, 21);

            // Set parent control
            parentControl = plot.Parent;

            // Set formsPlot
            formsPlot = plot;      
            formsPlot.Interaction.Disable();
            formsPlot.Plot.HideGrid();
            formsPlot.Plot.Title(title);
            formsPlot.Plot.Axes.SetLimitsY(-1, 1);

            // Set waveform plot
            wavePlot = formsPlot.Plot.Add.DataStreamer(AudioProcessor.SAMPLE_RATE);
            formsPlot.Plot.Axes.SetLimitsX(0, AudioProcessor.SAMPLE_RATE);
            wavePlot.ViewScrollLeft();
            wavePlot.ManageAxisLimits = false;

            // Zoom settings
            zoomMultiplier = AudioProcessor.SAMPLE_RATE / (AudioProcessor.CHUNK_SIZE * 100f);
            Zoom = 1;

            // Assign the correct channel to the plot
            AssignChannel(channel);

            // Start the frame timer
            frameTimer.Start();
        }

        private void AssignChannel(AudioChannel channel)
        {
            switch (channel)
            {
                case AudioChannel.Stereo:
                    channelStrategy = new StereoWaveformPlotStrategy();
                    break;
                case AudioChannel.LeftChannel:
                    channelStrategy = new LeftChannelWaveformPlotStrategy();
                    break;
                case AudioChannel.RightChannel:
                    channelStrategy = new RightChannelWaveformPlotStrategy();
                    break;
                default:
                    break;
            }
        }

        public void AddPoint(double y)
        {
            wavePlot.Add(y);
        }

        public void Update(float[] floatBuffer)
        {
            channelStrategy.UpdatePlot(floatBuffer, this);

            if (frameTimer.ElapsedMilliseconds < 1000f / AudioProcessor.TARGET_FPS)
            {
                return;
            }

            frameTimer.Restart();

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

            formsPlot.Invoke((MethodInvoker)delegate
            {
                formsPlot.Refresh();
            });
        }

        public void OnZoomChanged(object? sender, ValueEventArgs<float> e)
        {
            if (!zoomFlag)
            {
                zoomFlag = true;
                Zoom = e.Value;
                zoomFlag = false;
            }
            formsPlot.Plot.Axes.SetLimitsX(AudioProcessor.SAMPLE_RATE - (AudioProcessor.CHUNK_SIZE * (Zoom * zoomMultiplier)), AudioProcessor.SAMPLE_RATE);
        }
    }
}
