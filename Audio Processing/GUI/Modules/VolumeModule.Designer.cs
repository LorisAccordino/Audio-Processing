using AudioProcessing.Common;

namespace AudioProcessing.GUI.Modules
{
    partial class VolumeModule
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
            volumeGroupBox = new GroupBox();
            panPot = new GUI.PrecisionPot();
            rightVolumeMeter = new GUI.VolumeMeter();
            leftVolumeMeter = new GUI.VolumeMeter();
            isStereoCheckbox = new CheckBox();
            label12 = new Label();
            label11 = new Label();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            volumeSlider = new GUI.PrecisionSlider();
            volumeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // volumeGroupBox
            // 
            volumeGroupBox.Controls.Add(panPot);
            volumeGroupBox.Controls.Add(rightVolumeMeter);
            volumeGroupBox.Controls.Add(leftVolumeMeter);
            volumeGroupBox.Controls.Add(isStereoCheckbox);
            volumeGroupBox.Controls.Add(label12);
            volumeGroupBox.Controls.Add(label11);
            volumeGroupBox.Controls.Add(label1);
            volumeGroupBox.Controls.Add(label3);
            volumeGroupBox.Controls.Add(label2);
            volumeGroupBox.Controls.Add(volumeSlider);
            volumeGroupBox.Dock = DockStyle.Fill;
            volumeGroupBox.Location = new Point(0, 0);
            volumeGroupBox.Name = "volumeGroupBox";
            volumeGroupBox.Size = new Size(312, 510);
            volumeGroupBox.TabIndex = 26;
            volumeGroupBox.TabStop = false;
            volumeGroupBox.Text = "Volume:";
            // 
            // panPot
            // 
            panPot.Location = new Point(221, 412);
            panPot.Maximum = 1D;
            panPot.Minimum = -1D;
            panPot.Name = "panPot";
            panPot.PotIndex = -1;
            panPot.ShowValue = false;
            panPot.Size = new Size(62, 76);
            panPot.TabIndex = 29;
            panPot.Text = "Pan";
            panPot.Value = 0D;
            panPot.ValueAction = null;
            panPot.ValueSuffix = null;
            // 
            // rightVolumeMeter
            // 
            rightVolumeMeter.Channel = AudioChannel.RightChannel;
            rightVolumeMeter.Location = new Point(82, 26);
            rightVolumeMeter.MaxDb = 3F;
            rightVolumeMeter.MinDb = -40F;
            rightVolumeMeter.Name = "rightVolumeMeter";
            rightVolumeMeter.Size = new Size(51, 466);
            rightVolumeMeter.TabIndex = 15;
            rightVolumeMeter.Text = "volumeMeter1";
            rightVolumeMeter.VolumeLevel = -40F;
            // 
            // leftVolumeMeter
            // 
            leftVolumeMeter.Channel = AudioChannel.LeftChannel;
            leftVolumeMeter.Location = new Point(15, 26);
            leftVolumeMeter.MaxDb = 3F;
            leftVolumeMeter.MinDb = -40F;
            leftVolumeMeter.Name = "leftVolumeMeter";
            leftVolumeMeter.Size = new Size(51, 466);
            leftVolumeMeter.TabIndex = 14;
            leftVolumeMeter.Text = "volumeMeter1";
            leftVolumeMeter.VolumeLevel = -40F;
            // 
            // isStereoCheckbox
            // 
            isStereoCheckbox.AutoSize = true;
            isStereoCheckbox.Checked = true;
            isStereoCheckbox.CheckState = CheckState.Checked;
            isStereoCheckbox.Location = new Point(143, 468);
            isStereoCheckbox.Name = "isStereoCheckbox";
            isStereoCheckbox.Size = new Size(72, 24);
            isStereoCheckbox.TabIndex = 13;
            isStereoCheckbox.Text = "stereo";
            isStereoCheckbox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(267, 485);
            label12.Name = "label12";
            label12.Size = new Size(18, 20);
            label12.TabIndex = 11;
            label12.Text = "R";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(224, 485);
            label11.Name = "label11";
            label11.Size = new Size(16, 20);
            label11.TabIndex = 10;
            label11.Text = "L";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(209, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "+3 dB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 88);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 8;
            label3.Text = "0 dB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 364);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 6;
            label2.Text = "-40 dB";
            // 
            // volumeSlider
            // 
            volumeSlider.Location = new Point(177, 26);
            volumeSlider.Maximum = 3F;
            volumeSlider.Minimum = -40F;
            volumeSlider.Name = "volumeSlider";
            volumeSlider.Orientation = Orientation.Vertical;
            volumeSlider.Precision = 0.1F;
            volumeSlider.PrecisionScale = GUI.PrecisionScale.Logarithmic;
            volumeSlider.Size = new Size(62, 387);
            volumeSlider.TabIndex = 28;
            volumeSlider.Text = "precisionSlider1";
            volumeSlider.TickFrequency = 20;
            volumeSlider.Value = 0D;
            volumeSlider.ValueAction = null;
            volumeSlider.ValueSuffix = "dB";
            // 
            // VolumeModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(volumeGroupBox);
            Name = "VolumeModule";
            Size = new Size(312, 510);
            volumeGroupBox.ResumeLayout(false);
            volumeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox volumeGroupBox;
        private AudioProcessing.GUI.PrecisionPot panPot;
        private AudioProcessing.GUI.VolumeMeter rightVolumeMeter;
        private AudioProcessing.GUI.VolumeMeter leftVolumeMeter;
        private CheckBox isStereoCheckbox;
        private Label label12;
        private Label label11;
        private Label label1;
        private Label label3;
        private Label label2;
        private AudioProcessing.GUI.PrecisionSlider volumeSlider;

        #region Manually written code

        public override void InitializeEvents()
        {
            volumeSlider.ValueAction = new Action<float>(value => audioProcessor.VuMeter.Volume = (float)VolumeConverter.LogVolumeToLinearAmplitude(value));
            panPot.ValueAction = new Action<float>(value => audioProcessor.VuMeter.Pan = value);

            isStereoCheckbox.Tag = new Action<bool>(value => audioProcessor.VuMeter.IsStereo = value);
            isStereoCheckbox.CheckedChanged += Utils.CheckboxCheckedChangedAction;

            audioProcessor.VuMeter.VolumeChanged += leftVolumeMeter.OnVolumeChanged;
            audioProcessor.VuMeter.VolumeChanged += rightVolumeMeter.OnVolumeChanged;
            audioProcessor.VuMeter.SpeakerUpdated += SpeakerDialog.Instance.OnSpeakerUpdated;
        }

        public override void ResetComponent(bool enabled)
        {
            base.ResetComponent(enabled);

            // Reset values
            leftVolumeMeter.VolumeLevel = -40;
            rightVolumeMeter.VolumeLevel = -40;

            volumeSlider.Value = 0;
            panPot.Value = 0;

            isStereoCheckbox.Checked = true;
        }

        #endregion
    }
}
