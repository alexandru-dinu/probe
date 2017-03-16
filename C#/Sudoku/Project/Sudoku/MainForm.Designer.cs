namespace Sudoku
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnGenerateEasy = new System.Windows.Forms.Button();
            this.lvlGroupBox = new System.Windows.Forms.GroupBox();
            this.btnGenerateHard = new System.Windows.Forms.Button();
            this.btnGenerateMedium = new System.Windows.Forms.Button();
            this.envGroupBox = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.lblTmrDisplay = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.loadBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.board2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.board3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.board4ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.board5ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.board1ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.board2ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.board3ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.board4ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.board5ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvlGroupBox.SuspendLayout();
            this.envGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateEasy
            // 
            this.btnGenerateEasy.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateEasy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateEasy.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnGenerateEasy.Location = new System.Drawing.Point(6, 19);
            this.btnGenerateEasy.Name = "btnGenerateEasy";
            this.btnGenerateEasy.Size = new System.Drawing.Size(151, 32);
            this.btnGenerateEasy.TabIndex = 0;
            this.btnGenerateEasy.Text = "Easy";
            this.btnGenerateEasy.UseVisualStyleBackColor = false;
            this.btnGenerateEasy.Click += new System.EventHandler(this.btnGenerateEasy_Click);
            // 
            // lvlGroupBox
            // 
            this.lvlGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.lvlGroupBox.Controls.Add(this.btnGenerateHard);
            this.lvlGroupBox.Controls.Add(this.btnGenerateMedium);
            this.lvlGroupBox.Controls.Add(this.btnGenerateEasy);
            this.lvlGroupBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lvlGroupBox.Location = new System.Drawing.Point(436, 34);
            this.lvlGroupBox.Name = "lvlGroupBox";
            this.lvlGroupBox.Size = new System.Drawing.Size(163, 140);
            this.lvlGroupBox.TabIndex = 1;
            this.lvlGroupBox.TabStop = false;
            this.lvlGroupBox.Text = "Generate board";
            // 
            // btnGenerateHard
            // 
            this.btnGenerateHard.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateHard.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateHard.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnGenerateHard.Location = new System.Drawing.Point(6, 95);
            this.btnGenerateHard.Name = "btnGenerateHard";
            this.btnGenerateHard.Size = new System.Drawing.Size(151, 32);
            this.btnGenerateHard.TabIndex = 2;
            this.btnGenerateHard.Text = "Hard";
            this.btnGenerateHard.UseVisualStyleBackColor = false;
            this.btnGenerateHard.Click += new System.EventHandler(this.btnGenerateHard_Click);
            // 
            // btnGenerateMedium
            // 
            this.btnGenerateMedium.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerateMedium.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateMedium.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnGenerateMedium.Location = new System.Drawing.Point(6, 57);
            this.btnGenerateMedium.Name = "btnGenerateMedium";
            this.btnGenerateMedium.Size = new System.Drawing.Size(151, 32);
            this.btnGenerateMedium.TabIndex = 1;
            this.btnGenerateMedium.Text = "Medium";
            this.btnGenerateMedium.UseVisualStyleBackColor = false;
            this.btnGenerateMedium.Click += new System.EventHandler(this.btnGenerateMedium_Click);
            // 
            // envGroupBox
            // 
            this.envGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.envGroupBox.Controls.Add(this.btnCheck);
            this.envGroupBox.Controls.Add(this.btnExit);
            this.envGroupBox.Controls.Add(this.btnReset);
            this.envGroupBox.Controls.Add(this.btnSolve);
            this.envGroupBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.envGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.envGroupBox.Location = new System.Drawing.Point(436, 180);
            this.envGroupBox.Name = "envGroupBox";
            this.envGroupBox.Size = new System.Drawing.Size(163, 180);
            this.envGroupBox.TabIndex = 2;
            this.envGroupBox.TabStop = false;
            this.envGroupBox.Text = "Environment";
            // 
            // btnCheck
            // 
            this.btnCheck.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCheck.Location = new System.Drawing.Point(6, 23);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(151, 32);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Check board";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Location = new System.Drawing.Point(6, 137);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(151, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit game";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnReset.Location = new System.Drawing.Point(6, 99);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(151, 32);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset board";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSolve.Location = new System.Drawing.Point(6, 61);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(151, 32);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve board";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.statusGroupBox.Controls.Add(this.lblTmrDisplay);
            this.statusGroupBox.Controls.Add(this.lblSeconds);
            this.statusGroupBox.Controls.Add(this.lblStatus);
            this.statusGroupBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.statusGroupBox.Location = new System.Drawing.Point(436, 366);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(163, 83);
            this.statusGroupBox.TabIndex = 3;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Status";
            // 
            // lblTmrDisplay
            // 
            this.lblTmrDisplay.AutoSize = true;
            this.lblTmrDisplay.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTmrDisplay.Location = new System.Drawing.Point(47, 63);
            this.lblTmrDisplay.Name = "lblTmrDisplay";
            this.lblTmrDisplay.Size = new System.Drawing.Size(117, 16);
            this.lblTmrDisplay.TabIndex = 2;
            this.lblTmrDisplay.Text = "seconds elapsed";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.Location = new System.Drawing.Point(6, 57);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(22, 23);
            this.lblSeconds.TabIndex = 1;
            this.lblSeconds.Text = "0";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatus.Location = new System.Drawing.Point(7, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(109, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "awaiting user...";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBoardToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.colorCodesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(604, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // loadBoardToolStripMenuItem
            // 
            this.loadBoardToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.loadBoardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.loadBoardToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.loadBoardToolStripMenuItem.Name = "loadBoardToolStripMenuItem";
            this.loadBoardToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.loadBoardToolStripMenuItem.Text = "Load board";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.board1ToolStripMenuItem,
            this.board2ToolStripMenuItem,
            this.board3ToolStripMenuItem,
            this.board4ToolStripMenuItem,
            this.board5ToolStripMenuItem});
            this.easyToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.easyToolStripMenuItem.Text = "Easy";
            // 
            // board1ToolStripMenuItem
            // 
            this.board1ToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board1ToolStripMenuItem.Name = "board1ToolStripMenuItem";
            this.board1ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.board1ToolStripMenuItem.Text = "Board 1";
            this.board1ToolStripMenuItem.Click += new System.EventHandler(this.board1ToolStripMenuItem_Click);
            // 
            // board2ToolStripMenuItem
            // 
            this.board2ToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board2ToolStripMenuItem.Name = "board2ToolStripMenuItem";
            this.board2ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.board2ToolStripMenuItem.Text = "Board 2";
            this.board2ToolStripMenuItem.Click += new System.EventHandler(this.board2ToolStripMenuItem_Click);
            // 
            // board3ToolStripMenuItem
            // 
            this.board3ToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board3ToolStripMenuItem.Name = "board3ToolStripMenuItem";
            this.board3ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.board3ToolStripMenuItem.Text = "Board 3";
            this.board3ToolStripMenuItem.Click += new System.EventHandler(this.board3ToolStripMenuItem_Click);
            // 
            // board4ToolStripMenuItem
            // 
            this.board4ToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board4ToolStripMenuItem.Name = "board4ToolStripMenuItem";
            this.board4ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.board4ToolStripMenuItem.Text = "Board 4";
            this.board4ToolStripMenuItem.Click += new System.EventHandler(this.board4ToolStripMenuItem_Click);
            // 
            // board5ToolStripMenuItem
            // 
            this.board5ToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board5ToolStripMenuItem.Name = "board5ToolStripMenuItem";
            this.board5ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.board5ToolStripMenuItem.Text = "Board 5";
            this.board5ToolStripMenuItem.Click += new System.EventHandler(this.board5ToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.board1ToolStripMenuItem1,
            this.board2ToolStripMenuItem1,
            this.board3ToolStripMenuItem1,
            this.board4ToolStripMenuItem1,
            this.board5ToolStripMenuItem1});
            this.mediumToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.mediumToolStripMenuItem.Text = "Medium";
            // 
            // board1ToolStripMenuItem1
            // 
            this.board1ToolStripMenuItem1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board1ToolStripMenuItem1.Name = "board1ToolStripMenuItem1";
            this.board1ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.board1ToolStripMenuItem1.Text = "Board 1";
            this.board1ToolStripMenuItem1.Click += new System.EventHandler(this.board1ToolStripMenuItem1_Click);
            // 
            // board2ToolStripMenuItem1
            // 
            this.board2ToolStripMenuItem1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board2ToolStripMenuItem1.Name = "board2ToolStripMenuItem1";
            this.board2ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.board2ToolStripMenuItem1.Text = "Board 2";
            this.board2ToolStripMenuItem1.Click += new System.EventHandler(this.board2ToolStripMenuItem1_Click);
            // 
            // board3ToolStripMenuItem1
            // 
            this.board3ToolStripMenuItem1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board3ToolStripMenuItem1.Name = "board3ToolStripMenuItem1";
            this.board3ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.board3ToolStripMenuItem1.Text = "Board 3";
            this.board3ToolStripMenuItem1.Click += new System.EventHandler(this.board3ToolStripMenuItem1_Click);
            // 
            // board4ToolStripMenuItem1
            // 
            this.board4ToolStripMenuItem1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board4ToolStripMenuItem1.Name = "board4ToolStripMenuItem1";
            this.board4ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.board4ToolStripMenuItem1.Text = "Board 4";
            this.board4ToolStripMenuItem1.Click += new System.EventHandler(this.board4ToolStripMenuItem1_Click);
            // 
            // board5ToolStripMenuItem1
            // 
            this.board5ToolStripMenuItem1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board5ToolStripMenuItem1.Name = "board5ToolStripMenuItem1";
            this.board5ToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.board5ToolStripMenuItem1.Text = "Board 5";
            this.board5ToolStripMenuItem1.Click += new System.EventHandler(this.board5ToolStripMenuItem1_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.board1ToolStripMenuItem2,
            this.board2ToolStripMenuItem2,
            this.board3ToolStripMenuItem2,
            this.board4ToolStripMenuItem2,
            this.board5ToolStripMenuItem2});
            this.hardToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.hardToolStripMenuItem.Text = "Hard";
            // 
            // board1ToolStripMenuItem2
            // 
            this.board1ToolStripMenuItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board1ToolStripMenuItem2.Name = "board1ToolStripMenuItem2";
            this.board1ToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.board1ToolStripMenuItem2.Text = "Board 1";
            this.board1ToolStripMenuItem2.Click += new System.EventHandler(this.board1ToolStripMenuItem2_Click);
            // 
            // board2ToolStripMenuItem2
            // 
            this.board2ToolStripMenuItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board2ToolStripMenuItem2.Name = "board2ToolStripMenuItem2";
            this.board2ToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.board2ToolStripMenuItem2.Text = "Board 2";
            this.board2ToolStripMenuItem2.Click += new System.EventHandler(this.board2ToolStripMenuItem2_Click);
            // 
            // board3ToolStripMenuItem2
            // 
            this.board3ToolStripMenuItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board3ToolStripMenuItem2.Name = "board3ToolStripMenuItem2";
            this.board3ToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.board3ToolStripMenuItem2.Text = "Board 3";
            this.board3ToolStripMenuItem2.Click += new System.EventHandler(this.board3ToolStripMenuItem2_Click);
            // 
            // board4ToolStripMenuItem2
            // 
            this.board4ToolStripMenuItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board4ToolStripMenuItem2.Name = "board4ToolStripMenuItem2";
            this.board4ToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.board4ToolStripMenuItem2.Text = "Board 4";
            this.board4ToolStripMenuItem2.Click += new System.EventHandler(this.board4ToolStripMenuItem2_Click);
            // 
            // board5ToolStripMenuItem2
            // 
            this.board5ToolStripMenuItem2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.board5ToolStripMenuItem2.Name = "board5ToolStripMenuItem2";
            this.board5ToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.board5ToolStripMenuItem2.Text = "Board 5";
            this.board5ToolStripMenuItem2.Click += new System.EventHandler(this.board5ToolStripMenuItem2_Click);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.hintToolStripMenuItem.Text = "Hint";
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // colorCodesToolStripMenuItem
            // 
            this.colorCodesToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.colorCodesToolStripMenuItem.Name = "colorCodesToolStripMenuItem";
            this.colorCodesToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.colorCodesToolStripMenuItem.Text = "Color codes";
            this.colorCodesToolStripMenuItem.Click += new System.EventHandler(this.colorCodesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(604, 461);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.envGroupBox);
            this.Controls.Add(this.lvlGroupBox);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.lvlGroupBox.ResumeLayout(false);
            this.envGroupBox.ResumeLayout(false);
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateEasy;
        private System.Windows.Forms.GroupBox lvlGroupBox;
        private System.Windows.Forms.Button btnGenerateHard;
        private System.Windows.Forms.Button btnGenerateMedium;
        private System.Windows.Forms.GroupBox envGroupBox;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblTmrDisplay;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem board1ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem board2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem board3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem board4ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem board5ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem board2ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem board3ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem board4ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem board5ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorCodesToolStripMenuItem;
    }
}

