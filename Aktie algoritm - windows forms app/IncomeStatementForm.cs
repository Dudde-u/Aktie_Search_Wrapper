using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ClassLibrary;

namespace Aktie_algoritm___windows_forms_app
{
    public partial class IncomeStatementForm : Form
    {
        public IncomeStatementForm()//IncomeStatementResponse incomeStatementResponse)
        {
            InitializeComponent();
             //Data = incomeStatementResponse;
            BindLabels();
            for (int i = 0; i < incomestatement.ic_annualReports.Count; i++)
            {
                lbxDate.Items.Add(incomestatement.ic_annualReports[i].fiscalDateEnding);
            }
        }
        List<Label> labels = new List<Label>();
        private IncomeStatementResponse incomestatement;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           foreach(ic_Annualreport report in incomestatement.ic_annualReports)
            {

            }
        }
        private void BindLabels()
        {
            foreach (Label label in ICdataPanel.Controls)
            {
                if (label is Label) //no reason to have this really, will cause exception earlier
                {
                    labels.Add(label);
                }
            }
        }
    }
}
