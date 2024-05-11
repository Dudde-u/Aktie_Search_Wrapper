using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using FormsSpace;
using Class_library;

using System.Threading;
using System.Collections.Generic;





namespace Aktie_Logik
{


    public partial class BaseForm : Form
    {
        TickerSearchResponse TickerSearch;

        HttpClient httpClient = new HttpClient();

        //timer for rolling label
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Queue<Label> LabelQueue = new Queue<Label>();
        List<Label> LabelList = new List<Label>(); 
        public BaseForm()
        {
            timer.Interval = 5;
            timer.Tick+=timer_Tick;
            InitializeComponent();
        }   
        private void timer_Tick(object sender, EventArgs e) //shows the banner on the top of the form, there is a bug where global is showed twice
        {
            List<Label> delList = new List<Label>();
                Label label;
                if (LabelList.Count == 0)
                {
                    label = LabelQueue.Dequeue();
                    label.Visible = true;
                     LabelList.Add(label);
                }
                if (LabelList[LabelList.Count - 1].Location.X > LabelQueue.Peek().Width-150)
                {
                LabelList.Add(LabelQueue.Dequeue());
                LabelList[LabelList.Count - 1].Visible = true;
                }
                foreach (Label showLabel in LabelList)
                {
                    if (showLabel.Location.X > this.Width)
                    {
                   // showLabel.Visible = false;
                    showLabel.Location = new System.Drawing.Point(0 - showLabel.Width, this.Size.Height - 770);
                    showLabel.Visible = false;
                    LabelQueue.Enqueue(showLabel);
                    delList.Add(showLabel);
                     
                    }
                    else
                    {
                    int testheight = this.Size.Height - 100;
                    //tbxTest.Text += testheight + "\n";
                        showLabel.Location = new System.Drawing.Point(showLabel.Location.X + 1, testheight);
                    }

                } 
                foreach(Label removeLabel in delList)
                    {
                    LabelList.Remove(removeLabel);
                }
            
        }
        private async void btnSökAktie_Click(object sender, EventArgs e)
        {
            string intag = tbxSymbol.Text;
           
            TickerSearch=new TickerSearchResponse(ApiKeyHandler.Key,intag);
       
            
            await ResponseHelper.SetObjectAsync<TickerSearchResponse>(TickerSearch);
            TickerSearch.EnsureIsSet();

            try
            {
                LbxTickerSök.Items.Clear();
                LbxTickerSök.ClearSelected();

                for (int i = 0;  i < TickerSearch.bestMatches.Count; i++)
                {
                    LbxTickerSök.Items.Add(TickerSearch.bestMatches[i].name);
                }
            }
            catch (NullReferenceException)
            {
                
            }
            catch (Exception)
            {
               
            }
            LbxTickerSök.Enabled = true;

        }

        private async void btnKör_Click(object sender, EventArgs e)
        {
            string symbol = TickerSearch.bestMatches[LbxTickerSök.SelectedIndex].Symbol;

            try
            {
               
                switch (lbxRequestType.SelectedIndex)
                { 
                    case 0:
                        IncomeStatementResponse IncomeStatementResponse = new IncomeStatementResponse(ApiKeyHandler.Key,symbol); 
                      
                        await ResponseHelper.SetObjectAsync<IncomeStatementResponse>(IncomeStatementResponse);
                        IncomeStatementResponse.EnsureIsSet();
                        IncomeStatementForm IncomeStatementForm = new IncomeStatementForm(IncomeStatementResponse);
                        IncomeStatementForm.Show();
                        break;
                    case 1:
                      
                        BalanceSheetResponse balanceSheetResponse = new BalanceSheetResponse(ApiKeyHandler.Key, symbol);
                   
                        await ResponseHelper.SetObjectAsync<BalanceSheetResponse>(balanceSheetResponse);
                        balanceSheetResponse.EnsureIsSet();
                        BalanceSheetForm balanceSheetForm = new BalanceSheetForm(balanceSheetResponse);
                        balanceSheetForm.Show();

                        break;
                    case 2:
                        CashFlowResponse cashFlowResponse = new CashFlowResponse(ApiKeyHandler.Key, symbol);
                          
                        await ResponseHelper.SetObjectAsync<CashFlowResponse>(cashFlowResponse);
                        cashFlowResponse.EnsureIsSet();
                        CashFlowForm cashFlowForm = new CashFlowForm(cashFlowResponse);
                        cashFlowForm.Show();
                        break;
                    case 3:

                        throw new NotImplementedException();
                        


                        default:
                        throw new Exception();
                       
                }
                
               
            }
            catch (Exception)
            { }
        }
        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            TextBoxStatus(tbxSymbol, btnSökAktie, 2);
        }
        private async void LbxTickerSök_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxTickerSearchInfo.Text = "";
            tbxOverview.Text = "";
            int index = LbxTickerSök.SelectedIndex;
            if (index != -1)
            {
                try
                {
                    tbxTickerSearchInfo.Text += $"Name: {TickerSearch.bestMatches[index].name} \r\n";
                    tbxTickerSearchInfo.Text += $"Symbol: {TickerSearch.bestMatches[index].Symbol} \r\n";
                    tbxTickerSearchInfo.Text += $"Region: {TickerSearch.bestMatches[index].region} \r\n";
                    tbxTickerSearchInfo.Text += $"Type: {TickerSearch.bestMatches[index].type} \r\n";
                    tbxTickerSearchInfo.Text += $"Currency: {TickerSearch.bestMatches[index].currency} \r\n";

                    GlobalQuoteResponse globalQuoteresponse = new GlobalQuoteResponse(ApiKeyHandler.Key, TickerSearch.bestMatches[index].Symbol);
                    OverviewResponse overviewResponse = new OverviewResponse(ApiKeyHandler.Key, TickerSearch.bestMatches[index].Symbol);

                    //fix this async

                   await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(globalQuoteresponse);
                    await ResponseHelper.SetObjectAsync<OverviewResponse>(overviewResponse);
                    globalQuoteresponse.EnsureIsSet();
                    overviewResponse.EnsureIsSet();

                
                   tbxOverview.Text += $"{overviewResponse.Description}\r\n"; 
                    tbxTickerSearchInfo.Text += "Price: " + globalQuoteresponse.GlobalQuote._05price+ " (" + TickerSearch.bestMatches[index].currency+")";
                    tbxOverview.Text +=$"P/E ratio: {overviewResponse.PERatio}\r\n";
                    tbxOverview.Text += $"Profit margin: {overviewResponse.ProfitMargin}\r\n";
                    tbxOverview.Text += $"Market capitalization: {overviewResponse.MarketCapitalization}\r\n";
                    tbxOverview.Text+=$"Dividend yield: {overviewResponse.DividendYield}\r\n";
                    tbxOverview.Text += $"Beta : {overviewResponse.Beta}\r\n";
                    tbxOverview.Text += $"ebidta: {overviewResponse.EBITDA}\r\n";
                    tbxOverview.Text += $"Analyst target price: {overviewResponse.AnalystTargetPrice}\r\n";
                    lbxRequestType.Enabled = true;
                }
                catch (Exception)
                {
                 
                }
            }
            else 
            {
            lbxRequestType.Enabled= false;
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

      

        private async void BaseDataForm_VisibleChanged(object sender, EventArgs e)
        {
            timer.Stop();
            if (ApiKeyHandler.KeyIsValidated&&this.Visible==true)
            {
                
                gbxAktieSök.Enabled = true;

                LabelQueue.Clear();

                GlobalMarketResponse marketResponse = new GlobalMarketResponse(ApiKeyHandler.Key);
           

             
                await ResponseHelper.SetObjectAsync<GlobalMarketResponse>(marketResponse);

                try
                {
                    foreach (MarketData marketData in marketResponse.Markets)
                    {
                        Label Bannerlabel = new Label();
                        Bannerlabel.AutoSize = true;
                        Bannerlabel.Visible = false;
                        Bannerlabel.Text = "Region: " + marketData.region + "   Current Status: " + marketData.current_status;
                        Bannerlabel.Location = new System.Drawing.Point(80 - Bannerlabel.Width - 140, this.Size.Height);
                        this.Controls.Add(Bannerlabel);
                        LabelQueue.Enqueue(Bannerlabel);
                    }


                    timer.Start();
                }
                catch (Exception) { }
               
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

   

        private void lbxRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LbxTickerSök.SelectedIndex != -1&&lbxRequestType.SelectedIndex!=-1)
            {
                btnKör.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Archival.ClearAllStockData();
            MessageBox.Show("All data has been cleared");
        }
    }

}

