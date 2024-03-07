using AudioProcessing.Audio;
using AudioProcessing.Audio.DSP;
using AudioProcessing.Events;
using AudioProcessing.Plotting;
using NAudio.Wave;
using static AudioProcessing.Audio.SignalFunction;

namespace AudioProcessing
{
    public partial class Form1 : Form
    {
        // Audio processor
        private AudioProcessor audioProcessor;

        // Synthesizer
        private Synthesizer synthesizer;

        // Plotters
        private WaveformPlotter waveformPlotter;
        private FFTPlotter fftPlotter;

        public Form1()
        {
            // Initialize stuff
            InitializeComponent();

            // Initialize plotters
            InitializePlotters();
        }

        private void AddEventHandlers()
        {
            speedSlider.Tag = new Action<float>(value => audioProcessor.PlaybackManager.PlaybackSpeed = value);
            pitchSlider.Tag = new Action<float>(value => audioProcessor.PlaybackManager.PitchFactor = value);
            timeSlider.Tag = new Action<float>(value => audioProcessor.PlaybackManager.TimeStrech = value);
            zoomSlider.Tag = new Action<float>(value => waveformPlotter.Zoom = (int)Math.Max(1.0f, value));
            volumeSlider.Tag = new Action<float>(value => audioProcessor.VuMeter.Volume = VuMeter.LogVolumeToLinearVolume(value));
            fftDbSlider.Tag = new Action<float>(value => fftPlotter.MaxDbRange = value);
            fftHzSlider.Tag = new Action<float>(value => fftPlotter.MaxHzRange = value * 1000);

            panPot.Tag = new Action<float>(value => audioProcessor.VuMeter.Pan = value);
            lowPot.Tag = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, lowPot.PotIndex));
            midPot.Tag = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, midPot.PotIndex));
            highPot.Tag = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, highPot.PotIndex));

            isStereoCheckbox.Tag = new Action<bool>(value => audioProcessor.VuMeter.IsStereo = value);

            EventsUtils.AttachValueChangedEvent(this);

            tabControl.SelectedIndexChanged += waveformPlotter.UpdateCurrentPlotTab;

            timeSlider.ValueChanged += (sender, e) =>
            {
                speedSlider.Value = audioProcessor.PlaybackManager.PlaybackSpeed;
                pitchSlider.Value = audioProcessor.PlaybackManager.SMB.PitchFactor;
            };

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
            wavTSMI.Enabled = !enabled;

            ResetComponents();
        }

        public void ResetComponents()
        {
            tabControl.SelectedIndex = 0;

            zoomSlider.Value = 1;
            speedSlider.Value = 1;
            pitchSlider.Value = 1;
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

        private void InitializePlotters()
        {
            // Waveform plotter
            waveformPlotter = new WaveformPlotter();

            // Add waveforms
            waveformPlotter.AddWaveformPlot(stereoPlot, "Waveform (Stereo)", Mixer.AudioChannel.STEREO);
            waveformPlotter.AddWaveformPlot(leftPlot, "Left Channel", Mixer.AudioChannel.LEFT_CHANNEL);
            waveformPlotter.AddWaveformPlot(rightPlot, "Right Channel", Mixer.AudioChannel.RIGHT_CHANNEL);

            // Add EQ waveforms
            waveformPlotter.AddEQWaveformPlot(lowEQplot, "Low Frequencies", Mixer.ISOLATED_LOW);
            waveformPlotter.AddEQWaveformPlot(midEQplot, "Mid Frequencies", Mixer.ISOLATED_MID);
            waveformPlotter.AddEQWaveformPlot(highEQplot, "High Frequencies", Mixer.ISOLATED_HIGH);


            // FFT plotter
            fftPlotter = new FFTPlotter(spectrumPlot, AudioProcessor.SAMPLE_RATE);
            fftPlotter.AddTuner(toneLabel);
        }

        private void InitializeAudio(ISampleProvider sourceProvider)
        {
            // Enabling controls
            EnablingControls(true);

            // Initialize audio processor
            audioProcessor = new AudioProcessor(sourceProvider);
            audioProcessor.AddVuMeter(leftVolumeMeter, rightVolumeMeter);
            audioProcessor.AddPlotters(waveformPlotter, fftPlotter);
            audioProcessor.PlaybackManager.AddTimeElapsedLabel(timeElapsedLabel);

            // Init waveform EQs
            waveformPlotter.InitEQs(audioProcessor.PlaybackManager.SMB);

            // Perform click on start button
            playButton.PerformClick();

            // Start audio processor
            audioProcessor.Start();

            // Handle events
            AddEventHandlers();
        }

        private void InitializeSynthesizer()
        {
            // Istantiate synthesizer
            synthesizer = new Synthesizer(fncList, synthFuncsCmbx);

            // Make invisible some controls
            speedSlider.Visible = false;
            timeSlider.Visible = false;
            playbackLabel.Visible = false;
            timeElapsedLabel.Visible = false;

            // Setup functions list
            fncList.Visible = true;
            fncList.Location = new Point(438, 24);
            fncList.Size = new Size(393, 124);

            fncList.SelectedIndexChanged += delegate
            {
                if (fncList.SelectedIndex == -1)
                    return;


                synthFuncsCmbx.SelectedIndex = synthFuncsCmbx.FindString(synthesizer.signals[fncList.SelectedIndex].Signal.ToString()); 
                ampNum.Value = (decimal)synthesizer.signals[fncList.SelectedIndex].Amplitude;
                freqNum.Value = (decimal)synthesizer.signals[fncList.SelectedIndex].Frequency;
            };

            addSynth.Visible = true;
            removeSynth.Visible = true;
            editSynth.Visible = true;

            synthFuncsCmbx.Visible = true;

            freqNum.Visible = true;
            ampNum.Visible = true;

            freqNum.MouseWheel += EventsUtils.numericUpDown_MouseWheel;
            ampNum.MouseWheel += EventsUtils.numericUpDown_MouseWheel;

            synthFuncsCmbx.SelectedIndexChanged += delegate
            {
                SignalType selectedSignal = (SignalType)Enum.Parse(typeof(SignalType), synthFuncsCmbx.SelectedItem.ToString());

                synthesizer.EditFunction(fncList.SelectedIndex, funcType: selectedSignal);
            };

            freqNum.ValueChanged += delegate
            {
                synthesizer.EditFunction(fncList.SelectedIndex, freq: (double)freqNum.Value);
            };

            ampNum.ValueChanged += delegate
            {
                synthesizer.EditFunction(fncList.SelectedIndex, amp: (double)ampNum.Value);
            };

            addSynth.Click += delegate
            {
                synthesizer.AddFunction(new SignalFunction() { Signal = SignalType.Sine, Frequency = (double)freqNum.Value, Amplitude = (double)ampNum.Value, Phase = 0.0});
            };

            editSynth.Click += delegate
            {
                synthesizer.EditFunction(fncList.SelectedIndex, new SignalFunction() { Signal = SignalType.Sine, Frequency = (double)freqNum.Value, Amplitude = (double)ampNum.Value, Phase = 0.0 });
            };

            removeSynth.Click += delegate
            {
                synthesizer.RemoveFunction(fncList.SelectedIndex);
            };
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            EnablingControls(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioProcessor.Close();
        }

        private void wavTSMI_Click(object sender, EventArgs e)
        {
            if (audioOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Initialize audio
                InitializeAudio(new AudioFileReader(audioOpenFileDialog.FileName));

                playButton.Enabled = true;
                stopButton.Enabled = true;
                wavTSMI.Enabled = false;
            }
        }

        private void synthTSMI_Click(object sender, EventArgs e)
        {
            // Initialize the synthesizer
            InitializeSynthesizer();

            // Initialize the audio processor (with the synthesizer)
            InitializeAudio(synthesizer);
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
    }
}