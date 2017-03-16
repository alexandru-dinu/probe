namespace Ecuatia_de_gradul_al_doilea
{
    partial class Rezolva
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
            this.txta = new System.Windows.Forms.TextBox();
            this.txtb = new System.Windows.Forms.TextBox();
            this.txtc = new System.Windows.Forms.TextBox();
            this.btnRezolva = new System.Windows.Forms.Button();
            this.btnVizualizare = new System.Windows.Forms.Button();
            this.btnTrimite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txta
            // 
            this.txta.Location = new System.Drawing.Point(134, 13);
            this.txta.Name = "txta";
            this.txta.Size = new System.Drawing.Size(148, 20);
            this.txta.TabIndex = 0;
            this.txta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txta_KeyPress);
            // 
            // txtb
            // 
            this.txtb.Location = new System.Drawing.Point(134, 41);
            this.txtb.Name = "txtb";
            this.txtb.Size = new System.Drawing.Size(148, 20);
            this.txtb.TabIndex = 1;
            this.txtb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txta_KeyPress);
            // 
            // txtc
            // 
            this.txtc.Location = new System.Drawing.Point(134, 67);
            this.txtc.Name = "txtc";
            this.txtc.Size = new System.Drawing.Size(148, 20);
            this.txtc.TabIndex = 2;
            this.txtc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txta_KeyPress);
            // 
            // btnRezolva
            // 
            this.btnRezolva.Location = new System.Drawing.Point(12, 96);
            this.btnRezolva.Name = "btnRezolva";
            this.btnRezolva.Size = new System.Drawing.Size(75, 23);
            this.btnRezolva.TabIndex = 3;
            this.btnRezolva.Text = "Rezolvă";
            this.btnRezolva.UseVisualStyleBackColor = true;
            this.btnRezolva.Click += new System.EventHandler(this.btnRezolva_Click);
            // 
            // btnVizualizare
            // 
            this.btnVizualizare.Location = new System.Drawing.Point(104, 96);
            this.btnVizualizare.Name = "btnVizualizare";
            this.btnVizualizare.Size = new System.Drawing.Size(75, 23);
            this.btnVizualizare.TabIndex = 4;
            this.btnVizualizare.Text = "Vizualizează";
            this.btnVizualizare.UseVisualStyleBackColor = true;
            this.btnVizualizare.Click += new System.EventHandler(this.btnVizualizare_Click);
            // 
            // btnTrimite
            // 
            this.btnTrimite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTrimite.Location = new System.Drawing.Point(196, 96);
            this.btnTrimite.Name = "btnTrimite";
            this.btnTrimite.Size = new System.Drawing.Size(75, 23);
            this.btnTrimite.TabIndex = 5;
            this.btnTrimite.Text = "Trimite";
            this.btnTrimite.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Primul coeficient : a = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Al doilea coeficient : b = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Al treilea coeficient : c = ";
            // 
            // Rezolva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 122);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrimite);
            this.Controls.Add(this.btnVizualizare);
            this.Controls.Add(this.btnRezolva);
            this.Controls.Add(this.txtc);
            this.Controls.Add(this.txtb);
            this.Controls.Add(this.txta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Rezolva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ecuația de gradul al doilea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txta;
        private System.Windows.Forms.TextBox txtb;
        private System.Windows.Forms.TextBox txtc;
        private System.Windows.Forms.Button btnRezolva;
        private System.Windows.Forms.Button btnVizualizare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnTrimite;
    }
}

