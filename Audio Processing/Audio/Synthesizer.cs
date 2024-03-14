using NAudio.Wave;
using static AudioProcessing.Audio.SignalFunction;

namespace AudioProcessing.Audio
{
    public class Synthesizer : ISampleProvider
    {
        public bool HoldNote { get; set; } = false;
        public float Pitch { get; set; } = 1.0f;

        private readonly object signalsLock = new object();
        private readonly object notesLock = new object();

        private long sampleCounter = 0;
        private ListBox funcsList;

        public List<Note> notes = new List<Note>();
        public List<SignalFunction> signals = new List<SignalFunction>();
        public Synthesizer(ListBox funcsList)
        {
            this.funcsList = funcsList;

            AddFunction(new SignalFunction() { Signal = SignalType.Sine, Frequency = 440, Amplitude = 0.3 });

            funcsList.SelectedIndex = 0;
        }

        public void AddFunction(SignalFunction signal)
        {
            lock (signalsLock)
            {
                signals.Add(signal);
                funcsList.Items.Add(signal.ToString());
            }
        }

        public void EditFunction(int index, SignalFunction signal)
        {
            lock (signalsLock)
            {
                signals[index] = signal;
                funcsList.Items[index] = signal.ToString();
            }
        }

        public void EditFunction(int index, SignalType? funcType = null, double freq = -1, double amp = -1, double phase = -1)
        {
            lock (signalsLock)
            {
                signals[index].Signal = funcType != null ? (SignalType)funcType : signals[index].Signal;
                signals[index].Frequency = freq != -1 ? freq : signals[index].Frequency;
                signals[index].Amplitude = amp != -1 ? amp : signals[index].Amplitude;
                signals[index].Phase = phase != -1 ? phase : signals[index].Phase;
                funcsList.Items[index] = signals[index].ToString();
            }
        }

        public void RemoveFunction(SignalFunction signal)
        {
            lock (signalsLock)
            {
                signals.Remove(signal);
                funcsList.Items.Remove(signal.ToString());
                funcsList.SelectedIndex = 0;
            }
        }

        public void RemoveFunction(int index)
        {
            lock (signalsLock)
            {
                signals.RemoveAt(index);
                funcsList.Items.RemoveAt(index);
                funcsList.SelectedIndex = 0;
            }
        }

        public void AddNote(Note note)
        {
            lock (notesLock)
            {
                notes.Add(note);
            }
        }

        public void RemoveNote(Note note)
        {
            lock (notesLock)
            {
                notes.Remove(note);
            }
        }

        public WaveFormat WaveFormat => AudioProcessor.WAVE_FORMAT;

        public int Read(float[] buffer, int offset, int count)
        {
            int bytes = 0;
            bytes = count;
            sampleCounter += offset;

            for (int i = 0; i < count; i++)
            {
                buffer[i] = 0;
            }

            if (!HoldNote)
            {
                lock (notesLock)
                {
                    foreach (Note note in notes)
                    {
                        float notePitch = (float)Math.Pow(2, note.noteIndex / 12f);

                        lock (signalsLock)
                        {
                            foreach (var signal in signals)
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    buffer[i] += (float)signal.GetValue((int)(i + sampleCounter), Pitch * notePitch) / notes.Count;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var signal in signals)
                {
                    for (int i = 0; i < count; i++)
                    {
                        buffer[i] += (float)signal.GetValue((int)(i + sampleCounter), Pitch);
                    }
                }
            }
            sampleCounter += bytes;

            return bytes;
        }
    }

    public class SignalFunction
    {
        public SignalType Signal { get; set; }
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
        public double Phase { get; set; }

        public double GetValue(int sample, float pitch)
        {
            double normalizedFrequency = (Frequency * pitch) / AudioProcessor.SAMPLE_RATE;
            double radiansPerSample = Math.PI * normalizedFrequency;
            double phaseInRadians = Phase * Math.PI;

            switch (Signal)
            {
                case SignalType.Sine:
                    return Amplitude * Math.Sin(radiansPerSample * sample + phaseInRadians);

                case SignalType.Cosine:
                    return Amplitude * Math.Cos(radiansPerSample * sample + phaseInRadians);

                case SignalType.Square:
                    return Amplitude * Math.Sign(Math.Sin(radiansPerSample * sample + phaseInRadians));

                case SignalType.Triangle:
                    double normalizedSample = (radiansPerSample * sample + phaseInRadians) % (2 * Math.PI);
                    return Amplitude * (2 / Math.PI) * Math.Asin(Math.Sin(normalizedSample));

                /*case SignalType.Sawtooth:
                    double normalizedSawtoothSample = (radiansPerSample * sample + phaseInRadians) % (2 * Math.PI);
                    return Amplitude * (2 / Math.PI) * (normalizedSawtoothSample - Math.PI);*/
                /*case SignalType.Sawtooth:
                    double normalizedSawtoothSample = ((radiansPerSample * sample + phaseInRadians) % (2 * Math.PI)) / (2 * Math.PI);
                    return Amplitude * (normalizedSawtoothSample - Math.Floor(normalizedSawtoothSample + 0.5));*/
                case SignalType.Sawtooth:
                    double normalizedSawtoothSample = ((radiansPerSample * sample + phaseInRadians) % (2 * Math.PI)) / (2 * Math.PI);
                    double shiftedSawtoothSample = normalizedSawtoothSample + 0.5 - Math.Floor(normalizedSawtoothSample + 0.5);
                    return Amplitude * (2 * shiftedSawtoothSample - 1);

                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return $"{Signal}({Frequency} hz, A = {Amplitude}, Ph = {Phase})";
        }

        public enum SignalType
        {
            Sine,
            Cosine,
            Square,
            Triangle,
            Sawtooth,
        }
    }

    public struct Note
    {
        public Keys KeyCode;
        public int noteIndex;
    }
}
