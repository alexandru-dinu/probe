namespace Sudoku
{
    partial class ColorCodes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorCodes));
            this.lblRoyalBlue = new System.Windows.Forms.Label();
            this.lblDarkBlue = new System.Windows.Forms.Label();
            this.lblOrangeRed = new System.Windows.Forms.Label();
            this.lbGreen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRoyalBlue
            // 
            this.lblRoyalBlue.AutoSize = true;
            this.lblRoyalBlue.BackColor = System.Drawing.Color.Transparent;
            this.lblRoyalBlue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRoyalBlue.Location = new System.Drawing.Point(13, 13);
            this.lblRoyalBlue.Name = "lblRoyalBlue";
            this.lblRoyalBlue.Size = new System.Drawing.Size(229, 16);
            this.lblRoyalBlue.TabIndex = 0;
            this.lblRoyalBlue.Text = "Automatically generated numbers";
            // 
            // lblDarkBlue
            // 
            this.lblDarkBlue.AutoSize = true;
            this.lblDarkBlue.BackColor = System.Drawing.Color.Transparent;
            this.lblDarkBlue.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDarkBlue.Location = new System.Drawing.Point(13, 34);
            this.lblDarkBlue.Name = "lblDarkBlue";
            this.lblDarkBlue.Size = new System.Drawing.Size(118, 16);
            this.lblDarkBlue.TabIndex = 1;
            this.lblDarkBlue.Text = "Player\'s numbers";
            // 
            // lblOrangeRed
            // 
            this.lblOrangeRed.AutoSize = true;
            this.lblOrangeRed.BackColor = System.Drawing.Color.Transparent;
            this.lblOrangeRed.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOrangeRed.Location = new System.Drawing.Point(13, 55);
            this.lblOrangeRed.Name = "lblOrangeRed";
            this.lblOrangeRed.Size = new System.Drawing.Size(166, 16);
            this.lblOrangeRed.TabIndex = 2;
            this.lblOrangeRed.Text = "Hint generated numbers";
            // 
            // lbGreen
            // 
            this.lbGreen.AutoSize = true;
            this.lbGreen.BackColor = System.Drawing.Color.Transparent;
            this.lbGreen.ForeColor = System.Drawing.Color.Green;
            this.lbGreen.Location = new System.Drawing.Point(13, 76);
            this.lbGreen.Name = "lbGreen";
            this.lbGreen.Size = new System.Drawing.Size(292, 16);
            this.lbGreen.TabIndex = 3;
            this.lbGreen.Text = "Puzzle\'s solution (automatically generated)";
            // 
            // ColorCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(304, 101);
            this.Controls.Add(this.lbGreen);
            this.Controls.Add(this.lblOrangeRed);
            this.Controls.Add(this.lblDarkBlue);
            this.Controls.Add(this.lblRoyalBlue);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ColorCodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color Codes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRoyalBlue;
        private System.Windows.Forms.Label lblDarkBlue;
        private System.Windows.Forms.Label lblOrangeRed;
        private System.Windows.Forms.Label lbGreen;
    }
}