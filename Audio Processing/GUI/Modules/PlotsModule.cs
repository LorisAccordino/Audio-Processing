using AudioProcessing.Audio.DSP;
using AudioProcessing.Common;
using AudioProcessing.Plotting;

namespace AudioProcessing.GUI.Modules
{
    public partial class PlotsModule : GenericModule
    {
        public PlotsModule()
        {
            InitializeComponent();

            // Add FFT panel module
            fftPanel.Controls.Add(SingletonManager<FFTModule>.GetInstance());

            // Initialize plotters
            InitializePlotters();
        }

        private void InitializePlotters()
        {
            // Add waveforms
            audioProcessor.WaveformPlotter.AddWaveformPlot(stereoPlot, "Waveform (Stereo)", AudioChannel.Stereo);
            audioProcessor.WaveformPlotter.AddWaveformPlot(leftPlot, "Left Channel", AudioChannel.LeftChannel);
            audioProcessor.WaveformPlotter.AddWaveformPlot(rightPlot, "Right Channel", AudioChannel.RightChannel);

            // Add EQ waveforms
            audioProcessor.WaveformPlotter.AddEQWaveformPlot(lowEQplot, "Low Frequencies", Mixer.ISOLATED_LOW);
            audioProcessor.WaveformPlotter.AddEQWaveformPlot(midEQplot, "Mid Frequencies", Mixer.ISOLATED_MID);
            audioProcessor.WaveformPlotter.AddEQWaveformPlot(highEQplot, "High Frequencies", Mixer.ISOLATED_HIGH);

            // FFT plotter
            audioProcessor.FFTplotter = new FFTPlotter(spectrumPlot);
        }
    }
}
