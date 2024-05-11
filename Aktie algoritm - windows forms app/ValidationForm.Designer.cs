namespace FormsSpace
{
    partial class ValidationForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnValidering = new System.Windows.Forms.Button();
            this.lblAktieNyckel = new System.Windows.Forms.Label();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnValidering
            // 
            this.btnValidering.Enabled = false;
            this.btnValidering.Location = new System.Drawing.Point(508, 126);
            this.btnValidering.Name = "btnValidering";
            this.btnValidering.Size = new System.Drawing.Size(167, 43);
            this.btnValidering.TabIndex = 15;
            this.btnValidering.Text = "Validate";
            this.btnValidering.UseVisualStyleBackColor = true;
            this.btnValidering.Click += new System.EventHandler(this.btnValidering_Click);
            // 
            // lblAktieNyckel
            // 
            this.lblAktieNyckel.AutoSize = true;
            this.lblAktieNyckel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktieNyckel.Location = new System.Drawing.Point(186, 100);
            this.lblAktieNyckel.Name = "lblAktieNyckel";
            this.lblAktieNyckel.Size = new System.Drawing.Size(237, 20);
            this.lblAktieNyckel.TabIndex = 14;
            this.lblAktieNyckel.Text = "Your AlphaVantage API key:";
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.Enabled = false;
            this.tbxApiKey.Location = new System.Drawing.Point(190, 134);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.Size = new System.Drawing.Size(234, 26);
            this.tbxApiKey.TabIndex = 13;
            this.tbxApiKey.TextChanged += new System.EventHandler(this.tbxApiKey_TextChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(174, 183);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(261, 20);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "https://www.alphavantage.co/support/#api-key";
            this.linkLabel2.Text = "Get your free AlphaVantage ApiKey";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.btnValidering);
            this.Controls.Add(this.lblAktieNyckel);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ValidationForm";
            this.Text = "Key validation";
            this.Shown += new System.EventHandler(this.ValidationForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnValidering;
        private System.Windows.Forms.Label lblAktieNyckel;
        private System.Windows.Forms.TextBox tbxApiKey;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}