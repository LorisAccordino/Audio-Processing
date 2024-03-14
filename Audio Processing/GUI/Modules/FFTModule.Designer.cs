using AudioProcessing.Events;

namespace AudioProcessing.GUI.Modules
{
    partial class FFTModule
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
            tunerGroupBox = new GroupBox();
            toneLabel = new Label();
            fftLimitsGroupBox = new GroupBox();
            fftDbSlider = new GUI.PrecisionSlider();
            fftHzSlider = new GUI.PrecisionSlider();
            tunerGroupBox.SuspendLayout();
            fftLimitsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // tunerGroupBox
            // 
            tunerGroupBox.BackColor = SystemColors.Control;
            tunerGroupBox.Controls.Add(toneLabel);
            tunerGroupBox.Dock = DockStyle.Top;
            tunerGroupBox.Location = new Point(0, 0);
            tunerGroupBox.Name = "tunerGroupBox";
            tunerGroupBox.Size = new Size(144, 146);
            tunerGroupBox.TabIndex = 4;
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
            fftLimitsGroupBox.Location = new Point(0, 151);
            fftLimitsGroupBox.Name = "fftLimitsGroupBox";
            fftLimitsGroupBox.Size = new Size(144, 304);
            fftLimitsGroupBox.TabIndex = 3;
            fftLimitsGroupBox.TabStop = false;
            fftLimitsGroupBox.Text = "Max limits:";
            // 
            // fftDbSlider
            // 
            fftDbSlider.Location = new Point(68, 26);
            fftDbSlider.Maximum = 3F;
            fftDbSlider.Minimum = -39F;
            fftDbSlider.Name = "fftDbSlider";
            fftDbSlider.Orientation = Orientation.Vertical;
            fftDbSlider.Precision = 0.1F;
            fftDbSlider.PrecisionScale = GUI.PrecisionScale.Exponential;
            fftDbSlider.Size = new Size(62, 267);
            fftDbSlider.TabIndex = 6;
            fftDbSlider.Text = "precisionSlider2";
            fftDbSlider.TickFrequency = 15;
            fftDbSlider.Value = 3D;
            fftDbSlider.ValueAction = null;
            fftDbSlider.ValueSuffix = "dB";
            // 
            // fftHzSlider
            // 
            fftHzSlider.Location = new Point(1, 26);
            fftHzSlider.Maximum = 16F;
            fftHzSlider.Minimum = 1.5F;
            fftHzSlider.Name = "fftHzSlider";
            fftHzSlider.Orientation = Orientation.Vertical;
            fftHzSlider.PrecisionScale = GUI.PrecisionScale.Linear;
            fftHzSlider.Size = new Size(71, 267);
            fftHzSlider.TabIndex = 5;
            fftHzSlider.Text = "precisionSlider1";
            fftHzSlider.TickFrequency = 30;
            fftHzSlider.Value = 16D;
            fftHzSlider.ValueAction = null;
            fftHzSlider.ValueSuffix = "kHz";
            // 
            // FFTModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tunerGroupBox);
            Controls.Add(fftLimitsGroupBox);
            Name = "FFTModule";
            Size = new Size(144, 455);
            tunerGroupBox.ResumeLayout(false);
            fftLimitsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox tunerGroupBox;
        private Label toneLabel;
        private GroupBox fftLimitsGroupBox;
        private GUI.PrecisionSlider fftDbSlider;
        private GUI.PrecisionSlider fftHzSlider;

        #region Manually written code

        public override void InitializeEvents()
        {
            fftDbSlider.ValueAction = new Action<float>(value => audioProcessor.FFTplotter.MaxDbRange = value);
            fftHzSlider.ValueAction = new Action<float>(value => audioProcessor.FFTplotter.MaxHzRange = value * 1000);
            audioProcessor.FFTplotter.Tuner.ToneChangedAction = new ActionWithInvoke<string>(new Action<string>(value => toneLabel.Text = value), toneLabel);
        }

        public override void ResetComponent(bool enabled)
        {
            base.ResetComponent(enabled);

            // Reset values
            fftHzSlider.Value = 16000;
            fftDbSlider.Value = 3;
        }

        #endregion
    }
}
