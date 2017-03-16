namespace Turism
{
    partial class DP
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
            this.lbNume = new System.Windows.Forms.Label();
            this.lbPrenume = new System.Windows.Forms.Label();
            this.lbDataNasterii = new System.Windows.Forms.Label();
            this.lbJudet = new System.Windows.Forms.Label();
            this.lbCNP = new System.Windows.Forms.Label();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.txtPrenume = new System.Windows.Forms.TextBox();
            this.txtCNP = new System.Windows.Forms.TextBox();
            this.dtpDataNasterii = new System.Windows.Forms.DateTimePicker();
            this.cbJudet = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRevocate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNume
            // 
            this.lbNume.AutoSize = true;
            this.lbNume.Location = new System.Drawing.Point(13, 28);
            this.lbNume.Name = "lbNume";
            this.lbNume.Size = new System.Drawing.Size(38, 13);
            this.lbNume.TabIndex = 7;
            this.lbNume.Text = "Nume:";
            // 
            // lbPrenume
            // 
            this.lbPrenume.AutoSize = true;
            this.lbPrenume.Location = new System.Drawing.Point(13, 76);
            this.lbPrenume.Name = "lbPrenume";
            this.lbPrenume.Size = new System.Drawing.Size(52, 13);
            this.lbPrenume.TabIndex = 8;
            this.lbPrenume.Text = "Prenume:";
            // 
            // lbDataNasterii
            // 
            this.lbDataNasterii.AutoSize = true;
            this.lbDataNasterii.Location = new System.Drawing.Point(13, 172);
            this.lbDataNasterii.Name = "lbDataNasterii";
            this.lbDataNasterii.Size = new System.Drawing.Size(69, 13);
            this.lbDataNasterii.TabIndex = 10;
            this.lbDataNasterii.Text = "Data nasterii:";
            // 
            // lbJudet
            // 
            this.lbJudet.AutoSize = true;
            this.lbJudet.Location = new System.Drawing.Point(13, 220);
            this.lbJudet.Name = "lbJudet";
            this.lbJudet.Size = new System.Drawing.Size(36, 13);
            this.lbJudet.TabIndex = 11;
            this.lbJudet.Text = "Judet:";
            // 
            // lbCNP
            // 
            this.lbCNP.AutoSize = true;
            this.lbCNP.Location = new System.Drawing.Point(13, 124);
            this.lbCNP.Name = "lbCNP";
            this.lbCNP.Size = new System.Drawing.Size(32, 13);
            this.lbCNP.TabIndex = 9;
            this.lbCNP.Text = "CNP:";
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(97, 28);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(200, 20);
            this.txtNume.TabIndex = 0;
            // 
            // txtPrenume
            // 
            this.txtPrenume.Location = new System.Drawing.Point(97, 76);
            this.txtPrenume.Name = "txtPrenume";
            this.txtPrenume.Size = new System.Drawing.Size(200, 20);
            this.txtPrenume.TabIndex = 1;
            // 
            // txtCNP
            // 
            this.txtCNP.Location = new System.Drawing.Point(97, 116);
            this.txtCNP.MaxLength = 13;
            this.txtCNP.Name = "txtCNP";
            this.txtCNP.Size = new System.Drawing.Size(100, 20);
            this.txtCNP.TabIndex = 2;
            this.txtCNP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCNP_KeyPress);
            // 
            // dtpDataNasterii
            // 
            this.dtpDataNasterii.Location = new System.Drawing.Point(97, 172);
            this.dtpDataNasterii.Name = "dtpDataNasterii";
            this.dtpDataNasterii.Size = new System.Drawing.Size(200, 20);
            this.dtpDataNasterii.TabIndex = 3;
            // 
            // cbJudet
            // 
            this.cbJudet.FormattingEnabled = true;
            this.cbJudet.Items.AddRange(new object[] {
            "Alba",
            "Bucuresti",
            "Dambovita"});
            this.cbJudet.Location = new System.Drawing.Point(97, 220);
            this.cbJudet.Name = "cbJudet";
            this.cbJudet.Size = new System.Drawing.Size(121, 21);
            this.cbJudet.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(384, 191);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRevocate
            // 
            this.btnRevocate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRevocate.Location = new System.Drawing.Point(384, 220);
            this.btnRevocate.Name = "btnRevocate";
            this.btnRevocate.Size = new System.Drawing.Size(75, 23);
            this.btnRevocate.TabIndex = 6;
            this.btnRevocate.Text = "Revocare";
            this.btnRevocate.UseVisualStyleBackColor = true;
            // 
            // DP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 255);
            this.Controls.Add(this.btnRevocate);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbJudet);
            this.Controls.Add(this.dtpDataNasterii);
            this.Controls.Add(this.txtCNP);
            this.Controls.Add(this.txtPrenume);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.lbCNP);
            this.Controls.Add(this.lbJudet);
            this.Controls.Add(this.lbDataNasterii);
            this.Controls.Add(this.lbPrenume);
            this.Controls.Add(this.lbNume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DP";
            this.Text = "Date personale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNume;
        private System.Windows.Forms.Label lbPrenume;
        private System.Windows.Forms.Label lbDataNasterii;
        private System.Windows.Forms.Label lbJudet;
        private System.Windows.Forms.Label lbCNP;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtPrenume;
        private System.Windows.Forms.TextBox txtCNP;
        private System.Windows.Forms.DateTimePicker dtpDataNasterii;
        private System.Windows.Forms.ComboBox cbJudet;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRevocate;
    }
}