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
            volumeFader = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            volumeLabel = new Label();
            label3 = new Label();
            zoomSlider = new TrackBar();
            label4 = new Label();
            zoomLabel = new Label();
            pitchSlider = new TrackBar();
            playbackGroupBox = new GroupBox();
            label14 = new Label();
            stopButton = new Button();
            playButton = new Button();
            tempoLabel = new Label();
            label7 = new Label();
            tempoSlider = new TrackBar();
            pitchLabel = new Label();
            speedLabel = new Label();
            label6 = new Label();
            speedSlider = new TrackBar();
            label5 = new Label();
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
            tabControl = new TabControl();
            waveformPage = new TabPage();
            leftRightWaveformPage = new TabPage();
            leftWaveformPlot = new ScottPlot.WinForms.FormsPlot();
            rightWaveformPlot = new ScottPlot.WinForms.FormsPlot();
            spectrogramPage = new TabPage();
            groupBox1 = new GroupBox();
            fftHzLabel = new Label();
            fftDbLabel = new Label();
            label16 = new Label();
            label15 = new Label();
            fftDbTrackbar = new TrackBar();
            fftHzTrackbar = new TrackBar();
            spectrumPlot = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)volumeFader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zoomSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pitchSlider).BeginInit();
            playbackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tempoSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)speedSlider).BeginInit();
            eqGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            volumeGroupBox.SuspendLayout();
            tabControl.SuspendLayout();
            waveformPage.SuspendLayout();
            leftRightWaveformPage.SuspendLayout();
            spectrogramPage.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fftDbTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fftHzTrackbar).BeginInit();
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
            // volumeFader
            // 
            volumeFader.Location = new Point(188, 26);
            volumeFader.Maximum = 1500;
            volumeFader.Name = "volumeFader";
            volumeFader.Orientation = Orientation.Vertical;
            volumeFader.Size = new Size(56, 358);
            volumeFader.TabIndex = 4;
            volumeFader.TickFrequency = 175;
            volumeFader.Value = 1000;
            volumeFader.ValueChanged += volumeFader_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 5;
            label1.Text = "+3 dB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 354);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 6;
            label2.Text = "-40 dB";
            // 
            // volumeLabel
            // 
            volumeLabel.Location = new Point(171, 377);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(62, 25);
            volumeLabel.TabIndex = 7;
            volumeLabel.Text = "0 dB";
            volumeLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(232, 144);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 8;
            label3.Text = "0 dB";
            // 
            // zoomSlider
            // 
            zoomSlider.Location = new Point(81, 35);
            zoomSlider.Maximum = 200;
            zoomSlider.Minimum = 10;
            zoomSlider.Name = "zoomSlider";
            zoomSlider.Size = new Size(292, 56);
            zoomSlider.TabIndex = 9;
            zoomSlider.TickFrequency = 0;
            zoomSlider.Value = 10;
            zoomSlider.ValueChanged += zoomSlider_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 35);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 10;
            label4.Text = "Zoom:";
            // 
            // zoomLabel
            // 
            zoomLabel.AutoSize = true;
            zoomLabel.Location = new Point(379, 35);
            zoomLabel.Name = "zoomLabel";
            zoomLabel.Size = new Size(24, 20);
            zoomLabel.TabIndex = 11;
            zoomLabel.Text = "1x";
            // 
            // pitchSlider
            // 
            pitchSlider.Location = new Point(81, 97);
            pitchSlider.Maximum = 200;
            pitchSlider.Minimum = 50;
            pitchSlider.Name = "pitchSlider";
            pitchSlider.Size = new Size(292, 56);
            pitchSlider.TabIndex = 12;
            pitchSlider.TickFrequency = 0;
            pitchSlider.Value = 100;
            pitchSlider.ValueChanged += pitchSlider_ValueChanged;
            // 
            // playbackGroupBox
            // 
            playbackGroupBox.Controls.Add(label14);
            playbackGroupBox.Controls.Add(stopButton);
            playbackGroupBox.Controls.Add(playButton);
            playbackGroupBox.Controls.Add(tempoLabel);
            playbackGroupBox.Controls.Add(label7);
            playbackGroupBox.Controls.Add(tempoSlider);
            playbackGroupBox.Controls.Add(pitchLabel);
            playbackGroupBox.Controls.Add(speedLabel);
            playbackGroupBox.Controls.Add(label6);
            playbackGroupBox.Controls.Add(speedSlider);
            playbackGroupBox.Controls.Add(label5);
            playbackGroupBox.Controls.Add(zoomSlider);
            playbackGroupBox.Controls.Add(pitchSlider);
            playbackGroupBox.Controls.Add(label4);
            playbackGroupBox.Controls.Add(zoomLabel);
            playbackGroupBox.Location = new Point(12, 529);
            playbackGroupBox.Name = "playbackGroupBox";
            playbackGroupBox.Size = new Size(1076, 162);
            playbackGroupBox.TabIndex = 13;
            playbackGroupBox.TabStop = false;
            playbackGroupBox.Text = "Playback:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(856, 43);
            label14.Name = "label14";
            label14.Size = new Size(106, 20);
            label14.TabIndex = 23;
            label14.Text = "Playback state:";
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stopButton.Location = new Point(1022, 26);
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
            playButton.Location = new Point(968, 26);
            playButton.Name = "playButton";
            playButton.Size = new Size(48, 48);
            playButton.TabIndex = 21;
            playButton.Text = "⏵";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // tempoLabel
            // 
            tempoLabel.AutoSize = true;
            tempoLabel.Location = new Point(800, 97);
            tempoLabel.Name = "tempoLabel";
            tempoLabel.Size = new Size(24, 20);
            tempoLabel.TabIndex = 20;
            tempoLabel.Text = "1x";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(438, 97);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 19;
            label7.Text = "Time:";
            // 
            // tempoSlider
            // 
            tempoSlider.Location = new Point(502, 97);
            tempoSlider.Maximum = 200;
            tempoSlider.Minimum = 50;
            tempoSlider.Name = "tempoSlider";
            tempoSlider.Size = new Size(292, 56);
            tempoSlider.TabIndex = 18;
            tempoSlider.TickFrequency = 0;
            tempoSlider.Value = 100;
            tempoSlider.ValueChanged += tempoSlider_ValueChanged;
            // 
            // pitchLabel
            // 
            pitchLabel.AutoSize = true;
            pitchLabel.Location = new Point(379, 97);
            pitchLabel.Name = "pitchLabel";
            pitchLabel.Size = new Size(29, 20);
            pitchLabel.TabIndex = 17;
            pitchLabel.Text = "0%";
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Location = new Point(800, 35);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(24, 20);
            speedLabel.TabIndex = 16;
            speedLabel.Text = "1x";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(431, 35);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 15;
            label6.Text = "Speed:";
            // 
            // speedSlider
            // 
            speedSlider.Location = new Point(502, 35);
            speedSlider.Maximum = 200;
            speedSlider.Minimum = 30;
            speedSlider.Name = "speedSlider";
            speedSlider.Size = new Size(292, 56);
            speedSlider.TabIndex = 14;
            speedSlider.TickFrequency = 0;
            speedSlider.Value = 100;
            speedSlider.ValueChanged += speedSlider_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 97);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 13;
            label5.Text = "Pitch:";
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
            volumeGroupBox.Controls.Add(volumeLabel);
            volumeGroupBox.Controls.Add(volumeFader);
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
            isStereoCheckbox.Location = new Point(175, 471);
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
            label13.Location = new Point(162, 413);
            label13.Name = "label13";
            label13.Size = new Size(35, 20);
            label13.TabIndex = 12;
            label13.Text = "Pan:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(249, 443);
            label12.Name = "label12";
            label12.Size = new Size(18, 20);
            label12.TabIndex = 11;
            label12.Text = "R";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(206, 443);
            label11.Name = "label11";
            label11.Size = new Size(16, 20);
            label11.TabIndex = 10;
            label11.Text = "L";
            // 
            // panPot
            // 
            panPot.Location = new Point(208, 393);
            panPot.Margin = new Padding(4, 5, 4, 5);
            panPot.Maximum = 1D;
            panPot.Minimum = -1D;
            panPot.Name = "panPot";
            panPot.Size = new Size(54, 61);
            panPot.TabIndex = 9;
            panPot.Value = 0D;
            panPot.ValueChanged += panPot_ValueChanged;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(waveformPage);
            tabControl.Controls.Add(leftRightWaveformPage);
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
            leftWaveformPlot.Location = new Point(3, 2);
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
            // spectrogramPage
            // 
            spectrogramPage.Controls.Add(groupBox1);
            spectrogramPage.Controls.Add(spectrumPlot);
            spectrogramPage.Location = new Point(4, 29);
            spectrogramPage.Name = "spectrogramPage";
            spectrogramPage.Padding = new Padding(3);
            spectrogramPage.Size = new Size(1080, 457);
            spectrogramPage.TabIndex = 1;
            spectrogramPage.Text = "FFT Spectrogram";
            spectrogramPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(fftHzLabel);
            groupBox1.Controls.Add(fftDbLabel);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(fftDbTrackbar);
            groupBox1.Controls.Add(fftHzTrackbar);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(944, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(133, 451);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Max limits:";
            // 
            // fftHzLabel
            // 
            fftHzLabel.AutoSize = true;
            fftHzLabel.Location = new Point(55, 404);
            fftHzLabel.Name = "fftHzLabel";
            fftHzLabel.Size = new Size(71, 20);
            fftHzLabel.TabIndex = 5;
            fftHzLabel.Text = "20000 Hz";
            // 
            // fftDbLabel
            // 
            fftDbLabel.AutoSize = true;
            fftDbLabel.Location = new Point(6, 404);
            fftDbLabel.Name = "fftDbLabel";
            fftDbLabel.Size = new Size(39, 20);
            fftDbLabel.TabIndex = 4;
            fftDbLabel.Text = "3 dB";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(9, 37);
            label16.Name = "label16";
            label16.Size = new Size(27, 20);
            label16.TabIndex = 3;
            label16.Text = "dB";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(71, 37);
            label15.Name = "label15";
            label15.Size = new Size(27, 20);
            label15.TabIndex = 2;
            label15.Text = "Hz";
            // 
            // fftDbTrackbar
            // 
            fftDbTrackbar.Location = new Point(9, 60);
            fftDbTrackbar.Maximum = 380;
            fftDbTrackbar.Name = "fftDbTrackbar";
            fftDbTrackbar.Orientation = Orientation.Vertical;
            fftDbTrackbar.Size = new Size(56, 341);
            fftDbTrackbar.TabIndex = 1;
            fftDbTrackbar.TickFrequency = 15;
            fftDbTrackbar.Value = 380;
            fftDbTrackbar.ValueChanged += fftDbTrackbar_ValueChanged;
            // 
            // fftHzTrackbar
            // 
            fftHzTrackbar.Location = new Point(71, 60);
            fftHzTrackbar.Maximum = 200;
            fftHzTrackbar.Minimum = 140;
            fftHzTrackbar.Name = "fftHzTrackbar";
            fftHzTrackbar.Orientation = Orientation.Vertical;
            fftHzTrackbar.Size = new Size(56, 341);
            fftHzTrackbar.TabIndex = 0;
            fftHzTrackbar.TickFrequency = 2;
            fftHzTrackbar.Value = 200;
            fftHzTrackbar.ValueChanged += fftHzTrackbar_ValueChanged;
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
            ((System.ComponentModel.ISupportInitialize)volumeFader).EndInit();
            ((System.ComponentModel.ISupportInitialize)zoomSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pitchSlider).EndInit();
            playbackGroupBox.ResumeLayout(false);
            playbackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tempoSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)speedSlider).EndInit();
            eqGroupBox.ResumeLayout(false);
            eqGroupBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            volumeGroupBox.ResumeLayout(false);
            volumeGroupBox.PerformLayout();
            tabControl.ResumeLayout(false);
            waveformPage.ResumeLayout(false);
            leftRightWaveformPage.ResumeLayout(false);
            spectrogramPage.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fftDbTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)fftHzTrackbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot waveformPlot;
        private TrackBar volumeFader;
        private Label label1;
        private Label label2;
        private Label volumeLabel;
        private Label label3;
        private TrackBar zoomSlider;
        private Label label4;
        private Label zoomLabel;
        private TrackBar pitchSlider;
        private GroupBox playbackGroupBox;
        private Label label5;
        private TrackBar speedSlider;
        private Label label6;
        private Label speedLabel;
        private Label pitchLabel;
        private TrackBar tempoSlider;
        private Label label7;
        private Label tempoLabel;
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
        private GroupBox groupBox1;
        private TrackBar fftHzTrackbar;
        private TrackBar fftDbTrackbar;
        private Label label15;
        private Label label16;
        private Label fftDbLabel;
        private Label fftHzLabel;
    }
}
