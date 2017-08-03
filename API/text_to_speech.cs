using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;

namespace API
{
    public partial class text_to_speech : Form
    {
        public text_to_speech()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpVoice objspeech = new SpVoice();
            objspeech.Speak(textBox1.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
            
           // objspeech.WaitUntilDone(5000);
        }
    }
}
