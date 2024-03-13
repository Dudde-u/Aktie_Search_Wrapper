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

namespace Aktie_algoritm___windows_forms_app
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
             if (await ResponseHelper.ValidateAsync(prekey) == true &&prekey!=("demo"))//to remove
            {
                
                MessageBox.Show("Validation and save of key succesful", "Validation result", MessageBoxButtons.OK);

                File.WriteAllText("apiKeySave.txt",prekey);

                
                
            }
            else
            {
                MessageBox.Show("Validation failed","Validation result", MessageBoxButtons.OK);
            }
        }
        private void tbxApiKey_TextChanged(object sender, EventArgs e)
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
        private async void ValidationForm_Shown(object sender, EventArgs e)
        {
            try
            {
                string prekey = File.ReadAllText("apiKeySave.Txt");

                if (prekey != null && await ResponseHelper.ValidateAsync(prekey) == true)

                {
                    ApiKeyHandler.Key=prekey;
                    ApiKeyHandler.KeyIsValidated = true;
                    MessageBox.Show("Saved Key Validated");

                    this.Close();

                    mainWindow.Show();
                   
                }
                else
                {
                    this.Show();

                }
            }
            catch { }
            tbxApiKey.Enabled = true;
        }
    }
    
}
