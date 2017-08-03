using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestStack.White;
using System.Diagnostics;
using TestStack.White.Factory;
using System.Runtime.InteropServices;
using System.Windows.Input;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Custom;
//using TestStack.White.Mappings;
//using System.Windows.automation;

namespace API
{
    [ControlTypeMapping(CustomUIItemType.Pane)]
    [ControlTypeMapping(CustomUIItemType.Custom)]
    public partial class afzudan_zaban : Form
    {


        [DllImport("kernel32.dll")]
        static extern int WinExec(string lpCmdLine, int uCmdShow);
        



        public afzudan_zaban()
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

            TestStack.White.UIItems.Button button1 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Add a language"));
            button1.Click();

            string s = comboBox1.Text;
            SendKeys.Send(s);

            TestStack.White.UIItems.ListBoxItems.ListItem list = window.Get<TestStack.White.UIItems.ListBoxItems.ListItem>(TestStack.White.UIItems.Finders.SearchCriteria.ByText(s));
            list.Click();
            
            TestStack.White.UIItems.Button button2 = window.Get<TestStack.White.UIItems.Button>(TestStack.White.UIItems.Finders.SearchCriteria.ByText("Add"));
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
    }
}
