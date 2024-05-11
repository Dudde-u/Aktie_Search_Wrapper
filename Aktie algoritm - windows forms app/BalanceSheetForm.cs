using Class_library;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsSpace
{
    public partial class BalanceSheetForm : Form
    {
        
        public BalanceSheetForm(BalanceSheetResponse response)
        {
            InitializeComponent();
            balanceSheetResponse=response;

            

            this.btnQuarterly1.Click += this.button_Click;
            this.btnQuarterly2.Click += this.button_Click;
            this.btnQuarterly3.Click += this.button_Click;
            this.btnQuarterly4.Click += this.button_Click;

            this.btnQuarterly1.Click += this.ReloadQuarterlyData;
            this.btnQuarterly2.Click += this.ReloadQuarterlyData;
            this.btnQuarterly3.Click += this.ReloadQuarterlyData;
            this.btnQuarterly4.Click += this.ReloadQuarterlyData;

            this.btnAnnual1.Click += this.button_Click;
            this.btnAnnual2.Click += this.button_Click;
            this.btnAnnual3.Click += this.button_Click;
            this.btnAnnual4.Click += this.button_Click;

            this.btnAnnual1.Click += this.ReloadAnnualData;
            this.btnAnnual2.Click += this.ReloadAnnualData;
            this.btnAnnual3.Click += this.ReloadAnnualData;
            this.btnAnnual4.Click += this.ReloadAnnualData;

         
        }
        public List<string> DefaultTextList = new List<string>();
        public int AnnualOffset { get; set; }
        public int QuarterlyOffset { get; set; }
        private BalanceSheetResponse balanceSheetResponse;
        private void BalanceSheetForm_Shown(object sender, EventArgs e)
        {
            lblCurrency.Text = "Reported Currency: " +balanceSheetResponse.bs_annualReports[0].reportedCurrency;
            BindListBox(DefaultTextList);
            AnnualOffset = 1;
            QuarterlyOffset = 1;

            lblSymbol.Text = "Ticker/Symbol: " + balanceSheetResponse.Symbol;
            
            try
            {
                foreach (bs_QuarterlyReport report in balanceSheetResponse.bs_quarterlyReports)
                {
                    string tempDate = report.fiscalDateEnding.Substring(0, 7);
                    lbxDateQuarterly.Items.Add(tempDate);
                }
                foreach (bs_AnnualReport report in balanceSheetResponse.bs_annualReports)
                {
                    string tempDate = report.fiscalDateEnding.Substring(0, 4);
                    lbxDateAnnual.Items.Add(tempDate);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Something during loading of this page went wrong, try again");
                this.Close();
            }
        }
        private void ReloadQuarterlyData(object sender, EventArgs e)
        {

            lbxQuarterlyData.Items.Clear();

            int selectedindex = lbxDateQuarterly.SelectedIndex;
            int offset = QuarterlyOffset;

            if (selectedindex != -1) 
            {
                if (selectedindex + offset >= lbxDateQuarterly.Items.Count)
                {
                    offset = 0;
                }

                List<string> thisDataList = balanceSheetResponse.bs_quarterlyReports[selectedindex].ReturnList();

                List<string> PreviousDataList = balanceSheetResponse.bs_quarterlyReports[selectedindex + offset].ReturnList();

                List<string> multiplierList = StatementVisualizationHelper.CompareStatements(PreviousDataList, thisDataList);

                MergeAndShowLists(thisDataList, multiplierList, lbxQuarterlyData);
            }
        }
            private void ReloadAnnualData(object sender, EventArgs e)
            {
            lbxAnnualData.Items.Clear();

                int offset = AnnualOffset;
                int selectedindex = lbxDateAnnual.SelectedIndex;
                if (selectedindex != -1)
                {
                    List<string> thisDataList = balanceSheetResponse.bs_annualReports[selectedindex].ReturnList();

                    if (selectedindex + offset >= lbxDateAnnual.Items.Count)
                    {
                        offset = 0;
                    }   
                    List<string> PreviousDataList = balanceSheetResponse.bs_annualReports[selectedindex + offset].ReturnList();

                    List<string> multiplierList = StatementVisualizationHelper.CompareStatements(PreviousDataList, thisDataList);

                    MergeAndShowLists(thisDataList, multiplierList, lbxAnnualData);
                }
            }
        private void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Text;
            switch (buttonText)
            {
                case "1 y":
                    AnnualOffset = 1;
                    break;
                case "5 y":
                    AnnualOffset = 5;
                    break;
                case "10 y":
                    AnnualOffset = 10;
                    break;
                case "Max":
                    AnnualOffset = lbxDateAnnual.Items.Count - 1 - lbxDateAnnual.SelectedIndex;
                    break;
                case "1 r":
                    QuarterlyOffset = 1;
                    break;
                case "3 r":
                    QuarterlyOffset = 3;
                    break;
                case "5 r":
                    QuarterlyOffset = 5;
                    break;
                case "10 r":
                    QuarterlyOffset = 10;
                    break;
                default:
                    throw new NotImplementedException(); //this should not happen unless configuration malfunctions

            }
        }
        public void MergeAndShowLists(List<string> dataList, List<string> multiplierList, ListBox listBox)
        {
            try
            {
                int limit = dataList.Count;
                for (int i = 0; i < limit; i++)
                {
                    listBox.Items.Add( DefaultTextList[i] + dataList[i] + " " + multiplierList[i]);
                }
            }
            catch{ };
        }
        public static void BindListBox(List<string> DefaultTextList)
        {
            DefaultTextList.Add("Total Assets: ");
            DefaultTextList.Add("Total Current Assets: ");
            DefaultTextList.Add("Cash And Cash Equivalents At Carrying Value: ");
            DefaultTextList.Add("Cash And Short Term Investments: ");
            DefaultTextList.Add("Inventory: ");
            DefaultTextList.Add("Current Net Receivables: ");
            DefaultTextList.Add("Total Non Current Assets: ");
            DefaultTextList.Add("Property Plant Equipment: ");
            DefaultTextList.Add("Accumulated Depreciation Amortization PPE: ");
            DefaultTextList.Add("Intangible Assets: ");
            DefaultTextList.Add("Intangible Assets Excluding Goodwill: ");
            DefaultTextList.Add("Goodwill: ");
            DefaultTextList.Add("Investments: ");
            DefaultTextList.Add("Long Term Investments: ");
            DefaultTextList.Add("Short Term Investments: ");
            DefaultTextList.Add("Other Current Assets: ");
            DefaultTextList.Add("Other Non Current Assets: ");
            DefaultTextList.Add("Total Liabilities: ");
            DefaultTextList.Add("Total Current Liabilities: ");
            DefaultTextList.Add("Current Accounts Payable: ");
            DefaultTextList.Add("Deferred Revenue: ");
            DefaultTextList.Add("Current Debt: ");
            DefaultTextList.Add("Short Term Debt: ");
            DefaultTextList.Add("Total Non Current Liabilities: ");
            DefaultTextList.Add("Capital Lease Obligations: ");
            DefaultTextList.Add("Long Term Debt: ");
            DefaultTextList.Add("Current Long Term Debt: ");
            DefaultTextList.Add("Long Term Debt Noncurrent: ");
            DefaultTextList.Add("Short Long Term Debt Total: ");
            DefaultTextList.Add("Other Current Liabilities: ");
            DefaultTextList.Add("Other Non Current Liabilities: ");
            DefaultTextList.Add("Total Shareholder Equity: ");
            DefaultTextList.Add("Treasury Stock: ");
            DefaultTextList.Add("Retained Earnings: ");
            DefaultTextList.Add("Common Stock: ");
            DefaultTextList.Add("Common Stock Shares Outstanding: ");
        }
    }
}
