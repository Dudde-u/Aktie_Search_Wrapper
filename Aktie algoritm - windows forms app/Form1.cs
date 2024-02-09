using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aktie_algoritm___windows_forms_app;




namespace Aktie_algoritm___windows_forms_app
{


    public partial class Form1 : Form
    {

        HttpClient httpClient = new HttpClient();

        TickerSearchResponse TickerSearch = new TickerSearchResponse();

        IncomeStatementResponse IncomeStatement = new IncomeStatementResponse();

        BalanceSheetResponse BalanceSheet = new BalanceSheetResponse();

        GlobalQuoteResponse Globalquote = new GlobalQuoteResponse();

        bool demo = false; // for testing and not wasting API calls

        private string apiKey = "";

        public Form1()
        {

            InitializeComponent();
        }


        private async void btnSökAktie_Click(object sender, EventArgs e)
        {
            string intag = tbxSymbol.Text;

            await TickerSearch.SättaVärde(intag, apiKey, demo);
            try
            {
                LbxTickerSök.Items.Clear();
                LbxTickerSök.ClearSelected();
                //NullReferenceException fångas inte

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
            string symbol = TickerSearch.bestMatches[LbxTickerSök.SelectedIndex].symbol;

            try
            {
                string val = LbxTickerSök.SelectedItem.ToString();
                await HittaVärde(symbol, apiKey, val);
                //göra något med data
                tbxData.Text = "lyckat?";
            }
            catch (Exception ex)
            { MessageBox.Show("Exception caught: "+ex); }
        }
        async Task HittaVärde(string symbol, string apiKey, string requestType)
        {

            switch (requestType)
            {
               

                case "Income_Statement":
                    await IncomeStatement.SättaVärde(symbol, apiKey, demo);
                    break;
                case "Balance_Sheet":
                    await BalanceSheet.SättaVärde(symbol, apiKey, demo);
                    break;
                case "Ticker_Search":
                    await TickerSearch.SättaVärde(symbol, apiKey, demo);
                    break;
                case "Global_Quote":
                    await Globalquote.SättaVärde(symbol, apiKey, demo);
                    break;
                case "Market_status":

                    break;

            }

        }

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextCheck(tbxSymbol, btnSökAktie, 2);
           
        }
        private async void btnValidering_Click(object sender, EventArgs e)
        {

            string intag = tbxApiKey.Text;
            
            if (demo == false)
            {
                await HittaVärde("IBM", intag, "Income_Statement");
                
                if (IncomeStatement.success == true)
                {

                    MessageBox.Show("Lyckad validering");

                    gbxAktieSök.Enabled = true;
                
                    apiKey = intag;

                }
                else
                {
                    
                    //error
                    MessageBox.Show("ogiltig APIKEY, kontrollera att din APIKEY är korrekt");
                }
            }
            else
            {
                gbxAktieSök.Enabled = true;
              
                apiKey = intag;
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
                ut += $"Symbol: {TickerSearch.bestMatches[index].symbol} \r\n";
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

