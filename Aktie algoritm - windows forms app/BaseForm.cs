using ClassLibrary;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsSpace;
using Class_library;
using System.Collections.Generic;
using Label = System.Windows.Forms.Label;
using static ClassLibrary.CashFlowResponse;






namespace Aktie_Logik
{


    public partial class BaseForm : Form
    {
        TickerSearchResponse TickerSearch;

        HttpClient httpClient = new HttpClient();

        //timer for rolling label
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Queue<Label> NonMovingQueue = new Queue<Label>();
        List<Label> MovingList = new List<Label>(); 
        public BaseForm()
        {
            timer.Interval = 5;
            timer.Tick+=timer_Tick;
            InitializeComponent();
        }   
        private void timer_Tick(object sender, EventArgs e) //shows the banner on the bottom of the form, there is a bug where global is showed twice
        {
            if (MovingList[MovingList.Count - 1].Location.X > 100)
            {
                MovingList.Add(NonMovingQueue.Dequeue());
                MovingList[MovingList.Count - 1].Visible = true;
            }

            if (MovingList[0].Location.X > this.Width)
            {

                MovingList[0].Visible = false;
                MovingList[0].Location = new System.Drawing.Point((-MovingList[0].Width)-60,0);
               
                NonMovingQueue.Enqueue(MovingList[0]);
                MovingList.Remove(MovingList[0]);

            }

            int height = this.Size.Height - 100;

            for (int i = 0; i < MovingList.Count; i++)
            {
                MovingList[i].Location = new System.Drawing.Point(MovingList[i].Location.X + 1, height);
            }
          
            
        }
        private async void btnSökAktie_Click(object sender, EventArgs e)
        {
            
            
            string intag = tbxSymbol.Text;
           
            TickerSearch=new TickerSearchResponse(ApiKeyHandler.Key,intag);



                await ResponseHelper.SetObjectAsync<TickerSearchResponse>(TickerSearch);

            if (TickerSearch.isSet == true)
            {
                try
                {
                    LbxTickerSök.Items.Clear();
                    LbxTickerSök.ClearSelected();

                    for (int i = 0; i < TickerSearch.bestMatches.Count; i++)
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
            else
            {
               tbxTickerSearchInfo.Text = "No matches found";
            }
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


                        if (IncomeStatementResponse.isSet == true)
                        {
                            IncomeStatementForm IncomeStatementForm = new IncomeStatementForm(IncomeStatementResponse);
                            IncomeStatementForm.Show();
                        }else
                                                    {
                            MessageBox.Show("No data found for "+ IncomeStatementResponse.Symbol);
                        }
                        break;
                    case 1:
                      
                        BalanceSheetResponse balanceSheetResponse = new BalanceSheetResponse(ApiKeyHandler.Key, symbol);
                   
                        await ResponseHelper.SetObjectAsync<BalanceSheetResponse>(balanceSheetResponse);
                       if(balanceSheetResponse.isSet ==true)
                        {
                            BalanceSheetForm balanceSheetForm = new BalanceSheetForm(balanceSheetResponse);
                            balanceSheetForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("No data found for " + balanceSheetResponse.Symbol);
                        }                  
                      

                        break;
                    case 2:
                        CashFlowResponse cashFlowResponse = new CashFlowResponse(ApiKeyHandler.Key, symbol);
                          
                        await ResponseHelper.SetObjectAsync<CashFlowResponse>(cashFlowResponse);
                        if (cashFlowResponse.isSet == true)

                        {
                            CashFlowForm cashFlowForm = new CashFlowForm(cashFlowResponse);
                            cashFlowForm.Show();
                        }
                        else { 
                            MessageBox.Show("No data found for " + cashFlowResponse.Symbol);
                        }
                            break;
                  
                    

                    default:
                        MessageBox.Show("Something went wrong");
                        break;
                    

                       
                }
                
               
            }
            catch (Exception)
            { }
        }
        private void tbxSymbol_TextChanged(object sender, EventArgs e)
        {
            if(tbxSymbol.Text.Length>1)
            {
                btnSökAktie.Enabled = true;
            }
            else
            {
                btnSökAktie.Enabled = false;
            }
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
                    if (TickerSearch.isSet == true)
                    {
                        tbxTickerSearchInfo.Text += $"Name: {TickerSearch.bestMatches[index].name} \r\n";
                        tbxTickerSearchInfo.Text += $"Symbol: {TickerSearch.bestMatches[index].Symbol} \r\n";
                        tbxTickerSearchInfo.Text += $"Region: {TickerSearch.bestMatches[index].region} \r\n";
                        tbxTickerSearchInfo.Text += $"Type: {TickerSearch.bestMatches[index].type} \r\n";
                        tbxTickerSearchInfo.Text += $"Currency: {TickerSearch.bestMatches[index].currency} \r\n";

                        lbxRequestType.Enabled = true;
                    }
                    GlobalQuoteResponse globalQuoteresponse = new GlobalQuoteResponse(ApiKeyHandler.Key, TickerSearch.bestMatches[index].Symbol);
                    OverviewResponse overviewResponse = new OverviewResponse(ApiKeyHandler.Key, TickerSearch.bestMatches[index].Symbol);

                    

                   await ResponseHelper.SetObjectAsync<GlobalQuoteResponse>(globalQuoteresponse);
                    await ResponseHelper.SetObjectAsync<OverviewResponse>(overviewResponse);




                    if (globalQuoteresponse.isSet == true)
                    {
                        tbxTickerSearchInfo.Text += "Price: " + globalQuoteresponse.GlobalQuote._05price + " (" + TickerSearch.bestMatches[index].currency + ")";
                    }


                    if (overviewResponse.isSet == true)
                    {
                        tbxOverview.Text += $"{overviewResponse.Description}\r\n";
                        tbxOverview.Text += $"P/E ratio: {overviewResponse.PERatio}\r\n";
                        tbxOverview.Text += $"Profit margin: {overviewResponse.ProfitMargin}\r\n";
                        tbxOverview.Text += $"Market capitalization: {overviewResponse.MarketCapitalization}\r\n";
                        tbxOverview.Text += $"Dividend yield: {overviewResponse.DividendYield}\r\n";
                        tbxOverview.Text += $"Beta : {overviewResponse.Beta}\r\n";
                        tbxOverview.Text += $"ebidta: {overviewResponse.EBITDA}\r\n";
                        tbxOverview.Text += $"Analyst target price: {overviewResponse.AnalystTargetPrice}\r\n";
                        
                    }
                    else
                    {
                        tbxOverview.Text = "No data found";
                    }
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

               await CreateRollingBanner();

            }
            else
            {
               gbxAktieSök.Enabled=false;
         
            }
         
        }
        public async Task CreateRollingBanner()
        {

            NonMovingQueue.Clear();

            GlobalMarketResponse marketResponse = new GlobalMarketResponse(ApiKeyHandler.Key);
            await ResponseHelper.SetObjectAsync<GlobalMarketResponse>(marketResponse);
            try
            {
                foreach (MarketData marketData in marketResponse.MarketList)
                {
                    Label Bannerlabel = new Label();
                    Bannerlabel.AutoSize = true;
                    Bannerlabel.Visible = false;
                    if (marketData.current_status == "open")
                    {
                    Bannerlabel.BackColor = System.Drawing.Color.Green; 
                    }
                    else 
                    { 
                        Bannerlabel.BackColor = System.Drawing.Color.Red; 
                    }
                    this.Controls.Add(Bannerlabel);
                    Bannerlabel.Text = "Current Status: " + marketData.current_status +"   Region: " + marketData.region ;
                    Bannerlabel.Font= new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Bannerlabel.Location = new System.Drawing.Point((-Bannerlabel.Width) - 60, this.Size.Height-100);
                   
                    NonMovingQueue.Enqueue(Bannerlabel);
                }

                Label label = NonMovingQueue.Dequeue();
                label.Visible = true;
                MovingList.Add(label);
                timer.Start();


            }
            catch (Exception) { }
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
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changeApiKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ValidationForm validationForm = new ValidationForm(this);
            validationForm.Show();

        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archival.ClearAllStockData();
            MessageBox.Show("All data has been cleared");
        }

        private void closeAuxillaryProgramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> DeleteList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                if(form.GetType()!=typeof(BaseForm))
                {
                    DeleteList.Add(form);
                }
            }
            foreach(Form form in DeleteList)
            {
                form.Close();
            }
        }

        private async void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ApiKeyHandler.KeyIsValidated && this.Visible == true)
            {
                await CreateRollingBanner();
            }
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Label label in MovingList)
            {
                label.Visible = false;
            }
            MovingList.Clear();
            NonMovingQueue.Clear();
            timer.Stop();   
        }

        
    }

}

