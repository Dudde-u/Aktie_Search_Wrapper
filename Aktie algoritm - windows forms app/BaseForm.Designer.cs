namespace Aktie_Logik
{
    partial class BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxSymbol = new System.Windows.Forms.TextBox();
            this.lbxRequestType = new System.Windows.Forms.ListBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.LbxTickerSök = new System.Windows.Forms.ListBox();
            this.btnKör = new System.Windows.Forms.Button();
            this.lblNamn = new System.Windows.Forms.Label();
            this.btnSökAktie = new System.Windows.Forms.Button();
            this.gbxAktieSök = new System.Windows.Forms.GroupBox();
            this.tbxOverview = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTickerSök = new System.Windows.Forms.Label();
            this.tbxTickerSearchInfo = new System.Windows.Forms.TextBox();
            this.CheckBoxDemo = new System.Windows.Forms.CheckBox();
            this.btnValidationOpen = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbxAktieSök.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxSymbol
            // 
            this.tbxSymbol.Location = new System.Drawing.Point(208, 77);
            this.tbxSymbol.Name = "tbxSymbol";
            this.tbxSymbol.Size = new System.Drawing.Size(276, 26);
            this.tbxSymbol.TabIndex = 0;
            this.tbxSymbol.TextChanged += new System.EventHandler(this.tbxSymbol_TextChanged);
            // 
            // lbxRequestType
            // 
            this.lbxRequestType.Enabled = false;
            this.lbxRequestType.FormattingEnabled = true;
            this.lbxRequestType.ItemHeight = 20;
            this.lbxRequestType.Items.AddRange(new object[] {
            "Income Statement",
            "Balance Sheet",
            "Cash Flow"});
            this.lbxRequestType.Location = new System.Drawing.Point(100, 445);
            this.lbxRequestType.Name = "lbxRequestType";
            this.lbxRequestType.Size = new System.Drawing.Size(250, 144);
            this.lbxRequestType.TabIndex = 2;
            this.lbxRequestType.SelectedIndexChanged += new System.EventHandler(this.lbxRequestType_SelectedIndexChanged);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // LbxTickerSök
            // 
            this.LbxTickerSök.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LbxTickerSök.Enabled = false;
            this.LbxTickerSök.FormattingEnabled = true;
            this.LbxTickerSök.ItemHeight = 20;
            this.LbxTickerSök.Location = new System.Drawing.Point(78, 193);
            this.LbxTickerSök.Name = "LbxTickerSök";
            this.LbxTickerSök.Size = new System.Drawing.Size(228, 102);
            this.LbxTickerSök.TabIndex = 3;
            this.LbxTickerSök.SelectedIndexChanged += new System.EventHandler(this.LbxTickerSök_SelectedIndexChanged);
            // 
            // btnKör
            // 
            this.btnKör.Enabled = false;
            this.btnKör.Location = new System.Drawing.Point(470, 471);
            this.btnKör.Name = "btnKör";
            this.btnKör.Size = new System.Drawing.Size(124, 51);
            this.btnKör.TabIndex = 5;
            this.btnKör.Text = "Show data";
            this.btnKör.UseVisualStyleBackColor = true;
            this.btnKör.Click += new System.EventHandler(this.btnKör_Click);
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(6, 83);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(208, 20);
            this.lblNamn.TabIndex = 6;
            this.lblNamn.Text = "Write the name of the stock:";
            // 
            // btnSökAktie
            // 
            this.btnSökAktie.Enabled = false;
            this.btnSökAktie.Location = new System.Drawing.Point(524, 68);
            this.btnSökAktie.Name = "btnSökAktie";
            this.btnSökAktie.Size = new System.Drawing.Size(237, 38);
            this.btnSökAktie.TabIndex = 7;
            this.btnSökAktie.Text = "Search Ticker";
            this.btnSökAktie.UseVisualStyleBackColor = true;
            this.btnSökAktie.Click += new System.EventHandler(this.btnSökAktie_Click);
            // 
            // gbxAktieSök
            // 
            this.gbxAktieSök.Controls.Add(this.tbxOverview);
            this.gbxAktieSök.Controls.Add(this.label2);
            this.gbxAktieSök.Controls.Add(this.lblTickerSök);
            this.gbxAktieSök.Controls.Add(this.tbxTickerSearchInfo);
            this.gbxAktieSök.Controls.Add(this.lblNamn);
            this.gbxAktieSök.Controls.Add(this.btnSökAktie);
            this.gbxAktieSök.Controls.Add(this.LbxTickerSök);
            this.gbxAktieSök.Controls.Add(this.btnKör);
            this.gbxAktieSök.Controls.Add(this.lbxRequestType);
            this.gbxAktieSök.Controls.Add(this.tbxSymbol);
            this.gbxAktieSök.Enabled = false;
            this.gbxAktieSök.Location = new System.Drawing.Point(29, 106);
            this.gbxAktieSök.Name = "gbxAktieSök";
            this.gbxAktieSök.Size = new System.Drawing.Size(1059, 900);
            this.gbxAktieSök.TabIndex = 8;
            this.gbxAktieSök.TabStop = false;
            this.gbxAktieSök.Text = "Stock Search";
            // 
            // tbxOverview
            // 
            this.tbxOverview.Location = new System.Drawing.Point(748, 170);
            this.tbxOverview.Multiline = true;
            this.tbxOverview.Name = "tbxOverview";
            this.tbxOverview.ReadOnly = true;
            this.tbxOverview.Size = new System.Drawing.Size(265, 321);
            this.tbxOverview.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "(not all tickers have data)";
            // 
            // lblTickerSök
            // 
            this.lblTickerSök.AutoSize = true;
            this.lblTickerSök.Location = new System.Drawing.Point(74, 170);
            this.lblTickerSök.Name = "lblTickerSök";
            this.lblTickerSök.Size = new System.Drawing.Size(96, 20);
            this.lblTickerSök.TabIndex = 9;
            this.lblTickerSök.Text = "Select ticker";
            // 
            // tbxTickerSearchInfo
            // 
            this.tbxTickerSearchInfo.Location = new System.Drawing.Point(414, 170);
            this.tbxTickerSearchInfo.Multiline = true;
            this.tbxTickerSearchInfo.Name = "tbxTickerSearchInfo";
            this.tbxTickerSearchInfo.ReadOnly = true;
            this.tbxTickerSearchInfo.Size = new System.Drawing.Size(284, 172);
            this.tbxTickerSearchInfo.TabIndex = 8;
            // 
            // CheckBoxDemo
            // 
            this.CheckBoxDemo.AutoSize = true;
            this.CheckBoxDemo.Location = new System.Drawing.Point(1268, 76);
            this.CheckBoxDemo.Name = "CheckBoxDemo";
            this.CheckBoxDemo.Size = new System.Drawing.Size(83, 24);
            this.CheckBoxDemo.TabIndex = 14;
            this.CheckBoxDemo.Text = "DEMO";
            this.CheckBoxDemo.UseVisualStyleBackColor = true;
            // 
            // btnValidationOpen
            // 
            this.btnValidationOpen.Location = new System.Drawing.Point(1220, 106);
            this.btnValidationOpen.Name = "btnValidationOpen";
            this.btnValidationOpen.Size = new System.Drawing.Size(154, 49);
            this.btnValidationOpen.TabIndex = 16;
            this.btnValidationOpen.Text = "Set ApiKey";
            this.btnValidationOpen.UseVisualStyleBackColor = true;
            this.btnValidationOpen.Click += new System.EventHandler(this.btnValidationOpen_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(29, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(230, 40);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear stock data";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1875, 1182);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnValidationOpen);
            this.Controls.Add(this.CheckBoxDemo);
            this.Controls.Add(this.gbxAktieSök);
            this.Name = "BaseForm";
            this.Text = "Stock Analtyzer";
            this.Shown += new System.EventHandler(this.BaseDataForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.BaseDataForm_VisibleChanged);
            this.gbxAktieSök.ResumeLayout(false);
            this.gbxAktieSök.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSymbol;
        private System.Windows.Forms.ListBox lbxRequestType;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ListBox LbxTickerSök;
        private System.Windows.Forms.Button btnKör;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.Button btnSökAktie;
        private System.Windows.Forms.GroupBox gbxAktieSök;
        private System.Windows.Forms.TextBox tbxTickerSearchInfo;
        private System.Windows.Forms.Label lblTickerSök;
        private System.Windows.Forms.CheckBox CheckBoxDemo;
        private System.Windows.Forms.Button btnValidationOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOverview;
        private System.Windows.Forms.Button btnClear;
    }
}

