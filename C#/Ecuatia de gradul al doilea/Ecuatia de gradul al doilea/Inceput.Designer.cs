namespace Ecuatia_de_gradul_al_doilea
{
    partial class Inceput
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnInsereaza = new System.Windows.Forms.Button();
            this.btnIesire = new System.Windows.Forms.Button();
            this.btnCurata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(162, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(120, 98);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnInsereaza
            // 
            this.btnInsereaza.Location = new System.Drawing.Point(13, 12);
            this.btnInsereaza.Name = "btnInsereaza";
            this.btnInsereaza.Size = new System.Drawing.Size(143, 27);
            this.btnInsereaza.TabIndex = 1;
            this.btnInsereaza.Text = "Inserează o ecuație";
            this.btnInsereaza.UseVisualStyleBackColor = true;
            this.btnInsereaza.Click += new System.EventHandler(this.btnInsereaza_Click);
            // 
            // btnIesire
            // 
            this.btnIesire.Location = new System.Drawing.Point(13, 78);
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.Size = new System.Drawing.Size(143, 27);
            this.btnIesire.TabIndex = 2;
            this.btnIesire.Text = "Ieșire";
            this.btnIesire.UseVisualStyleBackColor = true;
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // btnCurata
            // 
            this.btnCurata.Location = new System.Drawing.Point(12, 45);
            this.btnCurata.Name = "btnCurata";
            this.btnCurata.Size = new System.Drawing.Size(143, 27);
            this.btnCurata.TabIndex = 3;
            this.btnCurata.Text = "Curăță";
            this.btnCurata.UseVisualStyleBackColor = true;
            this.btnCurata.Click += new System.EventHandler(this.btnCurata_Click);
            // 
            // Inceput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 122);
            this.Controls.Add(this.btnCurata);
            this.Controls.Add(this.btnIesire);
            this.Controls.Add(this.btnInsereaza);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Inceput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ecuația de gradul al doilea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnInsereaza;
        private System.Windows.Forms.Button btnIesire;
        private System.Windows.Forms.Button btnCurata;
    }
}