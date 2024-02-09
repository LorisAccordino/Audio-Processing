using AudioProcessing.Audio;
using AudioProcessing.Plotting;
using NAudio.Wave;

namespace AudioProcessing
{
    public partial class Form1 : Form
    {
        // Audio processor
        private AudioProcessor audioProcessor;

        // Plot manager
        private WaveformPlotter waveformPlotter;
        private SpectrumPlotter spectrumPlotter;

        public Form1()
        {
            // Initialize stuff
            InitializeComponent();

            // Initialize plotters
            waveformPlotter = new WaveformPlotter(waveformPlot, leftWaveformPlot, rightWaveformPlot);
            spectrumPlotter = new SpectrumPlotter(spectrumPlot, 44100);

            // Handle events
            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            tabControl.SelectedIndexChanged += waveformPlotter.UpdateCurrentPlotTab;
        }

        private void InitializeAudio(string wavFilePath)
        {
            // Initialize audio processor
            audioProcessor = new AudioProcessor(new AudioFileReader(wavFilePath), new WaveFileReader(wavFilePath), Mixer.LOW_MID_HIGH, waveformPlotter, spectrumPlotter);
            audioProcessor.InitVuMeter(leftVolumeMeter, rightVolumeMeter);
        }

        private void zoomSlider_ValueChanged(object sender, EventArgs e)
        {
            float zoom = zoomSlider.Value;
            zoom = (float)(Math.Pow(zoom / 10, 2));
            zoomLabel.Text = zoom + " x";

            waveformPlotter.Zoom = zoom;
        }

        private void speedSlider_ValueChanged(object sender, EventArgs e)
        {
            float speed = speedSlider.Value / 100.0f;
            audioProcessor.SpeedMultiplier = speed;
            speedLabel.Text = speed + "x";
        }

        private void pitchSlider_ValueChanged(object sender, EventArgs e)
        {
            float pitch = pitchSlider.Value / 100f;
            audioProcessor.PitchFactor = pitch;
            pitchLabel.Text = (int)((pitch * 100) - 100) + "%";
        }



        private void volumeFader_ValueChanged(object sender, EventArgs e)
        {
            float volume = volumeFader.Value / 1000.0f;
            audioProcessor.Volume = volume;
            int logVolume = (int)audioProcessor.VuMeter.LinearVolumeToLogVolume(volume, VuMeter.MIN_DECIBEL);
            volumeLabel.Text = logVolume + " dB";
        }

        private void tempoSlider_ValueChanged(object sender, EventArgs e)
        {
            float tempo = tempoSlider.Value / 100f;
            audioProcessor.SpeedMultiplier = tempo;
            speedSlider.Value = (int)(audioProcessor.SpeedMultiplier * 100f);
            audioProcessor.SMB.PitchFactor = 1 / audioProcessor.SpeedMultiplier;
            pitchSlider.Value = (int)(audioProcessor.SMB.PitchFactor * 100f);
            tempoLabel.Text = tempo + "x";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioProcessor.Close();
        }

        private void lowPot_ValueChanged(object sender, EventArgs e)
        {
            float newGain = (float)lowPot.Value * 100.0f;
            audioProcessor.Bands[0].Gain = newGain;
            audioProcessor.EQ.Update();
            lowLabel.Text = newGain + " dB";
        }

        private void midPot_ValueChanged(object sender, EventArgs e)
        {
            float newGain = (float)midPot.Value * 100.0f;
            audioProcessor.Bands[1].Gain = newGain;
            audioProcessor.EQ.Update();
            midLabel.Text = newGain + " dB";
        }

        private void highPot_ValueChanged(object sender, EventArgs e)
        {
            float newGain = (float)highPot.Value * 100.0f;
            audioProcessor.Bands[2].Gain = newGain;
            audioProcessor.EQ.Update();
            highLabel.Text = newGain + " dB";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (audioOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = audioOpenFileDialog.FileName;

                // Initialize audio
                InitializeAudio(filename);
            }
        }

        private void panPot_ValueChanged(object sender, EventArgs e)
        {
            float pan = (float)panPot.Value;
            audioProcessor.Pan = pan;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (audioProcessor.PlaybackState != PlaybackState.Playing)
            {
                // Start audio processor
                audioProcessor.Start();

                // Start playback
                audioProcessor.StartPlayback();

                // Start stopwatch
                //stopwatch.Start();

                // Update pause icon
                playButton.Text = "⏸";

                // Enable plot timer
                //UpdatePlotTimer.Enabled = true;
            }
            else
            {
                audioProcessor.PausePlayback();

                // Pause stopwatch
                //stopwatch.Stop();

                // Update play icon
                playButton.Text = "⏵";

                // Disable plot timer
                //UpdatePlotTimer.Enabled = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop playback
            audioProcessor.StopPlayback();

            // Stop stopwatch
            //stopwatch.Reset();
        }

        private void isStereoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            audioProcessor.IsStereo = isStereoCheckbox.Checked;
        }

        private void fftDbTrackbar_ValueChanged(object sender, EventArgs e)
        {
            spectrumPlotter.MaxDbRange = (fftDbTrackbar.Value - 350) / 10;
            fftDbLabel.Text = spectrumPlotter.MaxDbRange + " dB";
        }

        private void fftHzTrackbar_ValueChanged(object sender, EventArgs e)
        {
            spectrumPlotter.MaxHzRange = fftHzTrackbar.Value * 100;
            fftHzLabel.Text = spectrumPlotter.MaxHzRange + " Hz";
        }
    }
}
