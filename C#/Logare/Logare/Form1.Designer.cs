namespace Logare
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelParola = new System.Windows.Forms.Label();
            this.LabelUtilizator = new System.Windows.Forms.Label();
            this.TextBoxParola = new System.Windows.Forms.TextBox();
            this.TextBoxUtilizator = new System.Windows.Forms.TextBox();
            this.btnAutentificare = new System.Windows.Forms.Button();
            this.btnIesire = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelParola);
            this.groupBox1.Controls.Add(this.LabelUtilizator);
            this.groupBox1.Controls.Add(this.TextBoxParola);
            this.groupBox1.Controls.Add(this.TextBoxUtilizator);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autentificare";
            // 
            // LabelParola
            // 
            this.LabelParola.AutoSize = true;
            this.LabelParola.Location = new System.Drawing.Point(68, 83);
            this.LabelParola.Name = "LabelParola";
            this.LabelParola.Size = new System.Drawing.Size(37, 13);
            this.LabelParola.TabIndex = 4;
            this.LabelParola.Text = "Parola";
            // 
            // LabelUtilizator
            // 
            this.LabelUtilizator.AutoSize = true;
            this.LabelUtilizator.Location = new System.Drawing.Point(63, 34);
            this.LabelUtilizator.Name = "LabelUtilizator";
            this.LabelUtilizator.Size = new System.Drawing.Size(47, 13);
            this.LabelUtilizator.TabIndex = 3;
            this.LabelUtilizator.Text = "Utilizator";
            // 
            // TextBoxParola
            // 
            this.TextBoxParola.Location = new System.Drawing.Point(6, 99);
            this.TextBoxParola.Name = "TextBoxParola";
            this.TextBoxParola.Size = new System.Drawing.Size(168, 20);
            this.TextBoxParola.TabIndex = 1;
            this.TextBoxParola.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxParola_PreviewKeyDown);
            // 
            // TextBoxUtilizator
            // 
            this.TextBoxUtilizator.Location = new System.Drawing.Point(6, 50);
            this.TextBoxUtilizator.Name = "TextBoxUtilizator";
            this.TextBoxUtilizator.Size = new System.Drawing.Size(168, 20);
            this.TextBoxUtilizator.TabIndex = 0;
            this.TextBoxUtilizator.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxUtilizator_PreviewKeyDown);
            // 
            // btnAutentificare
            // 
            this.btnAutentificare.Location = new System.Drawing.Point(12, 158);
            this.btnAutentificare.Name = "btnAutentificare";
            this.btnAutentificare.Size = new System.Drawing.Size(174, 23);
            this.btnAutentificare.TabIndex = 1;
            this.btnAutentificare.Text = "Autentificare";
            this.btnAutentificare.UseVisualStyleBackColor = true;
            this.btnAutentificare.Click += new System.EventHandler(this.btnAutentificare_Click);
            // 
            // btnIesire
            // 
            this.btnIesire.Location = new System.Drawing.Point(12, 187);
            this.btnIesire.Name = "btnIesire";
            this.btnIesire.Size = new System.Drawing.Size(174, 23);
            this.btnIesire.TabIndex = 2;
            this.btnIesire.Text = "Iesire";
            this.btnIesire.UseVisualStyleBackColor = true;
            this.btnIesire.Click += new System.EventHandler(this.btnIesire_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 222);
            this.Controls.Add(this.btnIesire);
            this.Controls.Add(this.btnAutentificare);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Autentificare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelUtilizator;
        private System.Windows.Forms.TextBox TextBoxParola;
        private System.Windows.Forms.TextBox TextBoxUtilizator;
        private System.Windows.Forms.Label LabelParola;
        private System.Windows.Forms.Button btnAutentificare;
        private System.Windows.Forms.Button btnIesire;
    }
}

