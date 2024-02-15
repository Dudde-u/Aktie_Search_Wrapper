using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;




namespace Aktie_algoritm___windows_forms_app
{


    public partial class Form1 : Form
    {

        HttpClient httpClient = new HttpClient();
        //instances are currently reused through the life of the application
        TickerSearchResponse TickerSearch = new TickerSearchResponse();

        IncomeStatementResponse IncomeStatement = new IncomeStatementResponse();

        BalanceSheetResponse BalanceSheet = new BalanceSheetResponse();

        GlobalQuoteResponse GlobalQuote = new GlobalQuoteResponse();
        OverviewResponse overview = new OverviewResponse();
        GlobalMarketResponse MarketState = new GlobalMarketResponse();
        TopLosersGainersResponse GainersLosers = new TopLosersGainersResponse();
        CashFlowResponse CashFlow = new CashFlowResponse();

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

        private void btnKör_Click(object sender, EventArgs e)
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
            { MessageBox.Show("Exception caught: "+ex); }
        }
        

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextCheck(tbxSymbol, btnSökAktie, 2);
           
        }
        private async void btnValidering_Click(object sender, EventArgs e)
        {
            //testing
            //await SetValue.Prepare( IncomeStatement, "IBM", "DEMO");
            // SetValue.SetObjectValue(ref IncomeStatement);
            // tbxData.Text += IncomeStatement.ic_annualReports[1].totalRevenue+"\n";
            // tbxData.Text += IncomeStatement.ic_annualReports[1].reportedCurrency + "\n";
            // tbxData.Text += IncomeStatement.ic_annualReports[1].otherNonOperatingIncome;

            string PreKey = tbxSymbol.Text;

            if (demo == true)
            {
                gbxAktieSök.Enabled = true;

                apiKey = "demo";
            }
            else
            {
                bool validationResult = await SetValue.Validate(PreKey);

                if (validationResult == true)
                {

                    MessageBox.Show("Lyckad validering");

                    gbxAktieSök.Enabled = true;

                    apiKey = PreKey;

                }
                else
                {

                    //error
                    MessageBox.Show("ogiltig APIKEY, kontrollera att din APIKEY är korrekt");
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

