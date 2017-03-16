using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PeterMoon.GamesUtils.SudokuSolver
{

	public partial class SudokuDetails : Form
	{
		public SudokuDetails(string details)
		{
			this.InitializeComponent();
			this.detailsTextBox.Text = details;
		}
	}
}