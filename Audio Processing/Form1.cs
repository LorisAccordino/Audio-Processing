using AudioProcessing.Audio;
using AudioProcessing.Plotting;
using NAudio.Wave;
using System.Formats.Tar;

namespace AudioProcessing
{
    public partial class Form1 : Form
    {
        // Audio processor
        private AudioProcessor audioProcessor;

        // Plotters
        private WaveformPlotter waveformPlotter;
        private FFTPlotter fftPlotter;

        public Form1()
        {
            // Initialize stuff
            InitializeComponent();

            // Initialize plotters
            waveformPlotter = new WaveformPlotter(waveformPlot, leftWaveformPlot, rightWaveformPlot);
            waveformPlotter.AddEQplots(lowEQplot, midEQplot, highEQplot);

            fftPlotter = new FFTPlotter(spectrumPlot, 44100);
            fftPlotter.AddTuner(toneLabel);
        }

        private void AddEventHandlers()
        {
            tabControl.SelectedIndexChanged += waveformPlotter.UpdateCurrentPlotTab;

            speedSlider.ValueChanged += audioProcessor.PlaybackManager.SpeedChanged;
            pitchSlider.ValueChanged += audioProcessor.PlaybackManager.PitchChanged;
            timeSlider.ValueChanged += audioProcessor.PlaybackManager.TimeChanged;
            timeSlider.ValueChanged += (sender, e) =>
            {
                speedSlider.Value = audioProcessor.PlaybackManager.PlaybackSpeed;
                pitchSlider.Value = audioProcessor.PlaybackManager.SMB.PitchFactor * 100;
            };
            zoomSlider.ValueChanged += waveformPlotter.ZoomChanged;

            volumeSlider.ValueChanged += audioProcessor.VuMeter.VolumeChanged;

            fftDbSlider.ValueChanged += fftPlotter.DbLimitsChanged;
            fftHzSlider.ValueChanged += fftPlotter.HzLimitsChanged;

            audioProcessor.PlaybackManager.PlaybackStopped += (sender, e) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    EnablingControls(false);
                });
            };
        }

        public void EnablingControls(bool enabled)
        {
            playbackGroupBox.Enabled = enabled;
            eqGroupBox.Enabled = enabled;
            volumeGroupBox.Enabled = enabled;
            fftLimitsGroupBox.Enabled = enabled;
            tunerGroupBox.Enabled = enabled;
            openToolStripMenuItem.Enabled = !enabled;

            ResetComponents();
        }

        public void ResetComponents()
        {
            zoomSlider.Value = 1;
            speedSlider.Value = 1;
            pitchSlider.Value = 100;
            timeSlider.Value = 1;
            volumeSlider.Value = 0;

            isStereoCheckbox.Checked = true;

            panPot.Value = 0;
            lowPot.Value = 0;
            midPot.Value = 0;
            highPot.Value = 0;

            leftVolumeMeter.VolumeLevel = -40;
            rightVolumeMeter.VolumeLevel = -40;

            waveformPlotter.ClearAll();
            fftPlotter.Clear();
        }

        private void InitializeAudio(string wavFile)
        {
            // Initialize audio processor
            audioProcessor = new AudioProcessor(new AudioFileReader(wavFile), new WaveFileReader(wavFile));
            audioProcessor.AddVuMeter(leftVolumeMeter, rightVolumeMeter);
            audioProcessor.AddPlotters(waveformPlotter, fftPlotter);
            audioProcessor.PlaybackManager.AddTimeElapsedLabel(timeElapsedLabel);

            // Init waveform EQ with SMB
            waveformPlotter.InitEQ(audioProcessor.PlaybackManager.SMB);

            // Perform click on start button
            playButton.PerformClick();

            // Start audio processor
            audioProcessor.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnablingControls(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioProcessor.Close();
        }

        private void lowPot_ValueChanged(object sender, EventArgs e)
        {
            float[] gains = audioProcessor.Mixer.GetGains();
            float newGain = (float)lowPot.Value * 12.0f;
            audioProcessor.Mixer.UpdateGains(newGain, gains[1], gains[2]);
            lowLabel.Text = newGain + " dB";
        }

        private void midPot_ValueChanged(object sender, EventArgs e)
        {
            float[] gains = audioProcessor.Mixer.GetGains();
            float newGain = (float)midPot.Value * 12.0f;
            audioProcessor.Mixer.UpdateGains(gains[0], newGain, gains[2]);
            midLabel.Text = newGain + " dB";
        }

        private void highPot_ValueChanged(object sender, EventArgs e)
        {
            float[] gains = audioProcessor.Mixer.GetGains();
            float newGain = (float)highPot.Value * 12.0f;
            audioProcessor.Mixer.UpdateGains(gains[0], gains[1], newGain);
            highLabel.Text = newGain + " dB";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (audioOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Enabling controls
                EnablingControls(true);

                // Initialize audio
                InitializeAudio(audioOpenFileDialog.FileName);

                // Handle events
                AddEventHandlers();

                playButton.Enabled = true;
                stopButton.Enabled = true;
                openToolStripMenuItem.Enabled = false;
            }
        }

        private void profileMicrophoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Enabling controls
            EnablingControls(true);

            // Initialize audio processor
            audioProcessor = new AudioProcessor();
            audioProcessor.AddVuMeter(leftVolumeMeter, rightVolumeMeter);
            audioProcessor.AddPlotters(waveformPlotter, fftPlotter);
            //audioProcessor.PlaybackManager.AddTimeElapsedLabel(timeElapsedLabel);

            // Init waveform EQ with SMB
            //waveformPlotter.InitEQ(audioProcessor.PlaybackManager.SMB);

            // Perform click on start button
            //playButton.PerformClick();

            audioProcessor.StartProfiling();

            // Handle events
            //AddEventHandlers();

            playButton.Enabled = true;
            stopButton.Enabled = true;
            openToolStripMenuItem.Enabled = false;
        }

        private void panPot_ValueChanged(object sender, EventArgs e)
        {
            float pan = (float)panPot.Value;
            audioProcessor.VuMeter.Pan = pan;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            audioProcessor.PlaybackManager.TogglePlaybackState();

            // Update play/pause icon
            playButton.Text = audioProcessor.PlaybackManager.IsPaused() ? "⏵" : "⏸";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop playback
            audioProcessor.PlaybackManager.StopPlayback();
        }

        private void isStereoCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            audioProcessor.VuMeter.IsStereo = isStereoCheckbox.Checked;
        }
    }
}
