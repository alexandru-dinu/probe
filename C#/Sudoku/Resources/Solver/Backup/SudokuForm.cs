using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PeterMoon.GamesUtils.SudokuSolver
{
	public partial class SudokuForm : Form
	{

		#region Constructor...

		/// <summary>
		/// Constructors for this form.
		/// </summary>
		public SudokuForm()
		{
			this.InitializeComponent();
			
			this.solutionDetails = new StringBuilder();

			this.CreateSudokuBoard();
		}

		#endregion

		#region Fields...

		/// <summary>
		/// Graphic Sudoku board (bi-dimensional TextBox array).
		/// </summary>
		private TextBox[,] graphicSudokuBoard;

		/// <summary>
		/// Details of the strategies used for solve the Sudoku board.
		/// </summary>
		private StringBuilder solutionDetails;

		#endregion

		#region Methods...

		/// <summary>
		/// Create a visual Sudoku board
		/// </summary>
		private void CreateSudokuBoard()
		{
			int sudokuTableMargin = this.solveButton.Left;
			int x = sudokuTableMargin, y = sudokuTableMargin;
			int tabIndex = 0, textBoxHeight = 0;

			this.graphicSudokuBoard = new TextBox[9, 9];

			for (int row = 0; row < 9; row++)
			{
				x = sudokuTableMargin;

				for (int col = 0; col < 9; col++)
				{
					TextBox textBox = new TextBox();
					textBox.BorderStyle = BorderStyle.FixedSingle;
					textBox.Font = new Font(textBox.Font.FontFamily, 24F, FontStyle.Bold);
					textBox.MaxLength = 1;
					textBox.TextAlign = HorizontalAlignment.Center;
					textBox.Width = textBox.Height;
					textBox.TextChanged += new EventHandler(this.textBox_TextChanged);
					textBox.TabIndex = tabIndex++;

					textBox.Location = new Point(x, y);
					this.Controls.Add(textBox);

					this.graphicSudokuBoard[row, col] = textBox;
					textBoxHeight = textBox.Height;

					x += textBox.Width - 1;
					if (col % 3 == 2)
						x++;
				}

				y += textBoxHeight - 1;
				if (row % 3 == 2)
					y++;
			}
		}

		/// <summary>
		/// TextChanged handler for the visual Sudoku cells (TextBox).
		/// </summary>
		private void textBox_TextChanged(object sender, EventArgs e)
		{
			TextBox textBox = (TextBox) sender;
			this.ValidateSudokuTextBox(textBox);
			textBox.BackColor = Color.Empty;
		}

		/// <summary>
		/// Handler for the Click event for the clearButton control.
		/// </summary>
		private void clearButton_Click(object sender, EventArgs e)
		{
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					this.graphicSudokuBoard[row, col].ReadOnly = false;
					this.graphicSudokuBoard[row, col].Text = string.Empty;
					this.graphicSudokuBoard[row, col].BackColor = Color.Empty;
				}
			}

			this.graphicSudokuBoard[0, 0].Focus();

			this.solutionDetails.Length = 0;
			this.solveButton.Enabled = true;
			this.viewStepsButton.Enabled = false;
		}

		/// <summary>
		/// Validate the content of a Sudoku cell.
		/// </summary>
		/// <param name="textBox">Textbox which represents a visual Sudoku cell.</param>
		private void ValidateSudokuTextBox(TextBox textBox)
		{
			if (textBox.TextLength == 1)
			{
				if (textBox.Text[0] < '1' || textBox.Text[0] > '9')
				{
					textBox.Text = string.Empty;
				}
			}
			else if (textBox.TextLength > 1)
			{
				if (textBox.Text[0] < '1' || textBox.Text[0] > '9')
				{
					textBox.Text = string.Empty;
				}
				else
				{
					textBox.Text = textBox.Text.Substring(0, 1);
				}
			}
		}

		/// <summary>
		/// Handler for the Click event for the solveButton control.
		/// </summary>
		private void solveButton_Click(object sender, EventArgs e)
		{

			// Prepare the board...
			SudokuTable sudokuTable = new SudokuTable();
			sudokuTable.SudokuStrategyUsed += 
				new SudokuStrategyUsedEventHandler(this.sudokuTable_SudokuStrategyUsed);
			solutionDetails.Length = 0;

			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					this.ValidateSudokuTextBox(this.graphicSudokuBoard[row, col]);

					if (this.graphicSudokuBoard[row, col].TextLength == 1)
					{
						try
						{
							sudokuTable.SetValue(row, col, Convert.ToInt32(this.graphicSudokuBoard[row, col].Text));
						}
						catch (ApplicationException ex)
						{
							this.graphicSudokuBoard[row, col].BackColor = Color.Pink;
							this.graphicSudokuBoard[row, col].Focus();
							MessageBox.Show(ex.Message);
							return;
						}
					}
				}
			}

			// Solve!!
			long ticksStart, ticksStop;

			try
			{
				ticksStart = DateTime.Now.Ticks;
				sudokuTable.Solve();
				ticksStop = DateTime.Now.Ticks;
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message + Environment.NewLine + sudokuTable.ToString());
				return;
			}

			// Copy the results to show...
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					this.graphicSudokuBoard[row, col].Text = sudokuTable[row, col].Value.ToString();
					this.graphicSudokuBoard[row, col].ReadOnly = true;
				}
			}

			this.solveButton.Enabled = false;
			this.viewStepsButton.Enabled = true;

			MessageBox.Show(string.Format(
				"Solution found in {0} seconds"
				, (new TimeSpan(ticksStop - ticksStart)).Milliseconds / 1000.0));

		}

		/// <summary>
		/// Handler for the SudokuStrategyUsed event.
		/// </summary>
		private void sudokuTable_SudokuStrategyUsed(object sender, SudokuStrategyUsedEventArgs e)
		{
			this.solutionDetails.AppendFormat(
				"{0}: Cell [{1}, {2}] = {3}", e.Strategy, e.Row + 1, e.Col + 1, e.Value);
			this.solutionDetails.AppendLine();
		}

		/// <summary>
		/// Handler for the Click event for the viewStepsButton control.
		/// </summary>
		private void viewStepsButton_Click(object sender, EventArgs e)
		{
			SudokuDetails details = new SudokuDetails(this.solutionDetails.ToString());
			details.ShowDialog();
		}

		/// <summary>
		/// Handler for the Load event for the form.
		/// </summary>
		private void SudokuForm_Load(object sender, EventArgs e)
		{
			this.clearButton.PerformClick();
		}

		#endregion


	}
}