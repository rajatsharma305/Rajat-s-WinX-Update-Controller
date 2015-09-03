using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using Rajat_s_WinX_Update_Controller.Properties;

namespace Rajat_s_WinX_Update_Controller
{
    public partial class Form1 : Form
    {
        ServiceController sc = new ServiceController();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sc.ServiceName = "WSearch";
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                label1.Text = Resources.Form1_Form1_Load_Updates_Disabled;
                button2.Enabled = false;
            }
            if (sc.Status == ServiceControllerStatus.Running)
            {
                label1.Text = Resources.Form1_Form1_Load_Updates_Enabled;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                try
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    button2.Enabled = true;
                    button1.Enabled = false;
                    label1.Text = Resources.Form1_Form1_Load_Updates_Enabled;
                }
                catch (InvalidOperationException)
                {
                    label1.Text = Resources.Form1_button1_Click_Operation_Failed__Try_Again;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                try
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    button1.Enabled = true;
                    button2.Enabled = false;
                    label1.Text = Resources.Form1_Form1_Load_Updates_Disabled;
                }
                catch (InvalidOperationException)
                {
                    label1.Text = Resources.Form1_button1_Click_Operation_Failed__Try_Again;
                }
            }
        }
    }
}
