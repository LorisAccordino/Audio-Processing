namespace AudioProcessing.GUI.Modules
{
    partial class EqualizerModule
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
            eqGroupBox = new GroupBox();
            highPot = new GUI.PrecisionPot();
            midPot = new GUI.PrecisionPot();
            lowPot = new GUI.PrecisionPot();
            eqGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // eqGroupBox
            // 
            eqGroupBox.Controls.Add(highPot);
            eqGroupBox.Controls.Add(midPot);
            eqGroupBox.Controls.Add(lowPot);
            eqGroupBox.Dock = DockStyle.Fill;
            eqGroupBox.Location = new Point(0, 0);
            eqGroupBox.Name = "eqGroupBox";
            eqGroupBox.Size = new Size(310, 132);
            eqGroupBox.TabIndex = 24;
            eqGroupBox.TabStop = false;
            eqGroupBox.Text = "EQ:";
            // 
            // highPot
            // 
            highPot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            highPot.Location = new Point(191, 19);
            highPot.Maximum = 18D;
            highPot.Minimum = -18D;
            highPot.Name = "highPot";
            highPot.PotIndex = 2;
            highPot.ShowValue = true;
            highPot.Size = new Size(73, 95);
            highPot.TabIndex = 25;
            highPot.Text = "High";
            highPot.Value = 0D;
            highPot.ValueAction = null;
            highPot.ValueSuffix = " dB";
            // 
            // midPot
            // 
            midPot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            midPot.Location = new Point(116, 19);
            midPot.Maximum = 18D;
            midPot.Minimum = -18D;
            midPot.Name = "midPot";
            midPot.PotIndex = 1;
            midPot.ShowValue = true;
            midPot.Size = new Size(73, 95);
            midPot.TabIndex = 24;
            midPot.Text = "Mid";
            midPot.Value = 0D;
            midPot.ValueAction = null;
            midPot.ValueSuffix = " dB";
            // 
            // lowPot
            // 
            lowPot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lowPot.Location = new Point(41, 19);
            lowPot.Maximum = 18D;
            lowPot.Minimum = -18D;
            lowPot.Name = "lowPot";
            lowPot.PotIndex = 0;
            lowPot.ShowValue = true;
            lowPot.Size = new Size(73, 95);
            lowPot.TabIndex = 23;
            lowPot.Text = "Low";
            lowPot.Value = 0D;
            lowPot.ValueAction = null;
            lowPot.ValueSuffix = " dB";
            // 
            // EqualizerModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(eqGroupBox);
            Name = "EqualizerModule";
            Size = new Size(310, 132);
            eqGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion   

        private GroupBox eqGroupBox;
        private AudioProcessing.GUI.PrecisionPot highPot;
        private AudioProcessing.GUI.PrecisionPot midPot;
        private AudioProcessing.GUI.PrecisionPot lowPot;

        #region Manually written code

        public override void InitializeEvents()
        {
            lowPot.ValueAction = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, lowPot.PotIndex));
            midPot.ValueAction = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, midPot.PotIndex));
            highPot.ValueAction = new Action<float>(value => audioProcessor.Mixer.UpdateGain(value, highPot.PotIndex));
        }

        public override void ResetComponent(bool enabled)
        {
            base.ResetComponent(enabled);

            // Reset values
            lowPot.Value = 0;
            midPot.Value = 0;
            highPot.Value = 0;
        }

        #endregion
    }
}
