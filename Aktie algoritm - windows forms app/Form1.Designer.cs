namespace Aktie_algoritm___windows_forms_app
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
            this.tbxSymbol.Location = new System.Drawing.Point(139, 50);
            this.tbxSymbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxSymbol.Name = "tbxSymbol";
            this.tbxSymbol.Size = new System.Drawing.Size(185, 20);
            this.tbxSymbol.TabIndex = 0;
            this.tbxSymbol.Text = " ";
            this.tbxSymbol.TextChanged += new System.EventHandler(this.tbxSymbol_TextChanged);
            // 
            // tbxData
            // 
            this.tbxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxData.Location = new System.Drawing.Point(29, 417);
            this.tbxData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxData.Name = "tbxData";
            this.tbxData.ReadOnly = true;
            this.tbxData.Size = new System.Drawing.Size(480, 361);
            this.tbxData.TabIndex = 1;
            this.tbxData.Text = "";
            // 
            // lbxRequestType
            // 
            this.lbxRequestType.Enabled = false;
            this.lbxRequestType.FormattingEnabled = true;
            this.lbxRequestType.Items.AddRange(new object[] {
            "Income_Statement",
            "Balance_Sheet",
            "Global_Quote"});
            this.lbxRequestType.Location = new System.Drawing.Point(67, 289);
            this.lbxRequestType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxRequestType.Name = "lbxRequestType";
            this.lbxRequestType.Size = new System.Drawing.Size(168, 95);
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
            this.LbxTickerSök.Location = new System.Drawing.Point(51, 125);
            this.LbxTickerSök.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LbxTickerSök.Name = "LbxTickerSök";
            this.LbxTickerSök.Size = new System.Drawing.Size(153, 67);
            this.LbxTickerSök.TabIndex = 3;
            this.LbxTickerSök.SelectedIndexChanged += new System.EventHandler(this.LbxTickerSök_SelectedIndexChanged);
            this.LbxTickerSök.SelectedValueChanged += new System.EventHandler(this.LbxTickerSök_SelectedValueChanged);
            // 
            // btnKör
            // 
            this.btnKör.Location = new System.Drawing.Point(290, 320);
            this.btnKör.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKör.Name = "btnKör";
            this.btnKör.Size = new System.Drawing.Size(83, 33);
            this.btnKör.TabIndex = 5;
            this.btnKör.Text = "Run program";
            this.btnKör.UseVisualStyleBackColor = true;
            this.btnKör.Click += new System.EventHandler(this.btnKör_Click);
            // 
            // lblNamn
            // 
            this.lblNamn.AutoSize = true;
            this.lblNamn.Location = new System.Drawing.Point(9, 54);
            this.lblNamn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamn.Name = "lblNamn";
            this.lblNamn.Size = new System.Drawing.Size(130, 13);
            this.lblNamn.TabIndex = 6;
            this.lblNamn.Text = "Skriv in namnet på aktien:";
            // 
            // btnSökAktie
            // 
            this.btnSökAktie.Enabled = false;
            this.btnSökAktie.Location = new System.Drawing.Point(349, 44);
            this.btnSökAktie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSökAktie.Name = "btnSökAktie";
            this.btnSökAktie.Size = new System.Drawing.Size(158, 25);
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
            this.gbxAktieSök.Enabled = false;
            this.gbxAktieSök.Location = new System.Drawing.Point(8, 34);
            this.gbxAktieSök.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxAktieSök.Name = "gbxAktieSök";
            this.gbxAktieSök.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbxAktieSök.Size = new System.Drawing.Size(550, 805);
            this.gbxAktieSök.TabIndex = 8;
            this.gbxAktieSök.TabStop = false;
            this.gbxAktieSök.Text = "Aktie Sök";
            // 
            // lblTickerSök
            // 
            this.lblTickerSök.AutoSize = true;
            this.lblTickerSök.Location = new System.Drawing.Point(49, 103);
            this.lblTickerSök.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTickerSök.Name = "lblTickerSök";
            this.lblTickerSök.Size = new System.Drawing.Size(60, 13);
            this.lblTickerSök.TabIndex = 9;
            this.lblTickerSök.Text = "Välj Ticker:";
            // 
            // tbxTickerSearchInfo
            // 
            this.tbxTickerSearchInfo.Location = new System.Drawing.Point(269, 118);
            this.tbxTickerSearchInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxTickerSearchInfo.Multiline = true;
            this.tbxTickerSearchInfo.Name = "tbxTickerSearchInfo";
            this.tbxTickerSearchInfo.ReadOnly = true;
            this.tbxTickerSearchInfo.Size = new System.Drawing.Size(189, 83);
            this.tbxTickerSearchInfo.TabIndex = 8;
            // 
            // btnArkiverade
            // 
            this.btnArkiverade.Location = new System.Drawing.Point(672, 710);
            this.btnArkiverade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnArkiverade.Name = "btnArkiverade";
            this.btnArkiverade.Size = new System.Drawing.Size(158, 25);
            this.btnArkiverade.TabIndex = 9;
            this.btnArkiverade.Text = "Utifrån arkiv // projekt";
            this.btnArkiverade.UseVisualStyleBackColor = true;
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.Location = new System.Drawing.Point(599, 38);
            this.tbxApiKey.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.Size = new System.Drawing.Size(157, 20);
            this.tbxApiKey.TabIndex = 10;
            this.tbxApiKey.TextChanged += new System.EventHandler(this.tbxApiKey_TextChanged);
            // 
            // lblAktieNyckel
            // 
            this.lblAktieNyckel.AutoSize = true;
            this.lblAktieNyckel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktieNyckel.Location = new System.Drawing.Point(596, 23);
            this.lblAktieNyckel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAktieNyckel.Name = "lblAktieNyckel";
            this.lblAktieNyckel.Size = new System.Drawing.Size(178, 13);
            this.lblAktieNyckel.TabIndex = 11;
            this.lblAktieNyckel.Text = "Din AlphaVantage API nyckel:";
            // 
            // btnValidering
            // 
            this.btnValidering.Enabled = false;
            this.btnValidering.Location = new System.Drawing.Point(775, 36);
            this.btnValidering.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnValidering.Name = "btnValidering";
            this.btnValidering.Size = new System.Drawing.Size(96, 21);
            this.btnValidering.TabIndex = 12;
            this.btnValidering.Text = "Validera nyckel";
            this.btnValidering.UseVisualStyleBackColor = true;
            this.btnValidering.Click += new System.EventHandler(this.btnValidering_Click);
            // 
            // tbxMarketOpenClose
            // 
            this.tbxMarketOpenClose.Location = new System.Drawing.Point(1037, 21);
            this.tbxMarketOpenClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxMarketOpenClose.Multiline = true;
            this.tbxMarketOpenClose.Name = "tbxMarketOpenClose";
            this.tbxMarketOpenClose.ReadOnly = true;
            this.tbxMarketOpenClose.Size = new System.Drawing.Size(189, 83);
            this.tbxMarketOpenClose.TabIndex = 10;
            // 
            // btnMarketStatus
            // 
            this.btnMarketStatus.Enabled = false;
            this.btnMarketStatus.Location = new System.Drawing.Point(1079, 118);
            this.btnMarketStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarketStatus.Name = "btnMarketStatus";
            this.btnMarketStatus.Size = new System.Drawing.Size(117, 20);
            this.btnMarketStatus.TabIndex = 13;
            this.btnMarketStatus.Text = "Kolla marknadsstatus";
            this.btnMarketStatus.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDemo
            // 
            this.CheckBoxDemo.AutoSize = true;
            this.CheckBoxDemo.Location = new System.Drawing.Point(928, 14);
            this.CheckBoxDemo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheckBoxDemo.Name = "CheckBoxDemo";
            this.CheckBoxDemo.Size = new System.Drawing.Size(58, 17);
            this.CheckBoxDemo.TabIndex = 14;
            this.CheckBoxDemo.Text = "DEMO";
            this.CheckBoxDemo.UseVisualStyleBackColor = true;
            this.CheckBoxDemo.CheckedChanged += new System.EventHandler(this.CheckBoxDemo_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 768);
            this.Controls.Add(this.CheckBoxDemo);
            this.Controls.Add(this.btnMarketStatus);
            this.Controls.Add(this.tbxMarketOpenClose);
            this.Controls.Add(this.btnValidering);
            this.Controls.Add(this.lblAktieNyckel);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.gbxAktieSök);
            this.Controls.Add(this.btnArkiverade);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbxAktieSök.ResumeLayout(false);
            this.gbxAktieSök.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSymbol;
        private System.Windows.Forms.RichTextBox tbxData;
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
    }
}

