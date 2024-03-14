using AudioProcessing.Common;
using AudioProcessing.Events;

namespace AudioProcessing.GUI.Modules
{
    partial class PlaybackModule
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            playbackGroupBox = new GroupBox();
            timeElapsedLabel = new Label();
            timeFormatCmbx = new ComboBox();
            timeFormatLabel = new Label();
            zoomSlider = new PrecisionSlider();
            timeSlider = new PrecisionSlider();
            pitchSlider = new PrecisionSlider();
            speedSlider = new PrecisionSlider();
            playbackLabel = new Label();
            stopButton = new Button();
            playButton = new Button();
            playbackGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // playbackGroupBox
            // 
            playbackGroupBox.Controls.Add(timeElapsedLabel);
            playbackGroupBox.Controls.Add(timeFormatCmbx);
            playbackGroupBox.Controls.Add(timeFormatLabel);
            playbackGroupBox.Controls.Add(zoomSlider);
            playbackGroupBox.Controls.Add(timeSlider);
            playbackGroupBox.Controls.Add(pitchSlider);
            playbackGroupBox.Controls.Add(speedSlider);
            playbackGroupBox.Controls.Add(playbackLabel);
            playbackGroupBox.Controls.Add(stopButton);
            playbackGroupBox.Controls.Add(playButton);
            playbackGroupBox.Location = new Point(12, 4);
            playbackGroupBox.Name = "playbackGroupBox";
            playbackGroupBox.Size = new Size(1076, 162);
            playbackGroupBox.TabIndex = 14;
            playbackGroupBox.TabStop = false;
            playbackGroupBox.Text = "Playback:";
            // 
            // timeElapsedLabel
            // 
            timeElapsedLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeElapsedLabel.Location = new Point(854, 76);
            timeElapsedLabel.Name = "timeElapsedLabel";
            timeElapsedLabel.Size = new Size(211, 25);
            timeElapsedLabel.TabIndex = 32;
            timeElapsedLabel.Text = "Samples: 000.000.000";
            timeElapsedLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timeFormatCmbx
            // 
            timeFormatCmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            timeFormatCmbx.FormattingEnabled = true;
            timeFormatCmbx.Location = new Point(954, 112);
            timeFormatCmbx.Name = "timeFormatCmbx";
            timeFormatCmbx.Size = new Size(116, 28);
            timeFormatCmbx.TabIndex = 31;
            // 
            // timeFormatLabel
            // 
            timeFormatLabel.AutoSize = true;
            timeFormatLabel.Location = new Point(854, 115);
            timeFormatLabel.Name = "timeFormatLabel";
            timeFormatLabel.Size = new Size(94, 20);
            timeFormatLabel.TabIndex = 30;
            timeFormatLabel.Text = "Time format:";
            // 
            // zoomSlider
            // 
            zoomSlider.Location = new Point(23, 21);
            zoomSlider.Maximum = 100F;
            zoomSlider.Minimum = 1F;
            zoomSlider.Name = "zoomSlider";
            zoomSlider.Precision = 0.1F;
            zoomSlider.PrecisionScale = PrecisionScale.Exponential;
            zoomSlider.Size = new Size(394, 70);
            zoomSlider.TabIndex = 27;
            zoomSlider.Text = "Zoom:";
            zoomSlider.TickFrequency = 30;
            zoomSlider.Value = 1D;
            zoomSlider.ValueAction = null;
            zoomSlider.ValueSuffix = "%";
            // 
            // timeSlider
            // 
            timeSlider.Location = new Point(438, 86);
            timeSlider.Maximum = 2F;
            timeSlider.Minimum = 0.25F;
            timeSlider.Name = "timeSlider";
            timeSlider.PrecisionScale = PrecisionScale.Linear;
            timeSlider.Size = new Size(393, 70);
            timeSlider.TabIndex = 26;
            timeSlider.Text = "Time:";
            timeSlider.TickFrequency = 5;
            timeSlider.Value = 1D;
            timeSlider.ValueAction = null;
            timeSlider.ValueSuffix = "x";
            // 
            // pitchSlider
            // 
            pitchSlider.Location = new Point(23, 86);
            pitchSlider.Maximum = 4F;
            pitchSlider.Minimum = 0.25F;
            pitchSlider.Name = "pitchSlider";
            pitchSlider.PrecisionScale = PrecisionScale.Linear;
            pitchSlider.Size = new Size(394, 70);
            pitchSlider.TabIndex = 25;
            pitchSlider.Text = "Pitch:";
            pitchSlider.TickFrequency = 25;
            pitchSlider.Value = 1D;
            pitchSlider.ValueAction = null;
            pitchSlider.ValueSuffix = " x";
            // 
            // speedSlider
            // 
            speedSlider.Location = new Point(438, 24);
            speedSlider.Maximum = 3F;
            speedSlider.Minimum = 0.001F;
            speedSlider.Name = "speedSlider";
            speedSlider.Precision = 0.001F;
            speedSlider.PrecisionScale = PrecisionScale.Linear;
            speedSlider.Size = new Size(393, 70);
            speedSlider.TabIndex = 1;
            speedSlider.Text = "Speed:";
            speedSlider.TickFrequency = 100;
            speedSlider.Value = 1D;
            speedSlider.ValueAction = null;
            speedSlider.ValueSuffix = "x";
            // 
            // playbackLabel
            // 
            playbackLabel.AutoSize = true;
            playbackLabel.Location = new Point(854, 35);
            playbackLabel.Name = "playbackLabel";
            playbackLabel.Size = new Size(106, 20);
            playbackLabel.TabIndex = 23;
            playbackLabel.Text = "Playback state:";
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stopButton.Location = new Point(1017, 19);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(48, 48);
            stopButton.TabIndex = 22;
            stopButton.Text = "⏹";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // playButton
            // 
            playButton.Font = new Font("Consolas", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playButton.Location = new Point(965, 19);
            playButton.Name = "playButton";
            playButton.Size = new Size(48, 48);
            playButton.TabIndex = 21;
            playButton.Text = "⏵";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // PlaybackModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playbackGroupBox);
            Name = "PlaybackModule";
            Size = new Size(1099, 176);
            playbackGroupBox.ResumeLayout(false);
            playbackGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox playbackGroupBox;
        private AudioProcessing.GUI.PrecisionSlider zoomSlider;
        private AudioProcessing.GUI.PrecisionSlider timeSlider;
        private AudioProcessing.GUI.PrecisionSlider pitchSlider;
        private AudioProcessing.GUI.PrecisionSlider speedSlider;
        private Label playbackLabel;
        private Button stopButton;
        private Button playButton;

        #region Manually written code

        public override void InitializeEvents()
        {
            speedSlider.ValueAction = new Action<float>(value => audioProcessor.PlaybackManager.PlaybackSpeed = value);
            pitchSlider.ValueAction = new Action<float>(value => audioProcessor.PlaybackManager.PitchFactor = value);
            timeSlider.ValueAction = new Action<float>(value => audioProcessor.PlaybackManager.TimeStrech = value);
            zoomSlider.ValueAction = new Action<float>(value => audioProcessor.WaveformPlotter.Zoom = Math.Max(1.0f, value));

            audioProcessor.PlaybackManager.SpeedChangedAction = new Action<float>(value => speedSlider.Value = value);
            audioProcessor.PlaybackManager.PitchChangedAction = new Action<float>(value => pitchSlider.Value = value);
            audioProcessor.PlaybackManager.PlaybackStoppedAction = new ActionWithInvoke(() => ResetComponent(false), this);
            audioProcessor.PlaybackManager.TimeUpdatedAction = new ActionWithInvoke<string>(new Action<string>(value => timeElapsedLabel.Text = value), timeElapsedLabel);

            timeFormatCmbx.Tag = new Action<object>(value => audioProcessor.PlaybackManager.PlaybackTimeFormat = (TimeFormat)value);
            timeFormatCmbx.SelectedIndexChanged += Utils.ComboboxIndexChangedAction;
        }

        public override void ResetComponent(bool enabled)
        {
            base.ResetComponent(enabled);

            // Reset values
            zoomSlider.Value = 1;
            speedSlider.Value = 1;
            pitchSlider.Value = 1;
            timeSlider.Value = 1;
            timeElapsedLabel.Text = "Samples: " + Utils.FormatTimeElapsed(0, TimeFormat.Samples);
        }

#endregion
        private Label timeFormatLabel;
        private ComboBox timeFormatCmbx;
        private Label timeElapsedLabel;
    }
}
