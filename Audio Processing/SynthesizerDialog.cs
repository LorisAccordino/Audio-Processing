using AudioProcessing.Audio;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static AudioProcessing.Audio.SignalFunction;
using AudioProcessing.Hooks;
using KeyDetectorNET;
using AudioProcessing.Common;

namespace AudioProcessing
{
    public partial class SynthesizerDialog : Form
    {
        public readonly Synthesizer synthesizer;

        public SynthesizerDialog()
        {
            InitializeComponent();

            synthesizer = new Synthesizer(fncList);

            List<SignalType> signalTypes = Utils.GetEnumValues<SignalType>();
            foreach (SignalType signalType in signalTypes)
            {
                synthFuncsCmbx.Items.Add(signalType);
            }
            synthFuncsCmbx.SelectedIndex = 0;

            freqNum.MouseWheel += numericUpDown_MouseWheel;
            ampNum.MouseWheel += numericUpDown_MouseWheel;
            phaseNum.MouseWheel += numericUpDown_MouseWheel;

            List<Keys> keys = [
                Keys.A /* C */, 
                Keys.W /* C# */,
                Keys.S /* D */,
                Keys.E /* D# */, 
                Keys.D /* E */,
                Keys.F /* F */,
                Keys.T /* F# */,
                Keys.G /* G */,
                Keys.Y /* G# */,
                Keys.H /* A */,
                Keys.U /* A# */,
                Keys.J /* B */,
                Keys.K /* C */,
            ];

            BuildKeyboard(13, keys);
        }

        private void BuildKeyboard(int numOfKeys, List<Keys> keys)
        {
            TabPage playPage = tabCtrl.TabPages[1];

            int keyCounter = 0;
            int xOffset = 20;
            int yOffset = 15;
            int keyWidth = 50;
            int keyHeight = 120;

            if (keys.Count < numOfKeys)
            {
                throw new ArgumentException("There must be a key code for every button!");
            }

            for (int i = 0; i < numOfKeys; i++)
            {
                bool naturalKey = IsNaturalKey(keyCounter);

                xOffset += naturalKey ? keyWidth : 0;

                Button key = BuildKey(keys[i], xOffset + (naturalKey ? 0 : keyWidth / 2), yOffset, i, naturalKey, keyWidth, keyHeight);
                playPage.Controls.Add(key);

                if (keyCounter > 10)
                {
                    keyCounter = 0;
                }
                else
                {
                    keyCounter++;
                }
            }

            foreach(Control control in playPage.Controls)
            {
                if (control is Button key)
                {
                    if (key.BackColor == Color.Black)
                    {
                        key.BringToFront();
                    }
                }
            }
        }

        private Button BuildKey(Keys keyCode, int x, int y, int noteIndex, bool isNatural, int width, int height)
        {
            Button key = new Button();
            key.Tag = new Note() { KeyCode = keyCode, noteIndex = noteIndex};
            key.Size = new Size(width, height - (isNatural ? 0 : 30));
            key.Location = new Point(x, y);
            key.BackColor = isNatural ? Color.White : Color.Black;

            key.MouseDown += (s, e) =>
            {
                if (key.Tag is Note note)
                {
                    OnKeyDown(new KeyEventArgs(note.KeyCode));
                }
            };

            key.MouseUp += (s, e) =>
            {
                if (key.Tag is Note note)
                {
                    OnKeyUp(new KeyEventArgs(note.KeyCode));
                }
            };

            return key;
        }

        private bool IsNaturalKey(int keyCounter)
        {
            if (keyCounter < 5)
            {
                return keyCounter % 2 == 0;
            }
            else if (keyCounter < 12)
            {
                return keyCounter % 2 == 1;
            }

            return true;
        }

        private void SynthesizerDialog_Load(object sender, EventArgs e)
        {
            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            KeyPreview = true;

            holdCheckbox.CheckedChanged += (sender, e) => { synthesizer.HoldNote = holdCheckbox.Checked; };
        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Button targetButton = FindButtonByKey(e.KeyCode);

            if (targetButton != null)
            {
                if (targetButton.Tag is Note note)
                {
                    if (!synthesizer.notes.Contains(note))
                    {
                        synthesizer.AddNote(note);
                    }
                }
            }

            Debug.WriteLine($"KEY PRESSED: {e.KeyCode}");
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            Button targetButton = FindButtonByKey(e.KeyCode);

            if (targetButton != null)
            {
                if (targetButton.Tag is Note note)
                {
                    if (synthesizer.notes.Contains(note))
                    {
                        synthesizer.RemoveNote(note);
                    }
                }
            }
        }

        private Button FindButtonByKey(Keys key)
        {
            TabPage playPage = tabCtrl.TabPages[1];

            foreach (Control control in playPage.Controls)
            {
                if (control is Button button)
                {
                    if (button.Tag is Note note)
                    {
                        if (note.KeyCode == key)
                        {
                            return button;
                        }
                    }
                }
            }
            return null;
        }

        private void fncList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fncList.SelectedIndex == -1 || synthesizer == null)
                return;

            synthFuncsCmbx.SelectedIndex = synthFuncsCmbx.FindString(synthesizer.signals[fncList.SelectedIndex].Signal.ToString());
            freqNum.Value = (decimal)synthesizer.signals[fncList.SelectedIndex].Frequency;
            ampNum.Value = (decimal)synthesizer.signals[fncList.SelectedIndex].Amplitude;
            phaseNum.Value = (decimal)synthesizer.signals[fncList.SelectedIndex].Phase;
        }

        public static void numericUpDown_MouseWheel(object? sender, MouseEventArgs e)
        {
            HandledMouseEventArgs handledArgs = (HandledMouseEventArgs)e;
            handledArgs.Handled = true;

            if (sender is NumericUpDown numericUpDown)
            {
                int delta = e.Delta / 120; // 120 is the default value for one notch of the mouse wheel

                if (delta > 0)
                {
                    // Scrolling up
                    numericUpDown.Value = Math.Min(numericUpDown.Maximum, numericUpDown.Value + numericUpDown.Increment);
                }
                else if (delta < 0)
                {
                    // Scrolling down
                    numericUpDown.Value = Math.Max(numericUpDown.Minimum, numericUpDown.Value - numericUpDown.Increment);
                }
            }
        }

        private void synthFuncsCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedItem != null)
                {
                    SignalType selectedSignal = (SignalType)Enum.Parse(typeof(SignalType), comboBox.SelectedItem.ToString());
                    synthesizer.EditFunction(fncList.SelectedIndex, funcType: selectedSignal);
                }
            }
        }

        private void freqNum_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.EditFunction(fncList.SelectedIndex, freq: (double)freqNum.Value);
        }

        private void ampNum_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.EditFunction(fncList.SelectedIndex, amp: (double)ampNum.Value);
        }

        private void phaseNum_ValueChanged(object sender, EventArgs e)
        {
            synthesizer.EditFunction(fncList.SelectedIndex, phase: (double)phaseNum.Value);
        }

        private void addSynth_Click(object sender, EventArgs e)
        {
            SignalType selectedSignal = (SignalType)Enum.Parse(typeof(SignalType), synthFuncsCmbx.SelectedItem.ToString());
            synthesizer.AddFunction(new SignalFunction() { Signal = selectedSignal, Frequency = (double)freqNum.Value, Amplitude = (double)ampNum.Value, Phase = (double)phaseNum.Value });
        }

        private void editSynth_Click(object sender, EventArgs e)
        {
            SignalType selectedSignal = (SignalType)Enum.Parse(typeof(SignalType), synthFuncsCmbx.SelectedItem.ToString());
            synthesizer.EditFunction(fncList.SelectedIndex, new SignalFunction() { Signal = selectedSignal, Frequency = (double)freqNum.Value, Amplitude = (double)ampNum.Value, Phase = 0.0 });
        }

        private void removeSynth_Click(object sender, EventArgs e)
        {
            synthesizer.RemoveFunction(fncList.SelectedIndex);
        }

        private void SynthesizerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
