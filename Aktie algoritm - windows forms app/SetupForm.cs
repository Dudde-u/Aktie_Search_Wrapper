using Aktie_Logik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSpace
{
    public partial class SetupForm : Form
    {

        private readonly Form mainWindow;
        public SetupForm(Form mainForm)
        {
            InitializeComponent();
            mainWindow = mainForm;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;

            
            System.Diagnostics.Process.Start("https://www.alphavantage.co/support/#api-key");
        }

        private void btnStartApp_Click(object sender, EventArgs e)
        {
            
            this.Close();
            mainWindow.Show();
        }
    }
}
