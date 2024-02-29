namespace Aktie_Logik
{
    partial class Form1
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
            this.tbxData = new System.Windows.Forms.RichTextBox();
            this.lbxRequestType = new System.Windows.Forms.ListBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.LbxTickerSök = new System.Windows.Forms.ListBox();
            this.btnKör = new System.Windows.Forms.Button();
            this.lblNamn = new System.Windows.Forms.Label();
            this.btnSökAktie = new System.Windows.Forms.Button();
            this.gbxAktieSök = new System.Windows.Forms.GroupBox();
            this.lblTickerSök = new System.Windows.Forms.Label();
            this.tbxTickerSearchInfo = new System.Windows.Forms.TextBox();
            this.btnArkiverade = new System.Windows.Forms.Button();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.lblAktieNyckel = new System.Windows.Forms.Label();
            this.btnValidering = new System.Windows.Forms.Button();
            this.tbxMarketOpenClose = new System.Windows.Forms.TextBox();
            this.btnMarketStatus = new System.Windows.Forms.Button();
            this.CheckBoxDemo = new System.Windows.Forms.CheckBox();
            this.gbxAktieSök.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxSymbol
            // 
            this.tbxSymbol.Location = new System.Drawing.Point(208, 77);
            this.tbxSymbol.Name = "tbxSymbol";
            this.tbxSymbol.Size = new System.Drawing.Size(276, 26);
            this.tbxSymbol.TabIndex = 0;
            this.tbxSymbol.Text = " ";
            this.tbxSymbol.TextChanged += new System.EventHandler(this.tbxSymbol_TextChanged);
            // 
            // tbxData
            // 
            this.tbxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxData.Location = new System.Drawing.Point(43, 636);
            this.tbxData.Name = "tbxData";
            this.tbxData.ReadOnly = true;
            this.tbxData.Size = new System.Drawing.Size(718, 553);
            this.tbxData.TabIndex = 1;
            this.tbxData.Text = "";
            // 
            // lbxRequestType
            // 
            this.lbxRequestType.Enabled = false;
            this.lbxRequestType.FormattingEnabled = true;
            this.lbxRequestType.ItemHeight = 20;
            this.lbxRequestType.Items.AddRange(new object[] {
            "Income_Statement",
            "Balance_Sheet",
            "Global_Quote"});
            this.lbxRequestType.Location = new System.Drawing.Point(100, 445);
            this.lbxRequestType.Name = "lbxRequestType";
            this.lbxRequestType.Size = new System.Drawing.Size(250, 144);
            this.lbxRequestType.TabIndex = 2;
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
            this.LbxTickerSök.Location = new System.Drawing.Point(76, 192);
            this.LbxTickerSök.Name = "LbxTickerSök";
            this.LbxTickerSök.Size = new System.Drawing.Size(228, 102);
            this.LbxTickerSök.TabIndex = 3;
            this.LbxTickerSök.SelectedIndexChanged += new System.EventHandler(this.LbxTickerSök_SelectedIndexChanged);
            this.LbxTickerSök.SelectedValueChanged += new System.EventHandler(this.LbxTickerSök_SelectedValueChanged);
            // 
            // btnKör
            // 
            this.btnKör.Location = new System.Drawing.Point(435, 492);
            this.btnKör.Name = "btnKör";
            this.btnKör.Size = new System.Drawing.Size(124, 51);
            this.btnKör.TabIndex = 5;
            this.btnKör.Text = "Run program";
            this.btnKör.UseVisualStyleBackColor = true;
            this.btnKör.Click += new System.EventHandler(this.btnKör_Click);
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(14, 83);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(190, 20);
            this.lblNamn.TabIndex = 6;
            this.lblNamn.Text = "Skriv in namnet på aktien:";
            // 
            // btnSökAktie
            // 
            this.btnSökAktie.Enabled = false;
            this.btnSökAktie.Location = new System.Drawing.Point(524, 68);
            this.btnSökAktie.Name = "btnSökAktie";
            this.btnSökAktie.Size = new System.Drawing.Size(237, 38);
            this.btnSökAktie.TabIndex = 7;
            this.btnSökAktie.Text = "Sök Ticker namn";
            this.btnSökAktie.UseVisualStyleBackColor = true;
            this.btnSökAktie.Click += new System.EventHandler(this.btnSökAktie_Click);
            // 
            // gbxAktieSök
            // 
            this.gbxAktieSök.Controls.Add(this.lblTickerSök);
            this.gbxAktieSök.Controls.Add(this.tbxTickerSearchInfo);
            this.gbxAktieSök.Controls.Add(this.lblNamn);
            this.gbxAktieSök.Controls.Add(this.btnSökAktie);
            this.gbxAktieSök.Controls.Add(this.LbxTickerSök);
            this.gbxAktieSök.Controls.Add(this.tbxData);
            this.gbxAktieSök.Controls.Add(this.btnKör);
            this.gbxAktieSök.Controls.Add(this.lbxRequestType);
            this.gbxAktieSök.Controls.Add(this.tbxSymbol);
            this.gbxAktieSök.Location = new System.Drawing.Point(12, 52);
            this.gbxAktieSök.Name = "gbxAktieSök";
            this.gbxAktieSök.Size = new System.Drawing.Size(825, 1238);
            this.gbxAktieSök.TabIndex = 8;
            this.gbxAktieSök.TabStop = false;
            this.gbxAktieSök.Text = "Aktie Sök";
            // 
            // lblTickerSök
            // 
            this.lblTickerSök.AutoSize = true;
            this.lblTickerSök.Location = new System.Drawing.Point(74, 158);
            this.lblTickerSök.Name = "lblTickerSök";
            this.lblTickerSök.Size = new System.Drawing.Size(85, 20);
            this.lblTickerSök.TabIndex = 9;
            this.lblTickerSök.Text = "Välj Ticker:";
            // 
            // tbxTickerSearchInfo
            // 
            this.tbxTickerSearchInfo.Location = new System.Drawing.Point(404, 182);
            this.tbxTickerSearchInfo.Multiline = true;
            this.tbxTickerSearchInfo.Name = "tbxTickerSearchInfo";
            this.tbxTickerSearchInfo.ReadOnly = true;
            this.tbxTickerSearchInfo.Size = new System.Drawing.Size(282, 126);
            this.tbxTickerSearchInfo.TabIndex = 8;
            // 
            // btnArkiverade
            // 
            this.btnArkiverade.Location = new System.Drawing.Point(1008, 1092);
            this.btnArkiverade.Name = "btnArkiverade";
            this.btnArkiverade.Size = new System.Drawing.Size(237, 38);
            this.btnArkiverade.TabIndex = 9;
            this.btnArkiverade.Text = "Utifrån arkiv // projekt";
            this.btnArkiverade.UseVisualStyleBackColor = true;
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.Location = new System.Drawing.Point(898, 58);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.Size = new System.Drawing.Size(234, 26);
            this.tbxApiKey.TabIndex = 10;
            this.tbxApiKey.TextChanged += new System.EventHandler(this.tbxApiKey_TextChanged);
            // 
            // lblAktieNyckel
            // 
            this.lblAktieNyckel.AutoSize = true;
            this.lblAktieNyckel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktieNyckel.Location = new System.Drawing.Point(894, 35);
            this.lblAktieNyckel.Name = "lblAktieNyckel";
            this.lblAktieNyckel.Size = new System.Drawing.Size(249, 20);
            this.lblAktieNyckel.TabIndex = 11;
            this.lblAktieNyckel.Text = "Din AlphaVantage API nyckel:";
            // 
            // btnValidering
            // 
            this.btnValidering.Location = new System.Drawing.Point(1162, 55);
            this.btnValidering.Name = "btnValidering";
            this.btnValidering.Size = new System.Drawing.Size(144, 32);
            this.btnValidering.TabIndex = 12;
            this.btnValidering.Text = "Validera nyckel";
            this.btnValidering.UseVisualStyleBackColor = true;
            this.btnValidering.Click += new System.EventHandler(this.btnValidering_Click);
            // 
            // tbxMarketOpenClose
            // 
            this.tbxMarketOpenClose.Location = new System.Drawing.Point(1556, 32);
            this.tbxMarketOpenClose.Multiline = true;
            this.tbxMarketOpenClose.Name = "tbxMarketOpenClose";
            this.tbxMarketOpenClose.ReadOnly = true;
            this.tbxMarketOpenClose.Size = new System.Drawing.Size(282, 126);
            this.tbxMarketOpenClose.TabIndex = 10;
            // 
            // btnMarketStatus
            // 
            this.btnMarketStatus.Enabled = false;
            this.btnMarketStatus.Location = new System.Drawing.Point(1618, 182);
            this.btnMarketStatus.Name = "btnMarketStatus";
            this.btnMarketStatus.Size = new System.Drawing.Size(176, 31);
            this.btnMarketStatus.TabIndex = 13;
            this.btnMarketStatus.Text = "Kolla marknadsstatus";
            this.btnMarketStatus.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDemo
            // 
            this.CheckBoxDemo.AutoSize = true;
            this.CheckBoxDemo.Location = new System.Drawing.Point(1392, 22);
            this.CheckBoxDemo.Name = "CheckBoxDemo";
            this.CheckBoxDemo.Size = new System.Drawing.Size(83, 24);
            this.CheckBoxDemo.TabIndex = 14;
            this.CheckBoxDemo.Text = "DEMO";
            this.CheckBoxDemo.UseVisualStyleBackColor = true;
            this.CheckBoxDemo.CheckedChanged += new System.EventHandler(this.CheckBoxDemo_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1875, 1182);
            this.Controls.Add(this.CheckBoxDemo);
            this.Controls.Add(this.btnMarketStatus);
            this.Controls.Add(this.tbxMarketOpenClose);
            this.Controls.Add(this.btnValidering);
            this.Controls.Add(this.lblAktieNyckel);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.gbxAktieSök);
            this.Controls.Add(this.btnArkiverade);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button btnArkiverade;
        private System.Windows.Forms.TextBox tbxApiKey;
        private System.Windows.Forms.Label lblAktieNyckel;
        private System.Windows.Forms.Button btnValidering;
        private System.Windows.Forms.TextBox tbxTickerSearchInfo;
        private System.Windows.Forms.Label lblTickerSök;
        private System.Windows.Forms.TextBox tbxMarketOpenClose;
        private System.Windows.Forms.Button btnMarketStatus;
        private System.Windows.Forms.CheckBox CheckBoxDemo;
        public System.Windows.Forms.RichTextBox tbxData;
    }
}

