using AudioProcessing.Events;

namespace AudioProcessing
{
    public partial class SpeakerDialog : Form
    {
        // Instance
        private static SpeakerDialog _instance;
        public static SpeakerDialog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpeakerDialog();
                }
                return _instance;
            }
        }

        private int yWndOffset = 50;
        private int boundOffset = 1;

        private float position = 0;
        public float MembranePosition
        {
            get { return position; }
            set
            {
                position = value;
                Invalidate();
            }
        }

        // Events
        public void OnSpeakerUpdated(object? sender, ValueEventArgs<float> e)
        {
            MembranePosition = e.Value;
        }

        public SpeakerDialog()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Disegna la membrana
            using (var g = e.Graphics)
            {
                // Mappa la posizione della membrana da -1 a 1 a un intervallo Y specifico
                float mappedPosition = Map(-position + boundOffset, -1 + boundOffset, 1 + boundOffset, 5, Height - yWndOffset);

                // Linea orizzontale nera al centro
                g.DrawLine(new Pen(Pens.Black.Color, 2), 0, mappedPosition, Width, mappedPosition);
            }
        }

        private float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            float scaledValue = (value - fromSource) / (toSource - fromSource);
            return scaledValue * (toTarget - fromTarget) + fromTarget;
        }

        private void SpeakerDialog_Load(object sender, EventArgs e)
        {

        }

        private void SpeakerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
