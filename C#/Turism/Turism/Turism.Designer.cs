namespace Turism
{
    partial class Turism
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
            this.menuDatePersonale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVacanta = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDatePersonale = new System.Windows.Forms.Button();
            this.btnVacanta = new System.Windows.Forms.Button();
            this.txtVacanta = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatePersonale,
            this.menuVacanta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(439, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuDatePersonale
            // 
            this.menuDatePersonale.Name = "menuDatePersonale";
            this.menuDatePersonale.Size = new System.Drawing.Size(97, 20);
            this.menuDatePersonale.Text = "Date personale";
            this.menuDatePersonale.Click += new System.EventHandler(this.menuDatePersonale_Click);
            // 
            // menuVacanta
            // 
            this.menuVacanta.Name = "menuVacanta";
            this.menuVacanta.Size = new System.Drawing.Size(61, 20);
            this.menuVacanta.Text = "Vacanta";
            this.menuVacanta.Click += new System.EventHandler(this.menuVacanta_Click);
            // 
            // btnDatePersonale
            // 
            this.btnDatePersonale.Location = new System.Drawing.Point(13, 49);
            this.btnDatePersonale.Name = "btnDatePersonale";
            this.btnDatePersonale.Size = new System.Drawing.Size(108, 73);
            this.btnDatePersonale.TabIndex = 1;
            this.btnDatePersonale.Text = "Date personale";
            this.btnDatePersonale.UseVisualStyleBackColor = true;
            this.btnDatePersonale.Click += new System.EventHandler(this.menuDatePersonale_Click);
            // 
            // btnVacanta
            // 
            this.btnVacanta.Location = new System.Drawing.Point(13, 139);
            this.btnVacanta.Name = "btnVacanta";
            this.btnVacanta.Size = new System.Drawing.Size(108, 73);
            this.btnVacanta.TabIndex = 2;
            this.btnVacanta.Text = "Alege vacanta";
            this.btnVacanta.UseVisualStyleBackColor = true;
            this.btnVacanta.Click += new System.EventHandler(this.menuVacanta_Click);
            // 
            // txtVacanta
            // 
            this.txtVacanta.Location = new System.Drawing.Point(144, 49);
            this.txtVacanta.Multiline = true;
            this.txtVacanta.Name = "txtVacanta";
            this.txtVacanta.ReadOnly = true;
            this.txtVacanta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVacanta.Size = new System.Drawing.Size(281, 163);
            this.txtVacanta.TabIndex = 3;
            // 
            // Turism
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 230);
            this.Controls.Add(this.txtVacanta);
            this.Controls.Add(this.btnVacanta);
            this.Controls.Add(this.btnDatePersonale);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Turism";
            this.Text = "Agenție turism";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDatePersonale;
        private System.Windows.Forms.ToolStripMenuItem menuVacanta;
        private System.Windows.Forms.Button btnDatePersonale;
        private System.Windows.Forms.Button btnVacanta;
        private System.Windows.Forms.TextBox txtVacanta;
    }
}

