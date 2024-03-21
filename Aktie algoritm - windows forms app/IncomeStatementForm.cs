﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Class_library;
using ClassLibrary;


using Label = System.Windows.Forms.Label;

namespace Aktie_algoritm___windows_forms_app
{
    public partial class IncomeStatementForm : Form
    {
        public IncomeStatementForm(IncomeStatementResponse incomeStatementResponse)
        {
            InitializeComponent();
            incomestatement = incomeStatementResponse;
            AnnualOffset = 1;
            QuarterlyOffset = 1;
        }
        List<Label> LabelsAnnual = new List<Label>();
        List<Label> LabelsQuarterly = new List<Label>();
        public int AnnualOffset {  get; set; }
        public int QuarterlyOffset {  get; set; }
        
        private IncomeStatementResponse incomestatement;
        private void lbxDateAnnual_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TextToDefault(LabelsAnnual);

            int selectedindex = lbxDateAnnual.SelectedIndex;

            int offset = AnnualOffset;
            
            List<string> thisDataList = incomestatement.ic_annualReports[selectedindex].ReturnList();
           
            if(selectedindex >= lbxDateAnnual.Items.Count - 1) 
            {
                offset = 0;
            }
            List<string> PreviousDataList = incomestatement.ic_annualReports[selectedindex + offset].ReturnList();

            List<string> multiplierList= IncomeStatementHelper.CompareStatements(PreviousDataList, thisDataList);

            IncomeStatementHelper.MergeAndShowLists(thisDataList, multiplierList,LabelsAnnual);

        }
        private void BindLabels()
        {
            foreach (Control control in ICdataPanel_Annual.Controls)
            {
                if (control is Label) //redundancy
                {
                    LabelsAnnual.Add((Label)control);
                }
            }
            foreach(Control control in ICdataPanel_Quarterly.Controls)
            {
                if (control is Label) //redundancy
                {
                    LabelsQuarterly.Add((Label) control);
                }
            }
            IncomeStatementHelper.BubbleSortLabels(ref LabelsAnnual);
            IncomeStatementHelper.BubbleSortLabels(ref LabelsAnnual);
        }
            private void IncomeStatementForm_Shown(object sender, EventArgs e)
            {
            lblSymbol.Text = "Ticker/Symbol: "+incomestatement.Symbol;
            BindLabels();
            try
            {
                foreach (ic_Quarterlyreport report in incomestatement.ic_quarterlyReports)
                {
                    string tempDate=report.fiscalDateEnding.Substring(0, 7);
                          lbxDateQuarterly.Items.Add(tempDate);
                }
                foreach(ic_Annualreport report in incomestatement.ic_annualReports)
                {
                    string tempDate=report.fiscalDateEnding.Substring(0,4);
                    lbxDateAnnual.Items.Add(tempDate);
                }
            }
            catch (Exception) { MessageBox.Show("Something during loading of this page went wrong, try again"); }
            }
            private void lbxDateQuarterly_SelectedIndexChanged(object sender, EventArgs e)
            {

            
            TextToDefault(LabelsQuarterly);

            int selectedindex = lbxDateQuarterly.SelectedIndex;
            int offset = QuarterlyOffset;

            if (selectedindex >= lbxDateQuarterly.Items.Count - 1)
            {
                offset = 0;
            }

            List<string> thisDataList = incomestatement.ic_quarterlyReports[selectedindex].ReturnList();

               

                List<string> PreviousDataList = incomestatement.ic_quarterlyReports[selectedindex + offset].ReturnList();

            List<string> multiplierList = IncomeStatementHelper.CompareStatements(PreviousDataList, thisDataList);

            IncomeStatementHelper.MergeAndShowLists(thisDataList, multiplierList, LabelsQuarterly);

           
        }
         static void TextToDefault(List<Label> labels)
        {
            //can be done with array  amd loops but this should be more efficient:
            labels[0].Text = "Gross Profit: ";
            labels[1].Text = "Total Revenue: ";
            labels[2].Text = "Cost of Revenue: ";
            labels[3].Text = "Cost of Goods and Services Sold: ";
            labels[4].Text = "Operating Income: ";
            labels[5].Text = "Selling General and Administrative: ";
            labels[6].Text = "Research and Development: ";
            labels[7].Text = "Operating Expenses: ";
            labels[8].Text = "Investment Income Net: ";
            labels[9].Text = "Net Interest Income: ";
            labels[10].Text = "Interest Income: ";
            labels[11].Text = "Interest Expense: ";
            labels[12].Text = "Non Interest Income: ";
            labels[13].Text = "Other Non Operating Income: ";
            labels[14].Text = "Depreciation: ";
            labels[15].Text = "Depreciation and Amortization: ";
            labels[16].Text = "Income Before Tax: ";
            labels[17].Text = "Income Tax Expense: ";
            labels[18].Text = "Interest and Debt Expense: ";
            labels[19].Text = "Net Income From Continuing Operations: ";
            labels[20].Text = "Comprehensive Income Net of Tax: ";
            labels[21].Text = "Ebit: ";
            labels[22].Text = "Ebitda: ";
            labels[23].Text = "Net Income: ";
        }

        private void btnAnnual1_Click(object sender, EventArgs e) //todo fix this
        {
            //AnnualOffset = 1;
        }

        private void btnAnnual2_Click(object sender, EventArgs e)
        {
            //if (lbxDateAnnual.SelectedIndex + 5 <= lbxDateAnnual.Items.Count)
            //{
            //    AnnualOffset = 5;
            //}
        }

        private void btnAnnual3_Click(object sender, EventArgs e)
        {
            //if (lbxDateAnnual.SelectedIndex +10 <= lbxDateAnnual.Items.Count)
            //{
            //    AnnualOffset = 10;
            //}
        }

        private void btnAnnual4_Click(object sender, EventArgs e)
        {
         //  AnnualOffset = lbxDateAnnual.Items.Count - 1 - lbxDateAnnual.SelectedIndex;
        }
    }
    
}
