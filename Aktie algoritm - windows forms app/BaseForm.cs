using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Aktie_algoritm___windows_forms_app;
using Class_library;

using System.Threading;





namespace Aktie_Logik
{


    public partial class BaseForm : Form
    {
        TickerSearchResponse TickerSearch;

        HttpClient httpClient = new HttpClient();
        //instances are currently reused through the life of the application
       
        

        bool demo = false; // for testing and not wasting API calls

       
        

        public BaseForm()
        {
          
            
            InitializeComponent();

            
        }


        private async void btnSökAktie_Click(object sender, EventArgs e)
        {
            string intag = tbxSymbol.Text;
           
            TickerSearch=new TickerSearchResponse(ApiKeyHandler.Key,intag);
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
            string symbol = TickerSearch.bestMatches[LbxTickerSök.SelectedIndex].Symbol;
        
            string reqType=lbxRequestType.SelectedItem.ToString();
         
            try
            {
                // hitta värden här++
                switch (reqType.Replace(' ','_') )
                { //response manager needed -> very bad logic otherwise
                    case "Income_Statement":
                        IncomeStatementResponse response = new IncomeStatementResponse(ApiKeyHandler.Key, symbol); //if not response and response.Address then its testing
                        await response.Initialize();
                        response=await ResponseHelper.SetObjectAsync<IncomeStatementResponse>(response,response.Address);
                        //this.Enabled = false;
                        IncomeStatementForm form = new IncomeStatementForm(response);
                        form.Show();
                        break;
                    case "Balance_Sheet":
                        BalanceSheetResponse balanceSheetResponse = new BalanceSheetResponse(ApiKeyHandler.Key, symbol);
                        await balanceSheetResponse.Initialize();
                        balanceSheetResponse=await ResponseHelper.SetObjectAsync<BalanceSheetResponse>(balanceSheetResponse, balanceSheetResponse.Address);
                        
                        break;
                    case "Global_Quote":
                        GlobalQuoteResponse globalQuoteResponse = new GlobalQuoteResponse(ApiKeyHandler.Key, symbol);
                        await globalQuoteResponse.Initialize();
                        globalQuoteResponse=await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(globalQuoteResponse, globalQuoteResponse.Address);
                        

                        break;
                        default:
                        MessageBox.Show("Internal logic issue");
                        break;
                }
                
               
            }
            catch (Exception ex)
            { MessageBox.Show("Exception caught: "+ex);}
        }
        

        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextBoxStatus(tbxSymbol, btnSökAktie, 2);
           
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
     

        private void BaseDataForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            SetupForm setupform = new SetupForm(this);
            setupform.Show();
        }

      

        private void BaseDataForm_VisibleChanged(object sender, EventArgs e)
        {
            if (ApiKeyHandler.KeyIsValidated)
            {
                gbxAktieSök.Enabled = true;
            }
            else
            {
               gbxAktieSök.Enabled=false;
            }
         
        }

        private void btnValidationOpen_Click(object sender, EventArgs e)
        {
            this.Hide();
            ValidationForm validationForm = new ValidationForm(this);
            validationForm.Show();
        }

        private async void btnMarketOpenClose_Click(object sender, EventArgs e)//todo
        {
            GlobalMarketResponse response = new GlobalMarketResponse(ApiKeyHandler.Key);
            await response.Initialize();
           await ResponseHelper.SetObjectAsync(response, response.Address);
            foreach( MarketData marketData in response.Markets)
            {
                string textOut = "";
                textOut += "Region: "+marketData.region + "\n";
                textOut +="Current Status: "+ marketData.current_status + "\n";
               
                lblMarketOpenClose.Text += textOut;
            }

        }

        private void lbxRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LbxTickerSök.SelectedIndex != -1&&lbxRequestType.SelectedIndex!=-1)
            {
                btnKör.Enabled = true;
            }
        }
    }

}

