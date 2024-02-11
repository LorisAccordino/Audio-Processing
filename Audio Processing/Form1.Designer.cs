namespace AudioProcessing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            waveformPlot = new ScottPlot.WinForms.FormsPlot();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            playbackGroupBox = new GroupBox();
            zoomSlider = new GUI.PrecisionSlider();
            timeSlider = new GUI.PrecisionSlider();
            pitchSlider = new GUI.PrecisionSlider();
            speedSlider = new GUI.PrecisionSlider();
            timeElapsedLabel = new Label();
            label14 = new Label();
            stopButton = new Button();
            playButton = new Button();
            lowPot = new NAudio.Gui.Pot();
            midPot = new NAudio.Gui.Pot();
            highPot = new NAudio.Gui.Pot();
            lowLabel = new Label();
            midLabel = new Label();
            highLabel = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            eqGroupBox = new GroupBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            profileMicrophoneToolStripMenuItem = new ToolStripMenuItem();
            audioOpenFileDialog = new OpenFileDialog();
            volumeGroupBox = new GroupBox();
            rightVolumeMeter = new GUI.VolumeMeter();
            leftVolumeMeter = new GUI.VolumeMeter();
            isStereoCheckbox = new CheckBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            panPot = new NAudio.Gui.Pot();
            volumeSlider = new GUI.PrecisionSlider();
            tabControl = new TabControl();
            waveformPage = new TabPage();
            leftRightWaveformPage = new TabPage();
            leftWaveformPlot = new ScottPlot.WinForms.FormsPlot();
            rightWaveformPlot = new ScottPlot.WinForms.FormsPlot();
            eqWaveformPage = new TabPage();
            highEQplot = new ScottPlot.WinForms.FormsPlot();
            midEQplot = new ScottPlot.WinForms.FormsPlot();
            lowEQplot = new ScottPlot.WinForms.FormsPlot();
            spectrogramPage = new TabPage();
            tunerGroupBox = new GroupBox();
            toneLabel = new Label();
            fftLimitsGroupBox = new GroupBox();
            fftDbSlider = new GUI.PrecisionSlider();
            fftHzSlider = new GUI.PrecisionSlider();
            spectrumPlot = new ScottPlot.WinForms.FormsPlot();
            playbackGroupBox.SuspendLayout();
            eqGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            volumeGroupBox.SuspendLayout();
            tabControl.SuspendLayout();
            waveformPage.SuspendLayout();
            leftRightWaveformPage.SuspendLayout();
            eqWaveformPage.SuspendLayout();
            spectrogramPage.SuspendLayout();
            tunerGroupBox.SuspendLayout();
            fftLimitsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // waveformPlot
            // 
            waveformPlot.DisplayScale = 1.25F;
            waveformPlot.Dock = DockStyle.Fill;
            waveformPlot.Location = new Point(3, 3);
            waveformPlot.Name = "waveformPlot";
            waveformPlot.Size = new Size(1074, 451);
            waveformPlot.TabIndex = 0;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 364);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 6;
            label2.Text = "-40 dB";
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
            // playbackGroupBox
            // 
            playbackGroupBox.Controls.Add(zoomSlider);
            playbackGroupBox.Controls.Add(timeSlider);
            playbackGroupBox.Controls.Add(pitchSlider);
            playbackGroupBox.Controls.Add(speedSlider);
            playbackGroupBox.Controls.Add(timeElapsedLabel);
            playbackGroupBox.Controls.Add(label14);
            playbackGroupBox.Controls.Add(stopButton);
            playbackGroupBox.Controls.Add(playButton);
            playbackGroupBox.Location = new Point(12, 529);
            playbackGroupBox.Name = "playbackGroupBox";
            playbackGroupBox.Size = new Size(1076, 162);
            playbackGroupBox.TabIndex = 13;
            playbackGroupBox.TabStop = false;
            playbackGroupBox.Text = "Playback:";
            // 
            // zoomSlider
            // 
            zoomSlider.Location = new Point(23, 21);
            zoomSlider.Maximum = 100F;
            zoomSlider.Minimum = 1F;
            zoomSlider.Name = "zoomSlider";
            zoomSlider.Precision = 0.1F;
            zoomSlider.PrecisionScale = GUI.PrecisionScale.Exponential;
            zoomSlider.Size = new Size(394, 70);
            zoomSlider.TabIndex = 27;
            zoomSlider.Text = "Zoom:";
            zoomSlider.TickFrequency = 30;
            zoomSlider.Value = 1F;
            zoomSlider.ValueSuffix = "x";
            // 
            // timeSlider
            // 
            timeSlider.Location = new Point(438, 86);
            timeSlider.Maximum = 2F;
            timeSlider.Minimum = 0.5F;
            timeSlider.Name = "timeSlider";
            timeSlider.PrecisionScale = GUI.PrecisionScale.Linear;
            timeSlider.Size = new Size(393, 70);
            timeSlider.TabIndex = 26;
            timeSlider.Text = "Time:";
            timeSlider.TickFrequency = 5;
            timeSlider.Value = 1F;
            timeSlider.ValueSuffix = "x";
            // 
            // pitchSlider
            // 
            pitchSlider.Location = new Point(23, 86);
            pitchSlider.Maximum = 200F;
            pitchSlider.Minimum = 10F;
            pitchSlider.Name = "pitchSlider";
            pitchSlider.PrecisionScale = GUI.PrecisionScale.Linear;
            pitchSlider.Size = new Size(394, 70);
            pitchSlider.TabIndex = 25;
            pitchSlider.Text = "Pitch:";
            pitchSlider.TickFrequency = 500;
            pitchSlider.Value = 100F;
            pitchSlider.ValueSuffix = "%";
            // 
            // speedSlider
            // 
            speedSlider.Location = new Point(438, 24);
            speedSlider.Maximum = 2F;
            speedSlider.Minimum = 0.25F;
            speedSlider.Name = "speedSlider";
            speedSlider.PrecisionScale = GUI.PrecisionScale.Linear;
            speedSlider.Size = new Size(393, 70);
            speedSlider.TabIndex = 1;
            speedSlider.Text = "Speed:";
            speedSlider.TickFrequency = 10;
            speedSlider.Value = 1F;
            speedSlider.ValueSuffix = "x";
            // 
            // timeElapsedLabel
            // 
            timeElapsedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timeElapsedLabel.Location = new Point(847, 77);
            timeElapsedLabel.Name = "timeElapsedLabel";
            timeElapsedLabel.Size = new Size(218, 79);
            timeElapsedLabel.TabIndex = 24;
            timeElapsedLabel.Text = "Samples: 0\r\nTime: 00:00,000";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(847, 43);
            label14.Name = "label14";
            label14.Size = new Size(106, 20);
            label14.TabIndex = 23;
            label14.Text = "Playback state:";
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stopButton.Location = new Point(1017, 26);
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
            playButton.Location = new Point(961, 26);
            playButton.Name = "playButton";
            playButton.Size = new Size(48, 48);
            playButton.TabIndex = 21;
            playButton.Text = "⏵";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // lowPot
            // 
            lowPot.Location = new Point(54, 40);
            lowPot.Margin = new Padding(4, 5, 4, 5);
            lowPot.Maximum = 1D;
            lowPot.Minimum = -1D;
            lowPot.Name = "lowPot";
            lowPot.Size = new Size(54, 61);
            lowPot.TabIndex = 14;
            lowPot.Value = 0D;
            lowPot.ValueChanged += lowPot_ValueChanged;
            // 
            // midPot
            // 
            midPot.Location = new Point(121, 40);
            midPot.Margin = new Padding(4, 5, 4, 5);
            midPot.Maximum = 1D;
            midPot.Minimum = -1D;
            midPot.Name = "midPot";
            midPot.Size = new Size(54, 61);
            midPot.TabIndex = 15;
            midPot.Value = 0D;
            midPot.ValueChanged += midPot_ValueChanged;
            // 
            // highPot
            // 
            highPot.Location = new Point(191, 40);
            highPot.Margin = new Padding(4, 5, 4, 5);
            highPot.Maximum = 1D;
            highPot.Minimum = -1D;
            highPot.Name = "highPot";
            highPot.Size = new Size(54, 61);
            highPot.TabIndex = 16;
            highPot.Value = 0D;
            highPot.ValueChanged += highPot_ValueChanged;
            // 
            // lowLabel
            // 
            lowLabel.Location = new Point(50, 98);
            lowLabel.Name = "lowLabel";
            lowLabel.Size = new Size(62, 25);
            lowLabel.TabIndex = 17;
            lowLabel.Text = "0 dB";
            lowLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // midLabel
            // 
            midLabel.Location = new Point(118, 98);
            midLabel.Name = "midLabel";
            midLabel.Size = new Size(62, 25);
            midLabel.TabIndex = 18;
            midLabel.Text = "0 dB";
            midLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // highLabel
            // 
            highLabel.Location = new Point(188, 97);
            highLabel.Name = "highLabel";
            highLabel.Size = new Size(62, 25);
            highLabel.TabIndex = 19;
            highLabel.Text = "0 dB";
            highLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(63, 19);
            label8.Name = "label8";
            label8.Size = new Size(36, 20);
            label8.TabIndex = 20;
            label8.Text = "Low";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(130, 19);
            label9.Name = "label9";
            label9.Size = new Size(35, 20);
            label9.TabIndex = 21;
            label9.Text = "Mid";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(198, 19);
            label10.Name = "label10";
            label10.Size = new Size(41, 20);
            label10.TabIndex = 22;
            label10.Text = "High";
            // 
            // eqGroupBox
            // 
            eqGroupBox.Controls.Add(midPot);
            eqGroupBox.Controls.Add(label10);
            eqGroupBox.Controls.Add(lowPot);
            eqGroupBox.Controls.Add(label9);
            eqGroupBox.Controls.Add(highPot);
            eqGroupBox.Controls.Add(label8);
            eqGroupBox.Controls.Add(lowLabel);
            eqGroupBox.Controls.Add(highLabel);
            eqGroupBox.Controls.Add(midLabel);
            eqGroupBox.Location = new Point(1099, 550);
            eqGroupBox.Name = "eqGroupBox";
            eqGroupBox.Size = new Size(300, 141);
            eqGroupBox.TabIndex = 23;
            eqGroupBox.TabStop = false;
            eqGroupBox.Text = "EQ:";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1416, 28);
            menuStrip1.TabIndex = 24;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, profileMicrophoneToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(56, 24);
            fileToolStripMenuItem.Text = "Tasks";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(274, 26);
            openToolStripMenuItem.Text = "Import WAV";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // profileMicrophoneToolStripMenuItem
            // 
            profileMicrophoneToolStripMenuItem.Name = "profileMicrophoneToolStripMenuItem";
            profileMicrophoneToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            profileMicrophoneToolStripMenuItem.Size = new Size(274, 26);
            profileMicrophoneToolStripMenuItem.Text = "Profile microphone";
            profileMicrophoneToolStripMenuItem.Click += profileMicrophoneToolStripMenuItem_Click;
            // 
            // audioOpenFileDialog
            // 
            audioOpenFileDialog.Filter = "File WAV|*.wav";
            // 
            // volumeGroupBox
            // 
            volumeGroupBox.Controls.Add(rightVolumeMeter);
            volumeGroupBox.Controls.Add(leftVolumeMeter);
            volumeGroupBox.Controls.Add(isStereoCheckbox);
            volumeGroupBox.Controls.Add(label13);
            volumeGroupBox.Controls.Add(label12);
            volumeGroupBox.Controls.Add(label11);
            volumeGroupBox.Controls.Add(panPot);
            volumeGroupBox.Controls.Add(label1);
            volumeGroupBox.Controls.Add(label3);
            volumeGroupBox.Controls.Add(label2);
            volumeGroupBox.Controls.Add(volumeSlider);
            volumeGroupBox.Location = new Point(1099, 33);
            volumeGroupBox.Name = "volumeGroupBox";
            volumeGroupBox.Size = new Size(300, 511);
            volumeGroupBox.TabIndex = 25;
            volumeGroupBox.TabStop = false;
            volumeGroupBox.Text = "Volume:";
            // 
            // rightVolumeMeter
            // 
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
            isStereoCheckbox.CheckedChanged += isStereoCheckbox_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(238, 416);
            label13.Name = "label13";
            label13.Size = new Size(32, 20);
            label13.TabIndex = 12;
            label13.Text = "Pan";
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
            // panPot
            // 
            panPot.Location = new Point(226, 435);
            panPot.Margin = new Padding(4, 5, 4, 5);
            panPot.Maximum = 1D;
            panPot.Minimum = -1D;
            panPot.Name = "panPot";
            panPot.Size = new Size(54, 61);
            panPot.TabIndex = 9;
            panPot.Value = 0D;
            panPot.ValueChanged += panPot_ValueChanged;
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
            volumeSlider.Value = 0F;
            volumeSlider.ValueSuffix = "dB";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(waveformPage);
            tabControl.Controls.Add(leftRightWaveformPage);
            tabControl.Controls.Add(eqWaveformPage);
            tabControl.Controls.Add(spectrogramPage);
            tabControl.Location = new Point(0, 33);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1088, 490);
            tabControl.TabIndex = 26;
            // 
            // waveformPage
            // 
            waveformPage.Controls.Add(waveformPlot);
            waveformPage.Location = new Point(4, 29);
            waveformPage.Name = "waveformPage";
            waveformPage.Padding = new Padding(3);
            waveformPage.Size = new Size(1080, 457);
            waveformPage.TabIndex = 0;
            waveformPage.Text = "Waveform";
            waveformPage.UseVisualStyleBackColor = true;
            // 
            // leftRightWaveformPage
            // 
            leftRightWaveformPage.Controls.Add(leftWaveformPlot);
            leftRightWaveformPage.Controls.Add(rightWaveformPlot);
            leftRightWaveformPage.Location = new Point(4, 29);
            leftRightWaveformPage.Name = "leftRightWaveformPage";
            leftRightWaveformPage.Size = new Size(1080, 457);
            leftRightWaveformPage.TabIndex = 2;
            leftRightWaveformPage.Text = "L / R Waveform";
            leftRightWaveformPage.UseVisualStyleBackColor = true;
            // 
            // leftWaveformPlot
            // 
            leftWaveformPlot.DisplayScale = 1.25F;
            leftWaveformPlot.Location = new Point(3, 3);
            leftWaveformPlot.Name = "leftWaveformPlot";
            leftWaveformPlot.Size = new Size(1078, 226);
            leftWaveformPlot.TabIndex = 1;
            // 
            // rightWaveformPlot
            // 
            rightWaveformPlot.DisplayScale = 1.25F;
            rightWaveformPlot.Location = new Point(3, 228);
            rightWaveformPlot.Name = "rightWaveformPlot";
            rightWaveformPlot.Size = new Size(1078, 226);
            rightWaveformPlot.TabIndex = 0;
            // 
            // eqWaveformPage
            // 
            eqWaveformPage.Controls.Add(highEQplot);
            eqWaveformPage.Controls.Add(midEQplot);
            eqWaveformPage.Controls.Add(lowEQplot);
            eqWaveformPage.Location = new Point(4, 29);
            eqWaveformPage.Name = "eqWaveformPage";
            eqWaveformPage.Size = new Size(1080, 457);
            eqWaveformPage.TabIndex = 3;
            eqWaveformPage.Text = "EQ Waveform";
            eqWaveformPage.UseVisualStyleBackColor = true;
            // 
            // highEQplot
            // 
            highEQplot.DisplayScale = 1.25F;
            highEQplot.Location = new Point(542, 228);
            highEQplot.Name = "highEQplot";
            highEQplot.Size = new Size(535, 226);
            highEQplot.TabIndex = 2;
            // 
            // midEQplot
            // 
            midEQplot.DisplayScale = 1.25F;
            midEQplot.Location = new Point(3, 228);
            midEQplot.Name = "midEQplot";
            midEQplot.Size = new Size(541, 226);
            midEQplot.TabIndex = 1;
            // 
            // lowEQplot
            // 
            lowEQplot.DisplayScale = 1.25F;
            lowEQplot.Location = new Point(3, 4);
            lowEQplot.Name = "lowEQplot";
            lowEQplot.Size = new Size(1074, 226);
            lowEQplot.TabIndex = 0;
            // 
            // spectrogramPage
            // 
            spectrogramPage.Controls.Add(tunerGroupBox);
            spectrogramPage.Controls.Add(fftLimitsGroupBox);
            spectrogramPage.Controls.Add(spectrumPlot);
            spectrogramPage.Location = new Point(4, 29);
            spectrogramPage.Name = "spectrogramPage";
            spectrogramPage.Padding = new Padding(3);
            spectrogramPage.Size = new Size(1080, 457);
            spectrogramPage.TabIndex = 1;
            spectrogramPage.Text = "FFT Spectrogram";
            spectrogramPage.UseVisualStyleBackColor = true;
            // 
            // tunerGroupBox
            // 
            tunerGroupBox.BackColor = SystemColors.Control;
            tunerGroupBox.Controls.Add(toneLabel);
            tunerGroupBox.Location = new Point(944, 3);
            tunerGroupBox.Name = "tunerGroupBox";
            tunerGroupBox.Size = new Size(133, 146);
            tunerGroupBox.TabIndex = 2;
            tunerGroupBox.TabStop = false;
            tunerGroupBox.Text = "Tuner:";
            // 
            // toneLabel
            // 
            toneLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toneLabel.Location = new Point(6, 23);
            toneLabel.Name = "toneLabel";
            toneLabel.Size = new Size(124, 89);
            toneLabel.TabIndex = 0;
            toneLabel.Text = "... / ...\r\n(... Hz)";
            toneLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fftLimitsGroupBox
            // 
            fftLimitsGroupBox.BackColor = SystemColors.Control;
            fftLimitsGroupBox.Controls.Add(fftDbSlider);
            fftLimitsGroupBox.Controls.Add(fftHzSlider);
            fftLimitsGroupBox.Dock = DockStyle.Bottom;
            fftLimitsGroupBox.Location = new Point(944, 150);
            fftLimitsGroupBox.Name = "fftLimitsGroupBox";
            fftLimitsGroupBox.Size = new Size(133, 304);
            fftLimitsGroupBox.TabIndex = 1;
            fftLimitsGroupBox.TabStop = false;
            fftLimitsGroupBox.Text = "Max limits:";
            // 
            // fftDbSlider
            // 
            fftDbSlider.Location = new Point(74, 26);
            fftDbSlider.Maximum = 3F;
            fftDbSlider.Minimum = -37.5F;
            fftDbSlider.Name = "fftDbSlider";
            fftDbSlider.Orientation = Orientation.Vertical;
            fftDbSlider.PrecisionScale = GUI.PrecisionScale.Exponential;
            fftDbSlider.Size = new Size(53, 267);
            fftDbSlider.TabIndex = 6;
            fftDbSlider.Text = "precisionSlider2";
            fftDbSlider.TickFrequency = 1;
            fftDbSlider.Value = 3F;
            fftDbSlider.ValueSuffix = "dB";
            // 
            // fftHzSlider
            // 
            fftHzSlider.Location = new Point(6, 26);
            fftHzSlider.Maximum = 16F;
            fftHzSlider.Minimum = 10F;
            fftHzSlider.Name = "fftHzSlider";
            fftHzSlider.Orientation = Orientation.Vertical;
            fftHzSlider.PrecisionScale = GUI.PrecisionScale.Linear;
            fftHzSlider.Size = new Size(86, 267);
            fftHzSlider.TabIndex = 5;
            fftHzSlider.Text = "precisionSlider1";
            fftHzSlider.TickFrequency = 10;
            fftHzSlider.Value = 16F;
            fftHzSlider.ValueSuffix = "kHz";
            // 
            // spectrumPlot
            // 
            spectrumPlot.DisplayScale = 1.25F;
            spectrumPlot.Dock = DockStyle.Left;
            spectrumPlot.Location = new Point(3, 3);
            spectrumPlot.Name = "spectrumPlot";
            spectrumPlot.Size = new Size(941, 451);
            spectrumPlot.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1416, 703);
            Controls.Add(tabControl);
            Controls.Add(volumeGroupBox);
            Controls.Add(eqGroupBox);
            Controls.Add(playbackGroupBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Audio Processing - C#";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            playbackGroupBox.ResumeLayout(false);
            playbackGroupBox.PerformLayout();
            eqGroupBox.ResumeLayout(false);
            eqGroupBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            volumeGroupBox.ResumeLayout(false);
            volumeGroupBox.PerformLayout();
            tabControl.ResumeLayout(false);
            waveformPage.ResumeLayout(false);
            leftRightWaveformPage.ResumeLayout(false);
            eqWaveformPage.ResumeLayout(false);
            spectrogramPage.ResumeLayout(false);
            tunerGroupBox.ResumeLayout(false);
            fftLimitsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot waveformPlot;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox playbackGroupBox;
        private NAudio.Gui.Pot lowPot;
        private NAudio.Gui.Pot midPot;
        private NAudio.Gui.Pot highPot;
        private Label lowLabel;
        private Label midLabel;
        private Label highLabel;
        private Label label8;
        private Label label9;
        private Label label10;
        private GroupBox eqGroupBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private OpenFileDialog audioOpenFileDialog;
        private GroupBox volumeGroupBox;
        private NAudio.Gui.Pot panPot;
        private Label label11;
        private Label label13;
        private Label label12;
        private TabControl tabControl;
        private TabPage waveformPage;
        private TabPage spectrogramPage;
        private ToolStripMenuItem profileMicrophoneToolStripMenuItem;
        private Button playButton;
        private Button stopButton;
        private Label label14;
        private CheckBox isStereoCheckbox;
        private GUI.VolumeMeter leftVolumeMeter;
        private GUI.VolumeMeter rightVolumeMeter;
        private TabPage leftRightWaveformPage;
        private ScottPlot.WinForms.FormsPlot leftWaveformPlot;
        private ScottPlot.WinForms.FormsPlot rightWaveformPlot;
        private ScottPlot.WinForms.FormsPlot spectrumPlot;
        private GroupBox fftLimitsGroupBox;
        private TabPage eqWaveformPage;
        private ScottPlot.WinForms.FormsPlot highEQplot;
        private ScottPlot.WinForms.FormsPlot midEQplot;
        private ScottPlot.WinForms.FormsPlot lowEQplot;
        private GroupBox tunerGroupBox;
        private Label toneLabel;
        private Label timeElapsedLabel;
        private GUI.PrecisionSlider speedSlider;
        private GUI.PrecisionSlider pitchSlider;
        private GUI.PrecisionSlider timeSlider;
        private GUI.PrecisionSlider zoomSlider;
        private GUI.PrecisionSlider volumeSlider;
        private GUI.PrecisionSlider fftHzSlider;
        private GUI.PrecisionSlider fftDbSlider;
    }
}
