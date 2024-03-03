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


        private async void btnSökAktie_Click(object sender, EventArgs e)
        {
            string intag = tbxSymbol.Text;
            
            TickerSearch=new TickerSearchResponse(apiKey,"Ticker_Search",intag);
            await TickerSearch.Initialize();
            
            TickerSearch = await ResponseHelper.SetObjectAsync<TickerSearchResponse>(TickerSearch,TickerSearch.Address);
            //TODO add jsonstring
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
                MessageBox.Show("nullvalue reference " + ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error: "+ex);
            }
            LbxTickerSök.Enabled = true;

        }

        private async void btnKör_Click(object sender, EventArgs e)
        {
            //string symbol = TickerSearch.bestMatches[LbxTickerSök.SelectedIndex].Symbol;
            string symbol = "";
            string reqType=lbxRequestType.SelectedItem.ToString();
           // string reqType = "Income_Statement";
            string outtext = "";
            try
            {
                // hitta värden här
                switch (reqType) 
                { //response manager needed -> very bad logic otherwise
                    case "Income_Statement":
                        IncomeStatementResponse response = new IncomeStatementResponse("demo", "Income_Statement", "IBM");
                        await response.Initialize();
                        response=await ResponseHelper.SetObjectAsync<IncomeStatementResponse>(response,response.Address);
                        
                        break;
                    case "Balance_Sheet":
                        BalanceSheetResponse balanceSheetResponse = new BalanceSheetResponse(apiKey, "Balance_Sheet", symbol);
                        await balanceSheetResponse.Initialize();
                        balanceSheetResponse=await ResponseHelper.SetObjectAsync<BalanceSheetResponse>(balanceSheetResponse, balanceSheetResponse.Address);
                        
                        break;
                    case "Global_Quote":
                        GlobalQuoteResponse globalQuoteResponse = new GlobalQuoteResponse(apiKey, "Global_Quote", symbol);
                        await globalQuoteResponse.Initialize();
                        globalQuoteResponse=await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(globalQuoteResponse, globalQuoteResponse.Address);
                        

                        break;
                        default:
                        MessageBox.Show("Internal logic issue");
                        break;
                }
                //göra något med data
               
            }
            catch (Exception ex)
            { MessageBox.Show("Exception caught: "+ex);}
        }
        

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextBoxStatus(tbxSymbol, btnSökAktie, 2);
           
        }
        private async void btnValidering_Click(object sender, EventArgs e)
        {
            string PreKey = tbxApiKey.Text;

            if (demo == true||PreKey.ToLower()=="demo")
            {
                gbxAktieSök.Enabled = true;

                apiKey = "demo";
                MessageBox.Show("The Application is now in demo mode");
            }
            else
            {
                bool validationResult = await ResponseHelper.ValidateAsync(PreKey);

                if (validationResult == true)
                {

                    MessageBox.Show("Key validation successful");

                    gbxAktieSök.Enabled = true;

                    apiKey = PreKey;

                }
                else
                {
                    //error
                    MessageBox.Show("Key validation unsuccessful");
                }
            }


        }

        private void tbxApiKey_TextChanged(object sender, EventArgs e)
        {

            TextBoxStatus(tbxApiKey, btnValidering, 3);
         
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

                lbxRequestType.Enabled = true;
            }
            else 
            {
            lbxRequestType.Enabled= false;
            }
            
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

        public void TextBoxStatus( TextBox textbox, Button button,int requiredLength)
        {

            if(textbox.Text.Length > requiredLength) 
            {
            button.Enabled = true;
            }
            else
            {
            button.Enabled = false; 
            
            }

        }

       
    }

}

