using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TestStack.White.Factory;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.Speech.Synthesis;
using System.Speech.Synthesis.TtsEngine;

namespace API
{
    public partial class hazfe_zaban : Form
    {

        [DllImport("kernel32.dll")]
        static extern int WinExec(string lpCmdLine, int uCmdShow);

        public hazfe_zaban()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int prc_ID = 0;
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == "explorer")
                {
                    prc_ID = theprocess.Id;
                }
            }



            WinExec(@"control /name Microsoft.Language", 9);

            TestStack.White.Application app = TestStack.White.Application.Attach(prc_ID);


            TestStack.White.UIItems.WindowItems.Window window = app.GetWindow(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Language"), InitializeOption.NoCache);

            string s = comboBox1.Text;
            SendKeys.Send(s);

            TestStack.White.UIItems.Button button2 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Remove"));
            if (button2.Enabled == true)
            {
                button2.Click();
                TestStack.White.UIItems.Button button3 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Close"));
                button3.Click();
            }
            else
            {
                TestStack.White.UIItems.Button button4 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Close"));
                button4.Click();
            }
        }

        private void hazfe_zaban_Load(object sender, EventArgs e)
        {

            int prc_ID = 0;
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == "explorer")
                {
                    prc_ID = theprocess.Id;
                }
            }

            WinExec(@"control /name Microsoft.Language", 9);
            TestStack.White.Application app = TestStack.White.Application.Attach(prc_ID);


            TestStack.White.UIItems.WindowItems.Window window = app.GetWindow(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Language"), InitializeOption.NoCache);


            TestStack.White.UIItems.ListView lb = window.Get<TestStack.White.UIItems.ListView>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Languages enabled explorer"));

            foreach (TestStack.White.UIItems.ListViewRow item in lb.Rows)
            {
                comboBox1.Items.Add(item.Name);
            }

            TestStack.White.UIItems.Button button4 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Close"));
            button4.Click();
        }
    }
}
