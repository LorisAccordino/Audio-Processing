using AudioProcessing.Common;

namespace AudioProcessing.GUI.Modules
{
    partial class PlotsModule
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
            tabControl = new TabControl();
            waveformPage = new TabPage();
            stereoPlot = new ScottPlot.WinForms.FormsPlot();
            leftRightWaveformPage = new TabPage();
            leftPlot = new ScottPlot.WinForms.FormsPlot();
            rightPlot = new ScottPlot.WinForms.FormsPlot();
            eqWaveformPage = new TabPage();
            highEQplot = new ScottPlot.WinForms.FormsPlot();
            midEQplot = new ScottPlot.WinForms.FormsPlot();
            lowEQplot = new ScottPlot.WinForms.FormsPlot();
            spectrogramPage = new TabPage();
            fftPanel = new Panel();
            spectrumPlot = new ScottPlot.WinForms.FormsPlot();
            tabControl.SuspendLayout();
            waveformPage.SuspendLayout();
            leftRightWaveformPage.SuspendLayout();
            eqWaveformPage.SuspendLayout();
            spectrogramPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(waveformPage);
            tabControl.Controls.Add(leftRightWaveformPage);
            tabControl.Controls.Add(eqWaveformPage);
            tabControl.Controls.Add(spectrogramPage);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1090, 510);
            tabControl.TabIndex = 27;
            // 
            // waveformPage
            // 
            waveformPage.Controls.Add(stereoPlot);
            waveformPage.Location = new Point(4, 29);
            waveformPage.Name = "waveformPage";
            waveformPage.Padding = new Padding(3);
            waveformPage.Size = new Size(1082, 477);
            waveformPage.TabIndex = 0;
            waveformPage.Text = "Waveform";
            waveformPage.UseVisualStyleBackColor = true;
            // 
            // stereoPlot
            // 
            stereoPlot.DisplayScale = 1.25F;
            stereoPlot.Dock = DockStyle.Fill;
            stereoPlot.Location = new Point(3, 3);
            stereoPlot.Name = "stereoPlot";
            stereoPlot.Size = new Size(1076, 471);
            stereoPlot.TabIndex = 0;
            // 
            // leftRightWaveformPage
            // 
            leftRightWaveformPage.Controls.Add(leftPlot);
            leftRightWaveformPage.Controls.Add(rightPlot);
            leftRightWaveformPage.Location = new Point(4, 29);
            leftRightWaveformPage.Name = "leftRightWaveformPage";
            leftRightWaveformPage.Size = new Size(1080, 457);
            leftRightWaveformPage.TabIndex = 2;
            leftRightWaveformPage.Text = "L / R Waveform";
            leftRightWaveformPage.UseVisualStyleBackColor = true;
            // 
            // leftPlot
            // 
            leftPlot.DisplayScale = 1.25F;
            leftPlot.Location = new Point(3, 3);
            leftPlot.Name = "leftPlot";
            leftPlot.Size = new Size(1078, 226);
            leftPlot.TabIndex = 1;
            // 
            // rightPlot
            // 
            rightPlot.DisplayScale = 1.25F;
            rightPlot.Location = new Point(3, 228);
            rightPlot.Name = "rightPlot";
            rightPlot.Size = new Size(1078, 226);
            rightPlot.TabIndex = 0;
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
            spectrogramPage.Controls.Add(fftPanel);
            spectrogramPage.Controls.Add(spectrumPlot);
            spectrogramPage.Location = new Point(4, 29);
            spectrogramPage.Name = "spectrogramPage";
            spectrogramPage.Padding = new Padding(3);
            spectrogramPage.Size = new Size(1080, 457);
            spectrogramPage.TabIndex = 1;
            spectrogramPage.Text = "FFT Spectrogram";
            spectrogramPage.UseVisualStyleBackColor = true;
            // 
            // fftPanel
            // 
            fftPanel.Dock = DockStyle.Fill;
            fftPanel.Location = new Point(944, 3);
            fftPanel.Name = "fftPanel";
            fftPanel.Size = new Size(133, 451);
            fftPanel.TabIndex = 1;
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
            // PlotsModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Name = "PlotsModule";
            Size = new Size(1090, 510);
            tabControl.ResumeLayout(false);
            waveformPage.ResumeLayout(false);
            leftRightWaveformPage.ResumeLayout(false);
            eqWaveformPage.ResumeLayout(false);
            spectrogramPage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage waveformPage;
        private ScottPlot.WinForms.FormsPlot stereoPlot;
        private TabPage leftRightWaveformPage;
        private ScottPlot.WinForms.FormsPlot leftPlot;
        private ScottPlot.WinForms.FormsPlot rightPlot;
        private TabPage eqWaveformPage;
        private ScottPlot.WinForms.FormsPlot highEQplot;
        private ScottPlot.WinForms.FormsPlot midEQplot;
        private ScottPlot.WinForms.FormsPlot lowEQplot;
        private TabPage spectrogramPage;
        private Panel fftPanel;
        private ScottPlot.WinForms.FormsPlot spectrumPlot;

        #region Manually written code

        public override void InitializeEvents()
        {
            SingletonManager<FFTModule>.GetInstance().InitializeEvents();
            tabControl.SelectedIndexChanged += audioProcessor.WaveformPlotter.UpdateCurrentPlotTab;
        }

        public override void ResetComponent(bool enabled)
        {
            base.ResetComponent(enabled);
            SingletonManager<FFTModule>.GetInstance().ResetComponent(enabled);

            // Reset values
            tabControl.SelectedIndex = 0;
            audioProcessor.WaveformPlotter.ClearAll();
            audioProcessor.FFTplotter.Clear();
        }

        #endregion
    }
}
