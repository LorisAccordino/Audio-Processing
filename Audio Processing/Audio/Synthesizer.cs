using NAudio.Wave;
using static AudioProcessing.Audio.SignalFunction;

namespace AudioProcessing.Audio
{
    public class Synthesizer : ISampleProvider
    {
        private readonly object signalsLock = new object();
        private long sampleCounter = 0;
        private ListBox funcsList;

        public List<SignalFunction> signals = new List<SignalFunction>();
        public Synthesizer(ListBox funcsList, ComboBox signalComboBox)
        {
            this.funcsList = funcsList;

            PopulateComboBox(signalComboBox);

            AddFunction(new SignalFunction() { Signal = SignalType.Sine, Frequency = 440, Amplitude = 0.3 });

            funcsList.SelectedIndex = 0;
        }

        private void PopulateComboBox(ComboBox signalComboBox)
        {
            // Recupera tutti i valori dell'enum SignalType
            SignalType[] signalTypes = (SignalType[])Enum.GetValues(typeof(SignalType));

            // Aggiungi i valori alla ComboBox
            foreach (SignalType signalType in signalTypes)
            {
                signalComboBox.Items.Add(signalType);
            }

            // Imposta un valore predefinito se necessario
            signalComboBox.SelectedIndex = 0;
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

        public void EditFunction(int index, SignalType? funcType = null, double freq = -1, double amp = -1)
        {
            lock (signalsLock)
            {
                signals[index].Signal = funcType != null ? (SignalType)funcType : signals[index].Signal;
                signals[index].Frequency = freq != -1 ? freq : signals[index].Frequency;
                signals[index].Amplitude = amp != -1 ? amp : signals[index].Amplitude;
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

        public WaveFormat WaveFormat => AudioProcessor.WAVE_FORMAT;

        public int Read(float[] buffer, int offset, int count)
        {
            int bytes = 0;

            lock (signalsLock) 
            {
                bytes = count;
                sampleCounter += offset;

                for (int i = 0; i < count; i++)
                {
                    buffer[i] = 0;
                }

                foreach (var signal in signals)
                {
                    for (int i = 0; i < count; i++)
                    {
                        buffer[i] += (float)signal.GetValue((int)(i + sampleCounter));
                    }
                }

                sampleCounter += bytes;
            }
            
            return bytes;
        }
    }

    public class SignalFunction
    {
        public SignalType Signal { get; set; }
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
        public double Phase { get; set; }

        public double GetValue(int sample)
        {
            double normalizedFrequency = Frequency / AudioProcessor.SAMPLE_RATE;
            double radiansPerSample = Math.PI * normalizedFrequency;

            switch (Signal)
            {
                case SignalType.Sine:
                    return Amplitude * Math.Sin(radiansPerSample * sample + Phase);

                case SignalType.Cosine:
                    return Amplitude * Math.Cos(radiansPerSample * sample + Phase);

                case SignalType.Square:
                    return Amplitude * Math.Sign(Math.Sin(radiansPerSample * sample + Phase));

                case SignalType.Triangle:
                    double normalizedSample = (radiansPerSample * sample + Phase) % (2 * Math.PI);
                    return Amplitude * (2 / Math.PI) * Math.Asin(Math.Sin(normalizedSample));

                case SignalType.Sawtooth:
                    double normalizedSawtoothSample = (radiansPerSample * sample + Phase) % (2 * Math.PI);
                    return Amplitude * (2 / Math.PI) * (normalizedSawtoothSample - Math.PI);

                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return $"{Signal.ToString()}({Frequency} hz, A = {Amplitude}, Ph = {Phase})";
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
}
