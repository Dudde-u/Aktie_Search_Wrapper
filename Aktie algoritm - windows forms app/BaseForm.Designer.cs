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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.tbxSymbol = new System.Windows.Forms.TextBox();
            this.lbxRequestType = new System.Windows.Forms.ListBox();
            this.LbxTickerSök = new System.Windows.Forms.ListBox();
            this.btnKör = new System.Windows.Forms.Button();
            this.lblNamn = new System.Windows.Forms.Label();
            this.btnSökAktie = new System.Windows.Forms.Button();
            this.gbxAktieSök = new System.Windows.Forms.GroupBox();
            this.tbxOverview = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTickerSök = new System.Windows.Forms.Label();
            this.tbxTickerSearchInfo = new System.Windows.Forms.TextBox();
            this.btnValidationOpen = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.DataToolstrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.applicationStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAuxillaryProgramsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rollingBannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.apiKeyStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.changeApiKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BannerStateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gbxAktieSök.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxSymbol
            // 
            this.tbxSymbol.Location = new System.Drawing.Point(220, 77);
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
            this.btnKör.Location = new System.Drawing.Point(414, 479);
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
            this.tbxOverview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            // btnValidationOpen
            // 
            this.btnValidationOpen.Location = new System.Drawing.Point(1256, 106);
            this.btnValidationOpen.Name = "btnValidationOpen";
            this.btnValidationOpen.Size = new System.Drawing.Size(154, 49);
            this.btnValidationOpen.TabIndex = 16;
            this.btnValidationOpen.Text = "Set ApiKey";
            this.btnValidationOpen.UseVisualStyleBackColor = true;
            this.btnValidationOpen.Click += new System.EventHandler(this.btnValidationOpen_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataToolstrip,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.applicationStrip,
            this.toolStripSeparator4,
            this.toolStripSeparator1,
            this.apiKeyStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1875, 34);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // DataToolstrip
            // 
            this.DataToolstrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DataToolstrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDataToolStripMenuItem});
            this.DataToolstrip.Image = ((System.Drawing.Image)(resources.GetObject("DataToolstrip.Image")));
            this.DataToolstrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DataToolstrip.Name = "DataToolstrip";
            this.DataToolstrip.Size = new System.Drawing.Size(132, 29);
            this.DataToolstrip.Text = "Data storage";
            this.DataToolstrip.ToolTipText = "Data Management";
            // 
            // clearDataToolStripMenuItem
            // 
            this.clearDataToolStripMenuItem.Name = "clearDataToolStripMenuItem";
            this.clearDataToolStripMenuItem.Size = new System.Drawing.Size(193, 34);
            this.clearDataToolStripMenuItem.Text = "Clear data";
            this.clearDataToolStripMenuItem.Click += new System.EventHandler(this.clearDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // applicationStrip
            // 
            this.applicationStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.applicationStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemQuit,
            this.closeAuxillaryProgramsToolStripMenuItem,
            this.rollingBannerToolStripMenuItem});
            this.applicationStrip.Image = ((System.Drawing.Image)(resources.GetObject("applicationStrip.Image")));
            this.applicationStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applicationStrip.Name = "applicationStrip";
            this.applicationStrip.Size = new System.Drawing.Size(120, 29);
            this.applicationStrip.Text = "Application";
            // 
            // ToolStripMenuItemQuit
            // 
            this.ToolStripMenuItemQuit.Name = "ToolStripMenuItemQuit";
            this.ToolStripMenuItemQuit.Size = new System.Drawing.Size(300, 34);
            this.ToolStripMenuItemQuit.Text = "Quit";
            this.ToolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // closeAuxillaryProgramsToolStripMenuItem
            // 
            this.closeAuxillaryProgramsToolStripMenuItem.Name = "closeAuxillaryProgramsToolStripMenuItem";
            this.closeAuxillaryProgramsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.closeAuxillaryProgramsToolStripMenuItem.Text = "Close auxillary windows";
            this.closeAuxillaryProgramsToolStripMenuItem.Click += new System.EventHandler(this.closeAuxillaryProgramsToolStripMenuItem_Click);
            // 
            // rollingBannerToolStripMenuItem
            // 
            this.rollingBannerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem,
            this.offToolStripMenuItem});
            this.rollingBannerToolStripMenuItem.Name = "rollingBannerToolStripMenuItem";
            this.rollingBannerToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.rollingBannerToolStripMenuItem.Text = "Rolling banner";
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            this.onToolStripMenuItem.Size = new System.Drawing.Size(140, 34);
            this.onToolStripMenuItem.Text = "On";
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // offToolStripMenuItem
            // 
            this.offToolStripMenuItem.Name = "offToolStripMenuItem";
            this.offToolStripMenuItem.Size = new System.Drawing.Size(140, 34);
            this.offToolStripMenuItem.Text = "Off";
            this.offToolStripMenuItem.Click += new System.EventHandler(this.offToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // apiKeyStrip
            // 
            this.apiKeyStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.apiKeyStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeApiKeyToolStripMenuItem});
            this.apiKeyStrip.Image = ((System.Drawing.Image)(resources.GetObject("apiKeyStrip.Image")));
            this.apiKeyStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.apiKeyStrip.Name = "apiKeyStrip";
            this.apiKeyStrip.Size = new System.Drawing.Size(85, 29);
            this.apiKeyStrip.Text = "ApiKey";
            // 
            // changeApiKeyToolStripMenuItem
            // 
            this.changeApiKeyToolStripMenuItem.Name = "changeApiKeyToolStripMenuItem";
            this.changeApiKeyToolStripMenuItem.Size = new System.Drawing.Size(247, 34);
            this.changeApiKeyToolStripMenuItem.Text = "Change apiKey";
            this.changeApiKeyToolStripMenuItem.Click += new System.EventHandler(this.changeApiKeyToolStripMenuItem_Click);
            // 
            // BannerStateItem
            // 
            this.BannerStateItem.Name = "BannerStateItem";
            this.BannerStateItem.Size = new System.Drawing.Size(308, 34);
            this.BannerStateItem.Text = "Rolling banner";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 34);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1875, 1182);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnValidationOpen);
            this.Controls.Add(this.gbxAktieSök);
            this.Name = "BaseForm";
            this.Text = "Stock Analtyzer";
            this.Shown += new System.EventHandler(this.BaseDataForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.BaseDataForm_VisibleChanged);
            this.gbxAktieSök.ResumeLayout(false);
            this.gbxAktieSök.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSymbol;
        private System.Windows.Forms.ListBox lbxRequestType;
        private System.Windows.Forms.ListBox LbxTickerSök;
        private System.Windows.Forms.Button btnKör;
        private System.Windows.Forms.Label lblNamn;
        private System.Windows.Forms.Button btnSökAktie;
        private System.Windows.Forms.GroupBox gbxAktieSök;
        private System.Windows.Forms.TextBox tbxTickerSearchInfo;
        private System.Windows.Forms.Label lblTickerSök;
        private System.Windows.Forms.Button btnValidationOpen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOverview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton DataToolstrip;
        private System.Windows.Forms.ToolStripMenuItem clearDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton apiKeyStrip;
        private System.Windows.Forms.ToolStripMenuItem changeApiKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton applicationStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem closeAuxillaryProgramsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BannerStateItem;
        private System.Windows.Forms.ToolStripMenuItem rollingBannerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

