namespace picture_puzzle
{
    partial class formPicturePuzzle
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Scramble = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuShowSolution});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoadPicture,
            this.mnuFile_Scramble,
            this.mnuFile_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuLoadPicture
            // 
            this.mnuLoadPicture.Name = "mnuLoadPicture";
            this.mnuLoadPicture.Size = new System.Drawing.Size(140, 22);
            this.mnuLoadPicture.Text = "&Load Picture";
            this.mnuLoadPicture.Click += new System.EventHandler(this.mnuLoadPicture_Click);
            // 
            // mnuFile_Scramble
            // 
            this.mnuFile_Scramble.Name = "mnuFile_Scramble";
            this.mnuFile_Scramble.Size = new System.Drawing.Size(140, 22);
            this.mnuFile_Scramble.Text = "&Scramble";
            this.mnuFile_Scramble.Click += new System.EventHandler(this.mnuFile_Scramble_Click);
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.Size = new System.Drawing.Size(140, 22);
            this.mnuFile_Exit.Text = "E&xit";
            this.mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
            // 
            // mnuShowSolution
            // 
            this.mnuShowSolution.Name = "mnuShowSolution";
            this.mnuShowSolution.Size = new System.Drawing.Size(95, 20);
            this.mnuShowSolution.Text = "&Show Solution";
            this.mnuShowSolution.Click += new System.EventHandler(this.mnuShowSolution_Click);
            // 
            // formPicturePuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formPicturePuzzle";
            this.Text = "Picture Puzzle";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadPicture;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Scramble;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuShowSolution;
    }
}

