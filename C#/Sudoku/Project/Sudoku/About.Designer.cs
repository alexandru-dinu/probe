namespace Sudoku
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lblNameInfo = new System.Windows.Forms.Label();
            this.lblHighSchool = new System.Windows.Forms.Label();
            this.lblTownCounty = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNameInfo
            // 
            this.lblNameInfo.AutoSize = true;
            this.lblNameInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblNameInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNameInfo.Location = new System.Drawing.Point(13, 13);
            this.lblNameInfo.Name = "lblNameInfo";
            this.lblNameInfo.Size = new System.Drawing.Size(163, 16);
            this.lblNameInfo.TabIndex = 0;
            this.lblNameInfo.Text = "Scris de Alexandru Dinu";
            // 
            // lblHighSchool
            // 
            this.lblHighSchool.AutoSize = true;
            this.lblHighSchool.BackColor = System.Drawing.Color.Transparent;
            this.lblHighSchool.Location = new System.Drawing.Point(13, 36);
            this.lblHighSchool.Name = "lblHighSchool";
            this.lblHighSchool.Size = new System.Drawing.Size(267, 16);
            this.lblHighSchool.TabIndex = 1;
            this.lblHighSchool.Text = "Colegiul Național \"Ienăchiță Văcărescu\"";
            // 
            // lblTownCounty
            // 
            this.lblTownCounty.AutoSize = true;
            this.lblTownCounty.BackColor = System.Drawing.Color.Transparent;
            this.lblTownCounty.Location = new System.Drawing.Point(13, 59);
            this.lblTownCounty.Name = "lblTownCounty";
            this.lblTownCounty.Size = new System.Drawing.Size(157, 16);
            this.lblTownCounty.TabIndex = 2;
            this.lblTownCounty.Text = "Târgoviște, Dâmbovița";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblInfo.Location = new System.Drawing.Point(13, 82);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(210, 16);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "Atestatul de informatică, 2014";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.ForeColor = System.Drawing.Color.Green;
            this.lblVersion.Location = new System.Drawing.Point(13, 105);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 16);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "v1.1.0.0";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTownCounty);
            this.Controls.Add(this.lblHighSchool);
            this.Controls.Add(this.lblNameInfo);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameInfo;
        private System.Windows.Forms.Label lblHighSchool;
        private System.Windows.Forms.Label lblTownCounty;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblVersion;
    }
}