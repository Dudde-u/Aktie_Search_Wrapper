using Class_library;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClassLibrary.CashFlowResponse;

namespace FormsSpace
{
    public partial class CashFlowForm : Form
    {
        public CashFlowForm(CashFlowResponse Response)
        {
            InitializeComponent();

            cashFlowResponse = Response;


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
        private CashFlowResponse cashFlowResponse;
        private int AnnualOffset;
        private int QuarterlyOffset;


        private void CashFlowForm_Shown(object sender, EventArgs e)
        {
            lblCurrency.Text = "Reported Currency: " + cashFlowResponse.CF_annualReports[0].reportedCurrency;
            BindListBox();
            AnnualOffset = 1;
            QuarterlyOffset = 1;

            lblSymbol.Text = "Ticker/Symbol: " + cashFlowResponse.Symbol;

            try
            {
                foreach (CF_QuarterlyReport report in cashFlowResponse.CF_quarterlyReports)
                {
                    string tempDate = report.fiscalDateEnding.Substring(0, 7);
                    lbxQuarterlyDates.Items.Add(tempDate);
                }
                foreach (CF_AnnualReport report in cashFlowResponse.CF_annualReports)
                {
                    string tempDate = report.fiscalDateEnding.Substring(0, 4);
                    lbxAnnualDates.Items.Add(tempDate);
                }
            }
            catch (Exception) { MessageBox.Show("Something during loading of this page went wrong, try again"); }
        }

        private  void ReloadAnnualData(object sender, EventArgs e)
        {
            lbxAnnualData.Items.Clear();

            int offset = AnnualOffset;
            int selectedindex = lbxAnnualDates.SelectedIndex;

            if (selectedindex != -1)
            {
                List<string> thisDataList = cashFlowResponse.CF_annualReports[selectedindex].ReturnList();

                if (selectedindex + offset >= lbxAnnualDates.Items.Count)
                {
                    offset = 0;
                }
                List<string> PreviousDataList = cashFlowResponse.CF_annualReports[selectedindex + offset].ReturnList();

                List<string> multiplierList = StatementVisualizationHelper.CompareStatements(PreviousDataList, thisDataList);

               MergeAndShowLists(thisDataList, multiplierList, lbxAnnualData);
            }
        }
        private void ReloadQuarterlyData(object sender, EventArgs e)
        {

            lbxQuarterlyData.Items.Clear();

            int selectedindex = lbxQuarterlyDates.SelectedIndex;
            int offset = QuarterlyOffset;

            if (selectedindex != -1) //&& selectedindex + offset < lbxDateQuarterly.Items.Count)
            {
                if (selectedindex + offset >= lbxQuarterlyDates.Items.Count)
                {
                    offset = 0;
                }

                List<string> thisDataList = cashFlowResponse.CF_quarterlyReports[selectedindex].ReturnList();

                List<string> PreviousDataList = cashFlowResponse.CF_quarterlyReports[selectedindex + offset].ReturnList();

                List<string> multiplierList = StatementVisualizationHelper.CompareStatements(PreviousDataList, thisDataList);

                MergeAndShowLists(thisDataList, multiplierList, lbxQuarterlyData);
            }
        }
        public void MergeAndShowLists(List<string> dataList, List<string> multiplierList, ListBox listBox)
        {
            try
            {
                int limit = dataList.Count;
                for (int i = 0; i < limit; i++)
                {
                    listBox.Items.Add(DefaultTextList[i] + dataList[i] + " " + multiplierList[i]);
                }
            }
            catch { };
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
                    AnnualOffset = lbxAnnualDates.Items.Count - 1 - lbxAnnualDates.SelectedIndex;
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
                    throw new NotImplementedException(); //this should not happen unless something malfunctions

            }
        }
        public void BindListBox()
        {
            DefaultTextList.Add("Fiscal Date Ending: ");
            DefaultTextList.Add("Reported Currency: ");
            DefaultTextList.Add("Operating Cashflow: ");
            DefaultTextList.Add("Payments For Operating Activities: ");
            DefaultTextList.Add("Proceeds From Operating Activities: ");
            DefaultTextList.Add("Change In Operating Liabilities: ");
            DefaultTextList.Add("Change In Operating Assets: ");
            DefaultTextList.Add("Depreciation Depletion And Amortization: ");
            DefaultTextList.Add("Capital Expenditures: ");
            DefaultTextList.Add("Change In Receivables: ");
            DefaultTextList.Add("Change In Inventory: ");
            DefaultTextList.Add("Profit Loss: ");
            DefaultTextList.Add("Cashflow From Investment: ");
            DefaultTextList.Add("Cashflow From Financing: ");
            DefaultTextList.Add("Proceeds From Repayments Of Short Term Debt: ");
            DefaultTextList.Add("Payments For Repurchase Of Common Stock: ");
            DefaultTextList.Add("Payments For Repurchase Of Equity: ");
            DefaultTextList.Add("Payments For Repurchase Of Preferred Stock: ");
            DefaultTextList.Add("Dividend Payout: ");
            DefaultTextList.Add("Dividend Payout Common Stock: ");
            DefaultTextList.Add("Dividend Payout Preferred Stock: ");
            DefaultTextList.Add("Proceeds From Issuance Of Common Stock: ");
            DefaultTextList.Add("Proceeds From Issuance Of Long Term Debt And Capital Securities Net: ");
            DefaultTextList.Add("Proceeds From Issuance Of Preferred Stock: ");
            DefaultTextList.Add("Proceeds From Repurchase Of Equity: ");
            DefaultTextList.Add("Proceeds From Sale Of Treasury Stock: ");
            DefaultTextList.Add("Change In Cash And Cash Equivalents: ");
            DefaultTextList.Add("Change In Exchange Rate: ");
            DefaultTextList.Add("Net Income: ");
        }

    }
}
