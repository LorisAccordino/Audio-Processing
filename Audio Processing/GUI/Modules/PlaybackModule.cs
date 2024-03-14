using AudioProcessing.Common;
using AudioProcessing.Events;
using NAudio.Wave;

namespace AudioProcessing.GUI.Modules
{
    public partial class PlaybackModule : GenericModule
    {
        // Consts
        const int FFT_SIZE = 4096;
        const long OSAMP = 8L;

        // Events
        public event EventHandler<EventArgs>? PlaybackStarted;
        public ActionWithInvoke? PlaybackStartedAction { get; set; }

        public event EventHandler<EventArgs>? PlaybackStopped;
        public ActionWithInvoke? PlaybackStoppedAction { get; set; }

        public event EventHandler<EventArgs>? SpeedChanged;
        public Action<float>? SpeedChangedAction;

        public event EventHandler<EventArgs>? PitchChanged;
        public Action<float>? PitchChangedAction;


        public event EventHandler<ValueEventArgs<string>>? TimeUpdated;
        public ActionWithInvoke<string>? TimeUpdatedAction { get; set; }


        private void OnPlaybackStarted(EventArgs e)
        {
            PlaybackStarted?.Invoke(this, e);
            PlaybackStartedAction?.Execute();
        }

        private void OnPlaybackStopped(EventArgs e)
        {
            PlaybackStopped?.Invoke(this, e);
            PlaybackStoppedAction?.Execute();
        }

        private void OnSpeedChanged(ValueEventArgs<float> e)
        {
            SpeedChanged?.Invoke(this, e);
            SpeedChangedAction?.Invoke(e.Value);
        }

        private void OnPitchChanged(ValueEventArgs<float> e)
        {
            PitchChanged?.Invoke(this, e);
            PitchChangedAction?.Invoke(e.Value);
        }

        private void OnTimeUpdated(ValueEventArgs<string> e)
        {
            TimeUpdated?.Invoke(this, e);
            TimeUpdatedAction?.Execute(e.Value);
        }

        public PlaybackModule()
        {
            InitializeComponent();

            List<TimeFormat> formats = Utils.GetEnumValues<TimeFormat>();
            timeFormatCmbx.Items.AddRange(Utils.ConvertListToObjects(formats).ToArray());
            timeFormatCmbx.SelectedIndex = 0;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Toggle playback state
            TogglePlaybackState();

            // Update play/pause icon
            playButton.Text = IsPaused() ? "⏵" : "⏸";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop playback
            StopPlayback();
        }

        // Perform click on play button
        /*public void StartPlayback()
        {
            playButton.PerformClick();
        }*/

        // Perform click on stop button
        /*public void StopPlayback()
        {
            playButton.PerformClick();
        }*/

        public void StartPlayback()
        {
            waveOut.Play();
            OnPlaybackStarted(EventArgs.Empty);
        }

        public void PausePlayback()
        {
            waveOut.Pause();
        }

        public void StopPlayback()
        {
            waveOut.Stop();
            OnPlaybackStopped(EventArgs.Empty);
        }

        public void TogglePlaybackState()
        {
            if (IsPaused() || !IsAlive())
            {
                StartPlayback();
            }
            else
            {
                PausePlayback();
            }
        }

        public bool IsAlive()
        {
            return PlaybackState != PlaybackState.Stopped;
        }

        public bool IsPaused()
        {
            return PlaybackState == PlaybackState.Paused;
        }
    }
}
