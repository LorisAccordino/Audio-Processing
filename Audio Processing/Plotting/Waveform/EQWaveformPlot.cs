using AudioProcessing.Audio.DSP;
using NAudio.Wave;
using ScottPlot.WinForms;

namespace AudioProcessing.Plotting.Waveform
{
    public class EQWaveformPlot : WaveformPlot
    {
        private Equalizer EQ;
        private EqualizerBand[] bands;

        public EQWaveformPlot(FormsPlot formsPlot, string title, EqualizerBand[] bands, Mixer.AudioChannel channel) : base(formsPlot, title, channel)
        {
            this.bands = bands;
        }

        public void InitEQ(ISampleProvider sourceProvider)
        {
            EQ = new Equalizer(sourceProvider, bands);
            EQ.Update();
        }

        public new void Update(float[] floatBuffer)
        {
            float[] eqBuffer = new float[floatBuffer.Length];
            Array.Copy(floatBuffer, eqBuffer, floatBuffer.Length);
            EQ.ApplyToBuffer(eqBuffer);
            base.Update(eqBuffer);
        }
    }
}
