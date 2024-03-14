using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KeyDetectorNET
{
    public class KeyDetectorEventArgs
    {
        public Keys Key { get; private set; }
        public KeyDetectorEventArgs(Keys key)
        {
            this.Key = key;
        }
    }
}
