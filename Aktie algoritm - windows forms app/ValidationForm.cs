using System;
using System.IO;
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
            tbxApiKey.KeyDown += new KeyEventHandler(TB_KeyDown);
          
        }
        private readonly Form mainWindow;
       
        private bool Savekey { get; set; }
        private async Task ValidateKey()
        {
            string prekey = tbxApiKey.Text;
            if (await ApiKeyHandler.ValidateAsync(prekey) == true && prekey != ("demo"))
            {
                string message = "The validation of the key was successful";
                if (Savekey==true)
                {
                    message = "The validation and saving of the key were successful";

                    File.WriteAllText("apiKeySave.txt", prekey);
                }

                MessageBox.Show(message, "Validation result", MessageBoxButtons.OK);

                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Validation failed", "Validation result", MessageBoxButtons.OK);
            }
        }

        private async void TB_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if(sender is TextBox)
                    {
                        await ValidateKey();

                    }
                }
                catch (Exception) { }
            
            }
            
        }
    
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
            System.Diagnostics.Process.Start("https://www.alphavantage.co/support/#api-key");
        }
        

        private void returnToMainPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }
    }
    
}
