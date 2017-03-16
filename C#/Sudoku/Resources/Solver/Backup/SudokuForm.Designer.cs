namespace PeterMoon.GamesUtils.SudokuSolver
{
	partial class SudokuForm
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.solveButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.viewStepsButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// solveButton
			// 
			this.solveButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.solveButton.Location = new System.Drawing.Point(12, 414);
			this.solveButton.Name = "solveButton";
			this.solveButton.Size = new System.Drawing.Size(125, 25);
			this.solveButton.TabIndex = 100;
			this.solveButton.Text = "Solve!";
			this.solveButton.UseVisualStyleBackColor = true;
			this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.clearButton.Location = new System.Drawing.Point(277, 414);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(125, 25);
			this.clearButton.TabIndex = 102;
			this.clearButton.Text = "Clear";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// viewStepsButton
			// 
			this.viewStepsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.viewStepsButton.Location = new System.Drawing.Point(145, 414);
			this.viewStepsButton.Name = "viewStepsButton";
			this.viewStepsButton.Size = new System.Drawing.Size(125, 25);
			this.viewStepsButton.TabIndex = 101;
			this.viewStepsButton.Text = "View steps";
			this.viewStepsButton.UseVisualStyleBackColor = true;
			this.viewStepsButton.Click += new System.EventHandler(this.viewStepsButton_Click);
			// 
			// SudokuForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.clearButton;
			this.ClientSize = new System.Drawing.Size(414, 451);
			this.Controls.Add(this.viewStepsButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.solveButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "SudokuForm";
			this.Text = "Sudoku Solver";
			this.Load += new System.EventHandler(this.SudokuForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button solveButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button viewStepsButton;

	}
}