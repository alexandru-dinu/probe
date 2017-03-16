namespace Vizulizari
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnIesire = new System.Windows.Forms.Button();
            this.linkWordPad = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // btnIesire
            // 
            this.btnIesire.Location = new System.Drawing.Point(39, 227);
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.Size = new System.Drawing.Size(75, 23);
            this.btnIesire.TabIndex = 1;
            this.btnIesire.Text = "Ieșire";
            this.btnIesire.UseVisualStyleBackColor = true;
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // linkWordPad
            // 
            this.linkWordPad.AutoSize = true;
            this.linkWordPad.LinkArea = new System.Windows.Forms.LinkArea(20, 29);
            this.linkWordPad.Location = new System.Drawing.Point(39, 147);
            this.linkWordPad.Name = "linkWordPad";
            this.linkWordPad.Size = new System.Drawing.Size(143, 17);
            this.linkWordPad.TabIndex = 2;
            this.linkWordPad.TabStop = true;
            this.linkWordPad.Text = "Deschideți fișierul Salut.doc";
            this.linkWordPad.UseCompatibleTextRendering = true;
            this.linkWordPad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWordPad_LinkClicked);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.linkWordPad);
            this.Controls.Add(this.btnIesire);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIesire;
        private System.Windows.Forms.LinkLabel linkWordPad;

    }
}