namespace AudioProcessing
{
    partial class SynthesizerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fncList = new ListBox();
            editSynth = new Button();
            removeSynth = new Button();
            addSynth = new Button();
            synthFuncsCmbx = new ComboBox();
            ampNum = new NumericUpDown();
            freqNum = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            phaseNum = new NumericUpDown();
            tabCtrl = new TabControl();
            buildSynthPage = new TabPage();
            playSynthPage = new TabPage();
            holdCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)ampNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)freqNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)phaseNum).BeginInit();
            tabCtrl.SuspendLayout();
            buildSynthPage.SuspendLayout();
            playSynthPage.SuspendLayout();
            SuspendLayout();
            // 
            // fncList
            // 
            fncList.FormattingEnabled = true;
            fncList.Location = new Point(6, 15);
            fncList.Name = "fncList";
            fncList.Size = new Size(324, 164);
            fncList.TabIndex = 0;
            fncList.SelectedIndexChanged += fncList_SelectedIndexChanged;
            // 
            // editSynth
            // 
            editSynth.Location = new Point(421, 150);
            editSynth.Name = "editSynth";
            editSynth.Size = new Size(67, 29);
            editSynth.TabIndex = 34;
            editSynth.Text = "Edit";
            editSynth.UseVisualStyleBackColor = true;
            editSynth.Click += editSynth_Click;
            // 
            // removeSynth
            // 
            removeSynth.Location = new Point(494, 150);
            removeSynth.Name = "removeSynth";
            removeSynth.Size = new Size(76, 29);
            removeSynth.TabIndex = 33;
            removeSynth.Text = "Remove";
            removeSynth.UseVisualStyleBackColor = true;
            removeSynth.Click += removeSynth_Click;
            // 
            // addSynth
            // 
            addSynth.Location = new Point(348, 150);
            addSynth.Name = "addSynth";
            addSynth.Size = new Size(67, 29);
            addSynth.TabIndex = 32;
            addSynth.Text = "Add";
            addSynth.UseVisualStyleBackColor = true;
            addSynth.Click += addSynth_Click;
            // 
            // synthFuncsCmbx
            // 
            synthFuncsCmbx.DropDownStyle = ComboBoxStyle.DropDownList;
            synthFuncsCmbx.FormattingEnabled = true;
            synthFuncsCmbx.Location = new Point(450, 15);
            synthFuncsCmbx.Name = "synthFuncsCmbx";
            synthFuncsCmbx.Size = new Size(113, 28);
            synthFuncsCmbx.TabIndex = 37;
            synthFuncsCmbx.SelectedIndexChanged += synthFuncsCmbx_SelectedIndexChanged;
            // 
            // ampNum
            // 
            ampNum.DecimalPlaces = 3;
            ampNum.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            ampNum.Location = new Point(450, 82);
            ampNum.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            ampNum.Name = "ampNum";
            ampNum.Size = new Size(113, 27);
            ampNum.TabIndex = 36;
            ampNum.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            ampNum.ValueChanged += ampNum_ValueChanged;
            // 
            // freqNum
            // 
            freqNum.Location = new Point(450, 49);
            freqNum.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            freqNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            freqNum.Name = "freqNum";
            freqNum.Size = new Size(113, 27);
            freqNum.TabIndex = 35;
            freqNum.Value = new decimal(new int[] { 440, 0, 0, 0 });
            freqNum.ValueChanged += freqNum_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 18);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 38;
            label1.Text = "Function type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(365, 51);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 39;
            label2.Text = "Frequency:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 84);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 40;
            label3.Text = "Amplitude:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(374, 117);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 41;
            label4.Text = "Phase (π):";
            // 
            // phaseNum
            // 
            phaseNum.DecimalPlaces = 3;
            phaseNum.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            phaseNum.Location = new Point(450, 115);
            phaseNum.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            phaseNum.Name = "phaseNum";
            phaseNum.Size = new Size(113, 27);
            phaseNum.TabIndex = 42;
            phaseNum.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            phaseNum.ValueChanged += phaseNum_ValueChanged;
            // 
            // tabCtrl
            // 
            tabCtrl.Controls.Add(buildSynthPage);
            tabCtrl.Controls.Add(playSynthPage);
            tabCtrl.Location = new Point(12, 12);
            tabCtrl.Name = "tabCtrl";
            tabCtrl.SelectedIndex = 0;
            tabCtrl.Size = new Size(586, 226);
            tabCtrl.TabIndex = 43;
            // 
            // buildSynthPage
            // 
            buildSynthPage.Controls.Add(fncList);
            buildSynthPage.Controls.Add(phaseNum);
            buildSynthPage.Controls.Add(addSynth);
            buildSynthPage.Controls.Add(label4);
            buildSynthPage.Controls.Add(removeSynth);
            buildSynthPage.Controls.Add(label3);
            buildSynthPage.Controls.Add(editSynth);
            buildSynthPage.Controls.Add(label2);
            buildSynthPage.Controls.Add(freqNum);
            buildSynthPage.Controls.Add(label1);
            buildSynthPage.Controls.Add(ampNum);
            buildSynthPage.Controls.Add(synthFuncsCmbx);
            buildSynthPage.Location = new Point(4, 29);
            buildSynthPage.Name = "buildSynthPage";
            buildSynthPage.Padding = new Padding(3);
            buildSynthPage.Size = new Size(578, 193);
            buildSynthPage.TabIndex = 0;
            buildSynthPage.Text = "Build Synth";
            buildSynthPage.UseVisualStyleBackColor = true;
            // 
            // playSynthPage
            // 
            playSynthPage.Controls.Add(holdCheckbox);
            playSynthPage.Location = new Point(4, 29);
            playSynthPage.Name = "playSynthPage";
            playSynthPage.Padding = new Padding(3);
            playSynthPage.Size = new Size(578, 193);
            playSynthPage.TabIndex = 1;
            playSynthPage.Text = "Play Synth";
            playSynthPage.UseVisualStyleBackColor = true;
            // 
            // holdCheckbox
            // 
            holdCheckbox.AutoSize = true;
            holdCheckbox.Location = new Point(6, 163);
            holdCheckbox.Name = "holdCheckbox";
            holdCheckbox.Size = new Size(101, 24);
            holdCheckbox.TabIndex = 0;
            holdCheckbox.Text = "Hold Note";
            holdCheckbox.UseVisualStyleBackColor = true;
            // 
            // SynthesizerDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 246);
            Controls.Add(tabCtrl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SynthesizerDialog";
            Text = "Synthesizer";
            FormClosing += SynthesizerDialog_FormClosing;
            Load += SynthesizerDialog_Load;
            ((System.ComponentModel.ISupportInitialize)ampNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)freqNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)phaseNum).EndInit();
            tabCtrl.ResumeLayout(false);
            buildSynthPage.ResumeLayout(false);
            buildSynthPage.PerformLayout();
            playSynthPage.ResumeLayout(false);
            playSynthPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox fncList;
        private Button editSynth;
        private Button removeSynth;
        private Button addSynth;
        private ComboBox synthFuncsCmbx;
        private NumericUpDown ampNum;
        private NumericUpDown freqNum;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown phaseNum;
        private TabControl tabCtrl;
        private TabPage buildSynthPage;
        private TabPage playSynthPage;
        private CheckBox holdCheckbox;
    }
}