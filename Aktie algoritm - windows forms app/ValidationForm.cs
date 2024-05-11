using Aktie_Logik;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_library;

namespace FormsSpace
{
    public partial class ValidationForm : Form
    {
        public ValidationForm(Form form)
        {
            InitializeComponent();
            mainWindow=form;
        }
        private readonly Form mainWindow;
       

        private async void btnValidering_Click(object sender, EventArgs e)
        {
            string prekey= tbxApiKey.Text;
             if (await ApiKeyHandler.ValidateAsync(prekey) == true &&prekey!=("demo"))
            {
                
                MessageBox.Show("The validation and saving of the key were successful", "Validation result", MessageBoxButtons.OK);

                File.WriteAllText("apiKeySave.txt",prekey);

                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Validation failed","Validation result", MessageBoxButtons.OK);
            }
        }
        private void tbxApiKey_TextChanged(object sender, EventArgs e) //semantics
        {
            
            if (tbxApiKey.Text.Length > 1)
            {
                btnValidering.Enabled = true;
            }
            else 
            {
            btnValidering.Enabled=false;
            }
        }
        private async void ValidationForm_Shown(object sender, EventArgs e) //pulls key from text document and validates it
        {
            try
            {
                string prekey = File.ReadAllText("../../../DATA/ApplicationData/apiKeySave.txt");

                if (prekey != null && await ApiKeyHandler.ValidateAsync(prekey) == true&&prekey.ToLower()!="demo")
                {
                    MessageBox.Show("Saved Key Validated");

                    this.Close();

                    mainWindow.Show();  
                }
            }
            catch { }
            tbxApiKey.Enabled = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            System.Diagnostics.Process.Start("https://www.alphavantage.co/support/#api-key");
        }
    }
    
}
