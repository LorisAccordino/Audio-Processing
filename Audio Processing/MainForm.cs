using AudioProcessing.Audio;
using AudioProcessing.Common;
using AudioProcessing.Events;
using AudioProcessing.GUI.Modules;
using NAudio.Wave;

namespace AudioProcessing
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; } = SingletonManager<MainForm>.GetInstance();

        // Audio processor
        private AudioProcessor audioProcessor = AudioProcessor.Instance;

        // Speaker dialog
        private SpeakerDialog speakerDialog = new SpeakerDialog();

        public MainForm()
        {
            // Initialize stuff
            InitializeComponent();

            // Add user modules
            playbackPanel.Controls.Add(SingletonManager<PlaybackModule>.GetInstance());
            volumePanel.Controls.Add(SingletonManager<VolumeModule>.GetInstance());
            equalizerPanel.Controls.Add(SingletonManager<EqualizerModule>.GetInstance());
            plotsPanel.Controls.Add(SingletonManager<PlotsModule>.GetInstance());
        }

        private void Initialize(ISampleProvider sourceProvider)
        {
            // Start audio processor
            audioProcessor.StartWAV(sourceProvider);

            // Perform click on play button
            SingletonManager<PlaybackModule>.GetInstance().StartPlayback();

            // Start the separated thread
            audioProcessor.StartThread();

            // Handle events for each module
            //GenericModule.ExecuteMethodForEach(module => module.InitializeEvents());
            //audioProcessor.PlaybackManager.PlaybackStoppedAction = new ActionWithInvoke(() => GenericModule.ExecuteMethodForEach(module => module.ResetComponent(false)), this);
        }

        
        private void InitializeSynthesizer()
        {
            // Make invisible some controls
            /*speedSlider.Visible = false;
            timeSlider.Visible = false;
            playbackLabel.Visible = false;
            timeElapsedLabel.Visible = false;*/
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Reset (and disable) components
            //GenericModule.ExecuteMethodForEach(module => module.ResetComponent(false));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (audioProcessor.PlaybackManager.IsAlive())
            {
                audioProcessor.Close();
                e.Cancel = true;
            }
        }

        private void wavTSMI_Click(object sender, EventArgs e)
        {
            if (audioOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Initialize audio
                Initialize(new AudioFileReader(audioOpenFileDialog.FileName));
                wavTSMI.Enabled = false;
            }
        }

        private void synthTSMI_Click(object sender, EventArgs e)
        {
            // Initialize the synthesizer
            InitializeSynthesizer();

            // Initialize the audio processor (with the synthesizer)
            audioProcessor.StartSynth();

            Initialize(audioProcessor.Synthesizer);

            // Change pitch slider action
            //pitchSlider.ValueAction = new Action<float>(value => audioProcessor.Synthesizer.Pitch = value);
        }

        private void showSpeakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speakerDialog.Show();
        }
    }
}