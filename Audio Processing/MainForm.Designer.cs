namespace AudioProcessing
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            wavTSMI = new ToolStripMenuItem();
            synthTSMI = new ToolStripMenuItem();
            showSpeakerToolStripMenuItem = new ToolStripMenuItem();
            audioOpenFileDialog = new OpenFileDialog();
            playbackPanel = new Panel();
            volumePanel = new Panel();
            equalizerPanel = new Panel();
            plotsPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wavTSMI, synthTSMI, showSpeakerToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(56, 24);
            fileToolStripMenuItem.Text = "Tasks";
            // 
            // wavTSMI
            // 
            wavTSMI.Name = "wavTSMI";
            wavTSMI.ShortcutKeys = Keys.Control | Keys.O;
            wavTSMI.Size = new Size(258, 26);
            wavTSMI.Text = "Import WAV";
            wavTSMI.Click += wavTSMI_Click;
            // 
            // synthTSMI
            // 
            synthTSMI.Name = "synthTSMI";
            synthTSMI.ShortcutKeys = Keys.Control | Keys.S;
            synthTSMI.Size = new Size(258, 26);
            synthTSMI.Text = "Start Synthesizer";
            synthTSMI.Click += synthTSMI_Click;
            // 
            // showSpeakerToolStripMenuItem
            // 
            showSpeakerToolStripMenuItem.Name = "showSpeakerToolStripMenuItem";
            showSpeakerToolStripMenuItem.Size = new Size(258, 26);
            showSpeakerToolStripMenuItem.Text = "Show Speaker Animation";
            showSpeakerToolStripMenuItem.Click += showSpeakerToolStripMenuItem_Click;
            // 
            // audioOpenFileDialog
            // 
            audioOpenFileDialog.Filter = "File WAV|*.wav";
            // 
            // playbackPanel
            // 
            playbackPanel.Location = new Point(4, 525);
            playbackPanel.Name = "playbackPanel";
            playbackPanel.Size = new Size(1089, 172);
            playbackPanel.TabIndex = 27;
            // 
            // volumePanel
            // 
            volumePanel.Location = new Point(1099, 33);
            volumePanel.Name = "volumePanel";
            volumePanel.Size = new Size(300, 510);
            volumePanel.TabIndex = 28;
            // 
            // equalizerPanel
            // 
            equalizerPanel.Location = new Point(1099, 547);
            equalizerPanel.Name = "equalizerPanel";
            equalizerPanel.Size = new Size(300, 144);
            equalizerPanel.TabIndex = 29;
            // 
            // plotsPanel
            // 
            plotsPanel.Location = new Point(4, 33);
            plotsPanel.Name = "plotsPanel";
            plotsPanel.Size = new Size(1094, 495);
            plotsPanel.TabIndex = 30;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1416, 703);
            Controls.Add(plotsPanel);
            Controls.Add(equalizerPanel);
            Controls.Add(volumePanel);
            Controls.Add(playbackPanel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Audio Processing - C#";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem wavTSMI;
        private OpenFileDialog audioOpenFileDialog;
        private ToolStripMenuItem synthTSMI;
        private ToolStripMenuItem showSpeakerToolStripMenuItem;
        private Panel playbackPanel;
        private Panel volumePanel;
        private Panel equalizerPanel;
        private Panel plotsPanel;
    }
}
