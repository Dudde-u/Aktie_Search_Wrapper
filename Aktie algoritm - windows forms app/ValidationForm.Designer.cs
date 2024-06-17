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
            this.lblAktieNyckel = new System.Windows.Forms.Label();
            this.tbxApiKey = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.returnToMainPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.returnToMainPageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblAktieNyckel
            // 
            this.lblAktieNyckel.AutoSize = true;
            this.lblAktieNyckel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktieNyckel.Location = new System.Drawing.Point(186, 99);
            this.lblAktieNyckel.Name = "lblAktieNyckel";
            this.lblAktieNyckel.Size = new System.Drawing.Size(237, 20);
            this.lblAktieNyckel.TabIndex = 14;
            this.lblAktieNyckel.Text = "Your AlphaVantage API key:";
            // 
            // tbxApiKey
            // 
            this.tbxApiKey.Location = new System.Drawing.Point(190, 134);
            this.tbxApiKey.Name = "tbxApiKey";
            this.tbxApiKey.Size = new System.Drawing.Size(234, 26);
            this.tbxApiKey.TabIndex = 13;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(174, 214);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(261, 20);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Tag = "https://www.alphavantage.co/support/#api-key";
            this.linkLabel2.Text = "Get your free AlphaVantage ApiKey";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // returnToMainPageToolStripMenuItem
            // 
            this.returnToMainPageToolStripMenuItem.Name = "returnToMainPageToolStripMenuItem";
            this.returnToMainPageToolStripMenuItem.Size = new System.Drawing.Size(190, 29);
            this.returnToMainPageToolStripMenuItem.Text = "Return to main page";
            this.returnToMainPageToolStripMenuItem.Click += new System.EventHandler(this.returnToMainPageToolStripMenuItem_Click);
            // 
            // ValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.lblAktieNyckel);
            this.Controls.Add(this.tbxApiKey);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ValidationForm";
            this.Text = "Key validation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblAktieNyckel;
        private System.Windows.Forms.TextBox tbxApiKey;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ToolStripMenuItem returnToMainPageToolStripMenuItem;
    }
}