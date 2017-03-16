namespace WindowsFormsApplication2
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
            this.components = new System.ComponentModel.Container();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtBoxTotal = new System.Windows.Forms.TextBox();
            this.btnReset1 = new System.Windows.Forms.Button();
            this.rtBoxPrimes = new System.Windows.Forms.RichTextBox();
            this.numUpDownLB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numUpDownUB = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.rtBoxSpecGen = new System.Windows.Forms.RichTextBox();
            this.btnSpecGen = new System.Windows.Forms.Button();
            this.txtBoxSpecNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset2 = new System.Windows.Forms.Button();
            this.timerSpecGen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUB)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(11, 365);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(206, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate primes";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxTotal
            // 
            this.txtBoxTotal.Location = new System.Drawing.Point(96, 67);
            this.txtBoxTotal.Name = "txtBoxTotal";
            this.txtBoxTotal.ReadOnly = true;
            this.txtBoxTotal.Size = new System.Drawing.Size(121, 20);
            this.txtBoxTotal.TabIndex = 3;
            // 
            // btnReset1
            // 
            this.btnReset1.Location = new System.Drawing.Point(11, 394);
            this.btnReset1.Name = "btnReset1";
            this.btnReset1.Size = new System.Drawing.Size(206, 23);
            this.btnReset1.TabIndex = 4;
            this.btnReset1.Text = "Reset^";
            this.btnReset1.UseVisualStyleBackColor = true;
            this.btnReset1.Click += new System.EventHandler(this.button2_Click);
            // 
            // rtBoxPrimes
            // 
            this.rtBoxPrimes.Location = new System.Drawing.Point(11, 144);
            this.rtBoxPrimes.Name = "rtBoxPrimes";
            this.rtBoxPrimes.ReadOnly = true;
            this.rtBoxPrimes.Size = new System.Drawing.Size(206, 215);
            this.rtBoxPrimes.TabIndex = 5;
            this.rtBoxPrimes.Text = "";
            // 
            // numUpDownLB
            // 
            this.numUpDownLB.Location = new System.Drawing.Point(96, 11);
            this.numUpDownLB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUpDownLB.Name = "numUpDownLB";
            this.numUpDownLB.Size = new System.Drawing.Size(121, 20);
            this.numUpDownLB.TabIndex = 6;
            this.numUpDownLB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownLB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.numUpDownLB_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lower bound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Upper bound:";
            // 
            // numUpDownUB
            // 
            this.numUpDownUB.Location = new System.Drawing.Point(96, 39);
            this.numUpDownUB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUpDownUB.Name = "numUpDownUB";
            this.numUpDownUB.Size = new System.Drawing.Size(121, 20);
            this.numUpDownUB.TabIndex = 9;
            this.numUpDownUB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownUB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.numUpDownUB_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total primes:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 109);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(206, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Primes in interval:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(11, 423);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(206, 23);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export to file...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rtBoxSpecGen
            // 
            this.rtBoxSpecGen.Location = new System.Drawing.Point(224, 144);
            this.rtBoxSpecGen.Name = "rtBoxSpecGen";
            this.rtBoxSpecGen.ReadOnly = true;
            this.rtBoxSpecGen.Size = new System.Drawing.Size(206, 215);
            this.rtBoxSpecGen.TabIndex = 14;
            this.rtBoxSpecGen.Text = "";
            // 
            // btnSpecGen
            // 
            this.btnSpecGen.Location = new System.Drawing.Point(224, 365);
            this.btnSpecGen.Name = "btnSpecGen";
            this.btnSpecGen.Size = new System.Drawing.Size(206, 23);
            this.btnSpecGen.TabIndex = 15;
            this.btnSpecGen.Text = "Generate the specified number of primes";
            this.btnSpecGen.UseVisualStyleBackColor = true;
            this.btnSpecGen.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // txtBoxSpecNumber
            // 
            this.txtBoxSpecNumber.Location = new System.Drawing.Point(224, 109);
            this.txtBoxSpecNumber.MaxLength = 1000000;
            this.txtBoxSpecNumber.Name = "txtBoxSpecNumber";
            this.txtBoxSpecNumber.Size = new System.Drawing.Size(206, 20);
            this.txtBoxSpecNumber.TabIndex = 16;
            this.txtBoxSpecNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSpecNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "How many primes to be generated?";
            // 
            // btnReset2
            // 
            this.btnReset2.Location = new System.Drawing.Point(224, 394);
            this.btnReset2.Name = "btnReset2";
            this.btnReset2.Size = new System.Drawing.Size(206, 23);
            this.btnReset2.TabIndex = 18;
            this.btnReset2.Text = "Reset^";
            this.btnReset2.UseVisualStyleBackColor = true;
            this.btnReset2.Click += new System.EventHandler(this.btnReset2_Click);
            // 
            // timerSpecGen
            // 
            this.timerSpecGen.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 461);
            this.Controls.Add(this.btnReset2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxSpecNumber);
            this.Controls.Add(this.btnSpecGen);
            this.Controls.Add(this.rtBoxSpecGen);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUpDownUB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numUpDownLB);
            this.Controls.Add(this.rtBoxPrimes);
            this.Controls.Add(this.btnReset1);
            this.Controls.Add(this.txtBoxTotal);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Prime generator";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownUB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtBoxTotal;
        private System.Windows.Forms.Button btnReset1;
        private System.Windows.Forms.RichTextBox rtBoxPrimes;
        private System.Windows.Forms.NumericUpDown numUpDownLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDownUB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RichTextBox rtBoxSpecGen;
        private System.Windows.Forms.Button btnSpecGen;
        private System.Windows.Forms.TextBox txtBoxSpecNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset2;
        private System.Windows.Forms.Timer timerSpecGen;
    }
}

