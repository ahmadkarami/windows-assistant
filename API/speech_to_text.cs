using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Media.MediaHandlers;
using Ozeki.Media.MediaHandlers.Speech;
using System.Runtime.InteropServices;

namespace API
{
    public partial class speech_to_text : Form
    {
        [DllImport("kernel32.dll")]
        static extern int WinExec(string lpCmdLine, int uCmdShow);
        public speech_to_text()
        {
            InitializeComponent();
        }
        static Microphone microphone;
        static MediaConnector connector;
        static SpeechToText speechToText;   // creates a SpeechToText object
        private void button1_Click(object sender, EventArgs e)
        {
            microphone = Microphone.GetDefaultDevice();
            connector = new MediaConnector();

            SetupSpeechToText();    // calls the proper method to convert speech to text

            Console.ReadLine();
        }

        static void SetupSpeechToText()
        {
            string[] words = { "Hello", "notepad" };  // defines the words to be recognized

            speechToText = SpeechToText.CreateInstance(words);  // sets the speechToText object
            speechToText.WordRecognized += (SpeechToText_WordsRecognized);  // subscribes to get notified if a word is being recognized

            connector.Connect(microphone, speechToText);    // connects the microphone to the speech-to-text converter
            microphone.Start(); // starts the microphone
        }

        // this will be called, when a word is being recognized
        static void SpeechToText_WordsRecognized(object sender, SpeechDetectionEventArgs e)
        {
            WinExec(e.Word+".exe", 9);
        }


    }
}
