using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;





namespace Aktie_Logik
{


    public partial class Form1 : Form
    {
        TickerSearchResponse TickerSearch;

        HttpClient httpClient = new HttpClient();
        //instances are currently reused through the life of the application
       


        bool demo = false; // for testing and not wasting API calls

        private string apiKey = "";

        public Form1()
        {

            InitializeComponent();
        }


        private void btnSökAktie_Click(object sender, EventArgs e)
        {
            string intag = tbxSymbol.Text;
            
            
           
            try
            {
                LbxTickerSök.Items.Clear();
                LbxTickerSök.ClearSelected();
           

                for (int i = 0; i < TickerSearch.bestMatches.Count; i++)
                {
                    LbxTickerSök.Items.Add(TickerSearch.bestMatches[i].name);
                }
                

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("referens till nullvalue "+ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: "+ex);
            }
            LbxTickerSök.Enabled = true;

        }

        private async void btnKör_Click(object sender, EventArgs e)
        {
            string symbol = TickerSearch.bestMatches[LbxTickerSök.SelectedIndex].Symbol;

           
           
            try
            {
                string val = LbxTickerSök.SelectedItem.ToString();
                // hitta värden här


                //göra något med data
                tbxData.Text = "lyckat?";
            }
            catch (Exception ex)
            { MessageBox.Show("Exception caught: "+ex);}
        }
        

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextCheck(tbxSymbol, btnSökAktie, 2);
           
        }
        private async void btnValidering_Click(object sender, EventArgs e)
        {
            string PreKey = tbxApiKey.Text;

            if (demo == true)
            {
                gbxAktieSök.Enabled = true;

                apiKey = "demo";
            }
            else
            {
                bool validationResult = await SetValue.ValidateAsync(PreKey);

                if (validationResult == true)
                {

                    MessageBox.Show("Lyckad validering");

                    gbxAktieSök.Enabled = true;

                    apiKey = PreKey;

                }
                else
                {
                    //error
                    MessageBox.Show("ogiltig APIKEY, försök igen");
                }
            }


        }

        private void tbxApiKey_TextChanged(object sender, EventArgs e)
        {

            TextCheck(tbxApiKey, btnValidering, 3);
         
        }

        private void LbxTickerSök_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbxTickerSök.SelectedIndex != -1)
            {
                string ut = "";
                int index = LbxTickerSök.SelectedIndex;
                ut += $"Name: {TickerSearch.bestMatches[index].name} \r\n";
                ut += $"Symbol: {TickerSearch.bestMatches[index].Symbol} \r\n";
                ut += $"Region: {TickerSearch.bestMatches[index].region} \r\n";
                ut += $"Type: {TickerSearch.bestMatches[index].type} \r\n";
                ut += $"Currency: {TickerSearch.bestMatches[index].currency} \r\n";

                tbxTickerSearchInfo.Text = ut;

            }
            lbxRequestType.Enabled = true;
        }

        private void CheckBoxDemo_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxDemo.Checked==true)
            {
                demo = true;
            
            }
            else
            {
                demo = false;
                
            }
        }

        public void TextCheck( TextBox textbox, Button button,int Length)
        {

            if(textbox.Text.Length > Length) 
            {
            button.Enabled = true;
            }
            else
            {
            button.Enabled = false; 
            
            }

        }

        private void LbxTickerSök_SelectedValueChanged(object sender, EventArgs e)
        {
            tbxApiKey.Text = "lets go";
        }
    }

}

