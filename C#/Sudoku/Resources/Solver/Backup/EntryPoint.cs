
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PeterMoon.GamesUtils.SudokuSolver
{

	/// <summary>
	/// Entry point for the application.
	/// </summary>
	internal static class EntryPoint
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SudokuForm());
		}

	}
}
