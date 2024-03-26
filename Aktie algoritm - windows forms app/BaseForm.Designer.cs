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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTickerSök = new System.Windows.Forms.Label();
            this.tbxTickerSearchInfo = new System.Windows.Forms.TextBox();
            this.CheckBoxDemo = new System.Windows.Forms.CheckBox();
            this.btnValidationOpen = new System.Windows.Forms.Button();
            this.btnMarketOpenClose = new System.Windows.Forms.Button();
            this.lblMarketOpenClose = new System.Windows.Forms.Label();
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
            this.gbxAktieSök.Location = new System.Drawing.Point(12, 52);
            this.gbxAktieSök.Name = "gbxAktieSök";
            this.gbxAktieSök.Size = new System.Drawing.Size(786, 665);
            this.gbxAktieSök.TabIndex = 8;
            this.gbxAktieSök.TabStop = false;
            this.gbxAktieSök.Text = "Aktie Sök";
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
            this.CheckBoxDemo.CheckedChanged += new System.EventHandler(this.CheckBoxDemo_CheckedChanged);
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
            // btnMarketOpenClose
            // 
            this.btnMarketOpenClose.Enabled = false;
            this.btnMarketOpenClose.Location = new System.Drawing.Point(1589, 176);
            this.btnMarketOpenClose.Name = "btnMarketOpenClose";
            this.btnMarketOpenClose.Size = new System.Drawing.Size(197, 41);
            this.btnMarketOpenClose.TabIndex = 17;
            this.btnMarketOpenClose.Text = "Check market status";
            this.btnMarketOpenClose.UseVisualStyleBackColor = true;
            this.btnMarketOpenClose.Click += new System.EventHandler(this.btnMarketOpenClose_Click);
            // 
            // lblMarketOpenClose
            // 
            this.lblMarketOpenClose.AutoSize = true;
            this.lblMarketOpenClose.Location = new System.Drawing.Point(1575, 52);
            this.lblMarketOpenClose.Name = "lblMarketOpenClose";
            this.lblMarketOpenClose.Size = new System.Drawing.Size(0, 20);
            this.lblMarketOpenClose.TabIndex = 18;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1875, 1182);
            this.Controls.Add(this.lblMarketOpenClose);
            this.Controls.Add(this.btnMarketOpenClose);
            this.Controls.Add(this.btnValidationOpen);
            this.Controls.Add(this.CheckBoxDemo);
            this.Controls.Add(this.gbxAktieSök);
            this.Name = "BaseForm";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button btnMarketOpenClose;
        private System.Windows.Forms.Label lblMarketOpenClose;
        private System.Windows.Forms.Label label2;
    }
}

