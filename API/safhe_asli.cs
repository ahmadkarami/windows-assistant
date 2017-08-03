using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.InputDevices;
using Castle.Core;
using Castle.DynamicProxy;
using TestStack.White.UIItems.Finders;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.Actions;

namespace API
{
    [ControlTypeMapping(CustomUIItemType.TabItem)]
    public partial class safhe_asli : Form
    {
        
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, string buffer, int bufferSize, IntPtr hwndCallback);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int GetProcessId(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("kernel32.dll")]
        static extern int WinExec(string lpCmdLine, int uCmdShow);


        
        public safhe_asli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            afzudan_zaban f2 = new afzudan_zaban();
            f2.Show();              
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Open
            mciSendString("set CDAudio door open", "", 127, IntPtr.Zero);

           // rkApp.DeleteValue("API", false);
            //rkApp.SetValue("API", System.Windows.Forms.Application.ExecutablePath.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hazfe_zaban f = new hazfe_zaban();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            speech_to_text f = new speech_to_text();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            text_to_speech ts = new text_to_speech();
            ts.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int prc_ID = 0;
            WinExec("control intl.cpl,,2", 9);
            Thread.Sleep(500);
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName == "rundll32")
                {
                    prc_ID = theprocess.Id;
                }
            }
            
          
            
           TestStack.White.Application app = TestStack.White.Application.Attach(prc_ID);
           TestStack.White.UIItems.WindowItems.Window window = app.GetWindow(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Region"), InitializeOption.NoCache);
           TestStack.White.UIItems.Button C = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Change system locale..."));
           C.Click();
           // 

           SendKeys.Send("spanish");
           SendKeys.Send("{Enter}");        

        }

    }
}
