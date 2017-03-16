namespace _33_QuebraCabeca
{
    partial class Form2
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
            this.pcb_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pcb_image
            // 
            this.pcb_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcb_image.Location = new System.Drawing.Point(0, 0);
            this.pcb_image.Name = "pcb_image";
            this.pcb_image.Size = new System.Drawing.Size(456, 338);
            this.pcb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_image.TabIndex = 0;
            this.pcb_image.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 338);
            this.Controls.Add(this.pcb_image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Imagem";
            ((System.ComponentModel.ISupportInitialize)(this.pcb_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pcb_image;

    }
}