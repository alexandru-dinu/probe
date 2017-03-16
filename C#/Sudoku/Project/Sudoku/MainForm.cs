using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Data and objects

        #region declarations
        const int cColWidth = 45;
        const int cRowHeight = 45;
        const int cMaxCell = 9;
        const int cSidelength = cColWidth * cMaxCell + 3;

        DataGridView DGV; //The two-dimensional array

        bool[,] rnd_occupied = new bool[81, 81]; //Specifies what cells have been occupied when the level was generated

        //Maximum numbers generated per level of complexity
        int max_easy = 25;
        int max_medium = 20;
        int max_hard = 10;

        bool was_generated = false;

        Random rnd = new Random(); //Random component used to generate board
        Random rnd_solve = new Random(); //Random component used to solve board

        //Time (seconds) elapsed
        int tmr_seconds = 1;

        //Range = [0,10]; 10 hints available <=> 10 times the 'hint' button can be pressed
        int available_hints = 10;

        //Preloaded boards
        bool easy_board_1_generated = false;
        bool easy_board_2_generated = false;
        bool easy_board_3_generated = false;
        bool easy_board_4_generated = false;
        bool easy_board_5_generated = false;

        bool medium_board_1_generated = false;
        bool medium_board_2_generated = false;
        bool medium_board_3_generated = false;
        bool medium_board_4_generated = false;
        bool medium_board_5_generated = false;

        bool hard_board_1_generated = false;
        bool hard_board_2_generated = false;
        bool hard_board_3_generated = false;
        bool hard_board_4_generated = false;
        bool hard_board_5_generated = false;
        #endregion

        #region default_puzzles_to_be_loaded 
        #region easy
        int[,] easy_board_1 = new int[,]
{
        { 0, 5, 0, 0, 4, 0, 0, 6, 0 },
        { 0, 7, 0, 6, 2, 5, 0, 3, 0 },
        { 8, 0, 0, 1, 0, 0, 5, 0, 0 },
        { 0, 0, 7, 5, 0, 0, 8, 0, 2 },
        { 0, 0, 9, 4, 0, 8, 7, 0, 0 },
        { 6, 0, 5, 0, 0, 1, 4, 0, 0 },
        { 0, 0, 6, 0, 0, 4, 0, 0, 9 },
        { 0, 9, 0, 3, 5, 2, 0, 7, 0 },
        { 0, 2, 0, 0, 1, 0, 0, 8, 0 },
};

        int[,] easy_board_2 = new int[,]
{
        { 2, 0, 0, 1, 0, 0, 0, 4, 3 },
        { 0, 0, 3, 0, 7, 0, 6, 0, 9 },
        { 0, 1, 0, 9, 3, 0, 2, 0, 0 },
        { 8, 2, 0, 0, 0, 0, 0, 0, 7 },
        { 0, 4, 0, 2, 8, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 3, 8, 5, 0 },
        { 0, 3, 8, 0, 0, 0, 9, 0, 0 },
        { 9, 0, 0, 8, 0, 1, 3, 7, 0 },
        { 0, 0, 4, 0, 9, 6, 0, 0, 0 },
};

        int[,] easy_board_3 = new int[,]
{
        { 0, 0, 4, 0, 0, 3, 0, 0, 2 },
        { 5, 3, 0, 0, 0, 4, 0, 6, 0 },
        { 9, 0, 0, 1, 5, 0, 7, 0, 0 },
        { 0, 0, 3, 0, 4, 0, 6, 0, 1 },
        { 4, 0, 7, 3, 8, 0, 0, 0, 0 },
        { 0, 9, 0, 0, 0, 7, 0, 0, 8 },
        { 3, 0, 0, 0, 6, 0, 0, 5, 0 },
        { 0, 2, 0, 0, 0, 9, 0, 0, 6 },
        { 0, 8, 0, 2, 0, 0, 4, 9, 0 },
};

        int[,] easy_board_4 = new int[,]
{
        { 0, 0, 1, 0, 0, 9, 0, 0, 6 },
        { 4, 0, 0, 1, 0, 6, 0, 0, 2 },
        { 0, 9, 0, 0, 5, 0, 0, 4, 0 },
        { 0, 0, 7, 0, 1, 0, 0, 8, 0 },
        { 0, 0, 0, 3, 0, 4, 7, 6, 1 },
        { 1, 0, 3, 5, 0, 0, 0, 0, 0 },
        { 8, 6, 0, 0, 0, 0, 9, 0, 0 },
        { 0, 0, 9, 0, 4, 8, 0, 7, 0 },
        { 0, 7, 0, 0, 9, 0, 2, 5, 0 },
};

        int[,] easy_board_5 = new int[,]
{
        { 0, 0, 0, 8, 0, 5, 4, 0, 0 },
        { 0, 8, 0, 3, 0, 0, 2, 6, 0 },
        { 0, 4, 3, 0, 9, 0, 0, 1, 0 },
        { 2, 7, 0, 0, 3, 0, 0, 9, 0 },
        { 5, 0, 0, 0, 0, 1, 7, 0, 4 },
        { 0, 0, 0, 2, 0, 4, 0, 5, 0 },
        { 0, 0, 0, 4, 2, 0, 0, 0, 6 },
        { 0, 0, 2, 0, 8, 0, 0, 0, 7 },
        { 8, 0, 6, 0, 0, 0, 9, 0, 2 },
};
        #endregion

        #region medium
        int[,] medium_board_1 = new int[,]
{
        { 0, 0, 3, 0, 4, 0, 0, 0, 9 },
        { 2, 4, 0, 0, 0, 9, 3, 0, 0 },
        { 0, 0, 9, 3, 0, 0, 0, 0, 2 },
        { 0, 3, 0, 6, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 0, 7, 4, 8, 0, 0 },
        { 0, 8, 6, 5, 0, 0, 0, 2, 0 },
        { 3, 0, 0, 0, 6, 0, 0, 0, 0 },
        { 9, 0, 7, 0, 8, 1, 0, 3, 0 },
        { 0, 6, 0, 0, 0, 0, 0, 7, 8 },
};

        int[,] medium_board_2 = new int[,]
{
        { 0, 6, 3, 0, 0, 0, 0, 0, 7 },
        { 0, 0, 0, 0, 6, 3, 0, 0, 0 },
        { 4, 1, 0, 0, 7, 0, 0, 0, 3 },
        { 3, 0, 0, 5, 2, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 1, 3, 5, 0 },
        { 7, 5, 0, 3, 0, 0, 0, 0, 0 },
        { 0, 0, 6, 0, 0, 0, 2, 4, 0 },
        { 1, 0, 7, 6, 0, 0, 0, 0, 5 },
        { 0, 0, 2, 8, 0, 4, 6, 0, 0 },
};

        int[,] medium_board_3 = new int[,]
{
        { 0, 3, 8, 0, 9, 0, 1, 0, 0 },
        { 0, 5, 0, 0, 0, 0, 9, 3, 0 },
        { 0, 0, 0, 7, 3, 5, 0, 0, 2 },
        { 0, 0, 6, 3, 0, 0, 0, 0, 8 },
        { 0, 8, 0, 0, 0, 0, 7, 4, 0 },
        { 3, 4, 0, 0, 0, 1, 0, 0, 0 },
        { 8, 0, 3, 0, 0, 9, 0, 0, 0 },
        { 4, 0, 0, 0, 7, 0, 0, 0, 5 },
        { 0, 0, 0, 8, 1, 0, 0, 6, 9 },
};

        int[,] medium_board_4 = new int[,]
{
        { 0, 0, 8, 0, 0, 0, 0, 3, 9 },
        { 0, 3, 4, 0, 0, 0, 0, 5, 0 },
        { 0, 0, 2, 4, 9, 3, 0, 0, 0 },
        { 0, 9, 0, 7, 0, 0, 8, 0, 0 },
        { 8, 0, 1, 0, 0, 0, 0, 0, 0 },
        { 6, 0, 0, 0, 8, 0, 0, 9, 4 },
        { 2, 0, 0, 3, 0, 0, 0, 1, 8 },
        { 0, 0, 0, 5, 0, 8, 9, 0, 0 },
        { 4, 8, 0, 0, 6, 0, 2, 0, 0 },
};

        int[,] medium_board_5 = new int[,]
{
        { 0, 5, 2, 0, 8, 0, 0, 4, 0 },
        { 0, 0, 0, 7, 0, 0, 5, 0, 8 },
        { 1, 0, 0, 5, 0, 9, 3, 0, 0 },
        { 0, 4, 0, 2, 0, 5, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 3, 8, 1, 0 },
        { 0, 9, 6, 0, 0, 0, 0, 0, 7 },
        { 9, 0, 5, 0, 3, 7, 0, 0, 0 },
        { 2, 0, 0, 1, 0, 0, 0, 0, 9 },
        { 0, 0, 0, 0, 9, 0, 0, 8, 5 },
};
        #endregion

        #region hard
        int[,] hard_board_1 = new int[,]
{
        { 8, 2, 0, 0, 0, 0, 0, 3, 0 },
        { 0, 9, 0, 0, 5, 8, 0, 7, 0 },
        { 0, 0, 5, 9, 0, 0, 0, 0, 2 },
        { 0, 5, 0, 1, 0, 0, 6, 8, 0 },
        { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 2, 6, 0, 0, 5 },
        { 7, 0, 0, 4, 0, 5, 3, 0, 0 },
        { 0, 1, 0, 0, 0, 0, 4, 0, 0 },
        { 3, 0, 0, 0, 6, 0, 0, 0, 1 },
};

        int[,] hard_board_2 = new int[,]
{
        { 0, 0, 9, 0, 0, 2, 0, 0, 8 },
        { 0, 7, 5, 0, 0, 8, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 4, 7, 0, 0 },
        { 6, 0, 0, 5, 1, 0, 0, 0, 9 },
        { 0, 5, 0, 0, 0, 0, 8, 0, 0 },
        { 3, 0, 0, 2, 0, 0, 0, 7, 0 },
        { 9, 0, 0, 3, 7, 0, 4, 0, 0 },
        { 0, 0, 0, 0, 2, 0, 1, 6, 0 },
        { 0, 4, 7, 0, 0, 0, 0, 0, 5 },
};

        int[,] hard_board_3 = new int[,]
{
        { 0, 0, 0, 0, 0, 0, 0, 8, 1 },
        { 8, 0, 0, 0, 0, 6, 0, 0, 7 },
        { 0, 7, 1, 5, 0, 0, 0, 0, 0 },
        { 0, 9, 6, 7, 0, 0, 8, 0, 0 },
        { 5, 0, 0, 0, 9, 0, 0, 0, 0 },
        { 0, 4, 0, 0, 0, 8, 6, 0, 0 },
        { 6, 0, 3, 0, 0, 0, 2, 0, 0 },
        { 0, 0, 7, 4, 0, 9, 0, 6, 0 },
        { 0, 1, 0, 0, 6, 0, 0, 3, 0 },
};

        int[,] hard_board_4 = new int[,]
{
        { 3, 5, 0, 0, 2, 0, 0, 0, 6 },
        { 6, 0, 0, 1, 0, 0, 3, 0, 0 },
        { 0, 0, 0, 9, 6, 0, 0, 0, 2 },
        { 0, 9, 3, 0, 0, 0, 2, 0, 0 },
        { 0, 4, 0, 5, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 4, 9, 5, 1, 0 },
        { 0, 0, 8, 0, 0, 7, 0, 9, 0 },
        { 0, 0, 0, 0, 0, 1, 0, 0, 8 },
        { 0, 0, 1, 8, 0, 0, 7, 0, 0 },
};

        int[,] hard_board_5 = new int[,]
{
        { 0, 0, 0, 2, 0, 0, 4, 0, 1 },
        { 6, 0, 0, 0, 0, 3, 0, 0, 0 },
        { 2, 0, 0, 0, 1, 0, 8, 0, 0 },
        { 0, 0, 0, 3, 0, 0, 0, 1, 0 },
        { 0, 0, 6, 4, 0, 0, 0, 8, 0 },
        { 0, 5, 0, 0, 6, 0, 9, 0, 0 },
        { 1, 8, 0, 6, 0, 0, 0, 0, 3 },
        { 0, 0, 0, 0, 5, 8, 0, 2, 4 },
        { 0, 0, 7, 0, 0, 4, 0, 0, 8 },
};
        #endregion
        #endregion

        #region default_puzzles_solutions
        #region easy
        int[,] sol_easy_board_1 = new int[,]
{
        { 9, 5, 3, 8, 4, 7, 2, 6, 1 },
        { 4, 7, 1, 6, 2, 5, 9, 3, 8 },
        { 8, 6, 2, 1, 9, 3, 5, 4, 7 },
        { 3, 4, 7, 5, 6, 9, 8, 1, 2 },
        { 2, 1, 9, 4, 3, 8, 7, 5, 6 },
        { 6, 8, 5, 2, 7, 1, 4, 9, 3 },
        { 5, 3, 6, 7, 8, 4, 1, 2, 9 },
        { 1, 9, 8, 3, 5, 2, 6, 7, 4 },
        { 7, 2, 4, 9, 1, 6, 3, 8, 5 },
};

        int[,] sol_easy_board_2 = new int[,]
{
        { 2, 5, 9, 1, 6, 8, 7, 4, 3 },
        { 4, 8, 3, 5, 7, 2, 6, 1, 9 },
        { 7, 1, 6, 9, 3, 4, 2, 8, 5 },
        { 8, 2, 5, 6, 1, 9, 4, 3, 7 },
        { 3, 4, 7, 2, 8, 5, 1, 9, 6 },
        { 6, 9, 1, 7, 4, 3, 8, 5, 2 },
        { 5, 3, 8, 4, 2, 7, 9, 6, 1 },
        { 9, 6, 2, 8, 5, 1, 3, 7, 4 },
        { 1, 7, 4, 3, 9, 6, 5, 2, 8 },
};

        int[,] sol_easy_board_3 = new int[,]
{
        { 1, 7, 4, 6, 9, 3, 5, 8, 2 },
        { 5, 3, 8, 7, 2, 4, 1, 6, 9 },
        { 9, 6, 2, 1, 5, 8, 7, 3, 4 },
        { 8, 5, 3, 9, 4, 2, 6, 7, 1 },
        { 4, 1, 7, 3, 8, 6, 9, 2, 5 },
        { 2, 9, 6, 5, 1, 7, 3, 4, 8 },
        { 3, 4, 9, 8, 6, 1, 2, 5, 7 },
        { 7, 2, 5, 4, 3, 9, 8, 1, 6 },
        { 6, 8, 1, 2, 7, 5, 4, 9, 3 },
};

        int[,] sol_easy_board_4 = new int[,]
{
        { 7, 5, 1, 4, 2, 9, 8, 3, 6 },
        { 4, 3, 8, 1, 7, 6, 5, 9, 2 },
        { 2, 9, 6, 8, 5, 3, 1, 4, 7 },
        { 6, 4, 7, 9, 1, 2, 3, 8, 5 },
        { 9, 2, 5, 3, 8, 4, 7, 6, 1 },
        { 1, 8, 3, 5, 6, 7, 4, 2, 9 },
        { 8, 6, 2, 7, 3, 5, 9, 1, 4 },
        { 5, 1, 9, 2, 4, 8, 6, 7, 3 },
        { 3, 7, 4, 6, 9, 1, 2, 5, 8 },
};

        int[,] sol_easy_board_5 = new int[,]
{
        { 6, 2, 9, 8, 1, 5, 4, 7, 3 },
        { 1, 8, 5, 3, 4, 7, 2, 6, 9 },
        { 7, 4, 3, 6, 9, 2, 8, 1, 5 },
        { 2, 7, 4, 5, 3, 8, 6, 9, 1 },
        { 5, 3, 8, 9, 6, 1, 7, 2, 4 },
        { 9, 6, 1, 2, 7, 4, 3, 5, 8 },
        { 3, 5, 7, 4, 2, 9, 1, 8, 6 },
        { 4, 9, 2, 1, 8, 6, 5, 3, 7 },
        { 8, 1, 6, 7, 5, 3, 9, 4, 2 },
};
        #endregion

        #region medium
        int[,] sol_medium_board_1 = new int[,]
{
        { 6, 7, 3, 8, 4, 2, 5, 1, 9 },
        { 2, 4, 5, 7, 1, 9, 3, 8, 6 },
        { 8, 1, 9, 3, 5, 6, 7, 4, 2 },
        { 7, 3, 4, 6, 2, 8, 1, 9, 5 },
        { 5, 9, 2, 1, 7, 4, 8, 6, 3 },
        { 1, 8, 6, 5, 9, 3, 4, 2, 7 },
        { 3, 2, 8, 4, 6, 7, 9, 5, 1 },
        { 9, 5, 7, 2, 8, 1, 6, 3, 4 },
        { 4, 6, 1, 9, 3, 5, 2, 7, 8 },
};

        int[,] sol_medium_board_2 = new int[,]
{
        { 9, 6, 3, 4, 1, 8, 5, 2, 7 },
        { 2, 7, 5, 9, 6, 3, 1, 8, 4 },
        { 4, 1, 8, 2, 7, 5, 9, 6, 3 },
        { 3, 8, 4, 5, 2, 9, 7, 1, 6 },
        { 6, 2, 9, 7, 4, 1, 3, 5, 8 },
        { 7, 5, 1, 3, 8, 6, 4, 9, 2 },
        { 8, 3, 6, 1, 5, 7, 2, 4, 9 },
        { 1, 4, 7, 6, 9, 2, 8, 3, 5 },
        { 5, 9, 2, 8, 3, 4, 6, 7, 1 },
};

        int[,] sol_medium_board_3 = new int[,]
{
        { 6, 3, 8, 4, 9, 2, 1, 5, 7 },
        { 7, 5, 2, 1, 6, 8, 9, 3, 4 },
        { 1, 9, 4, 7, 3, 5, 6, 8, 2 },
        { 9, 2, 6, 3, 4, 7, 5, 1, 8 },
        { 5, 8, 1, 9, 2, 6, 7, 4, 3 },
        { 3, 4, 7, 5, 8, 1, 2, 9, 6 },
        { 8, 6, 3, 2, 5, 9, 4, 7, 1 },
        { 4, 1, 9, 6, 7, 3, 8, 2, 5 },
        { 2, 7, 5, 8, 1, 4, 3, 6, 9 },
};

        int[,] sol_medium_board_4 = new int[,]
{
        { 1, 6, 8, 2, 5, 7, 4, 3, 9 },
        { 9, 3, 4, 8, 1, 6, 7, 5, 2 },
        { 5, 7, 2, 4, 9, 3, 1, 8, 6 },
        { 3, 9, 5, 7, 4, 2, 8, 6, 1 },
        { 8, 4, 1, 6, 3, 9, 5, 2, 7 },
        { 6, 2, 7, 1, 8, 5, 3, 9, 4 },
        { 2, 5, 9, 3, 7, 4, 6, 1, 8 },
        { 7, 1, 6, 5, 2, 8, 9, 4, 3 },
        { 4, 8, 3, 9, 6, 1, 2, 7, 5 },
};

        int[,] sol_medium_board_5 = new int[,]
{
        { 7, 5, 2, 3, 8, 6, 9, 4, 1 },
        { 6, 3, 9, 7, 4, 1, 5, 2, 8 },
        { 1, 8, 4, 5, 2, 9, 3, 7, 6 },
        { 8, 4, 1, 2, 7, 5, 6, 9, 3 },
        { 5, 2, 7, 9, 6, 3, 8, 1, 4 },
        { 3, 9, 6, 4, 1, 8, 2, 5, 7 },
        { 9, 1, 5, 8, 3, 7, 4, 6, 2 },
        { 2, 6, 8, 1, 5, 4, 7, 3, 9 },
        { 4, 7, 3, 6, 9, 2, 1, 8, 5 },
};
        #endregion

        #region hard
        int[,] sol_hard_board_1 = new int[,]
{
        { 8, 2, 4, 6, 7, 1, 5, 3, 9 },
        { 6, 9, 3, 2, 5, 8, 1, 7, 4 },
        { 1, 7, 5, 9, 3, 4, 8, 6, 2 },
        { 2, 5, 7, 1, 4, 9, 6, 8, 3 },
        { 9, 6, 1, 5, 8, 3, 2, 4, 7 },
        { 4, 3, 8, 7, 2, 6, 9, 1, 5 },
        { 7, 8, 2, 4, 1, 5, 3, 9, 6 },
        { 5, 1, 6, 3, 9, 7, 4, 2, 8 },
        { 3, 4, 9, 8, 6, 2, 7, 5, 1 },
};

        int[,] sol_hard_board_2 = new int[,]
{
        { 4, 3, 9, 7, 1, 2, 6, 5, 8 },
        { 1, 7, 5, 6, 3, 8, 2, 9, 4 },
        { 8, 2, 6, 9, 5, 4, 7, 1, 3 },
        { 6, 1, 8, 5, 4, 7, 3, 2, 9 },
        { 7, 5, 2, 1, 9, 3, 8, 4, 6 },
        { 3, 9, 4, 2, 8, 6, 5, 7, 1 },
        { 9, 6, 1, 3, 7, 5, 4, 8, 2 },
        { 5, 8, 3, 4, 2, 9, 1, 6, 7 },
        { 2, 4, 7, 8, 6, 1, 9, 3, 5 },
};

        int[,] sol_hard_board_3 = new int[,]
{
        { 3, 6, 9, 2, 4, 7, 5, 8, 1 },
        { 8, 2, 5, 9, 1, 6, 3, 4, 7 },
        { 4, 7, 1, 5, 8, 3, 9, 2, 6 },
        { 1, 9, 6, 7, 2, 4, 8, 5, 3 },
        { 5, 3, 8, 6, 9, 1, 4, 7, 2 },
        { 7, 4, 2, 3, 5, 8, 6, 1, 9 },
        { 6, 8, 3, 1, 7, 5, 2, 9, 4 },
        { 2, 5, 7, 4, 3, 9, 1, 6, 8 },
        { 9, 1, 4, 8, 6, 2, 7, 3, 5 },
};

        int[,] sol_hard_board_4 = new int[,]
{
        { 3, 5, 9, 4, 2, 8, 1, 7, 6 },
        { 6, 8, 2, 1, 7, 5, 3, 4, 9 },
        { 7, 1, 4, 9, 6, 3, 8, 5, 2 },
        { 5, 9, 3, 7, 1, 6, 2, 8, 4 },
        { 1, 4, 7, 5, 8, 2, 9, 6, 3 },
        { 8, 2, 6, 3, 4, 9, 5, 1, 7 },
        { 2, 3, 8, 6, 5, 7, 4, 9, 1 },
        { 4, 7, 5, 2, 9, 1, 6, 3, 8 },
        { 9, 6, 1, 8, 3, 4, 7, 2, 5 },
};

        int[,] sol_hard_board_5 = new int[,]
{
        { 8, 3, 5, 2, 9, 6, 4, 7, 1 },
        { 6, 7, 1, 8, 4, 3, 2, 5, 9 },
        { 2, 4, 9, 5, 1, 7, 8, 3, 6 },
        { 4, 9, 2, 3, 8, 5, 6, 1, 7 },
        { 7, 1, 6, 4, 2, 9, 3, 8, 5 },
        { 3, 5, 8, 7, 6, 1, 9, 4, 2 },
        { 1, 8, 4, 6, 7, 2, 5, 9, 3 },
        { 9, 6, 3, 1, 5, 8, 7, 2, 4 },
        { 5, 2, 7, 9, 3, 4, 1, 6, 8 },
};
        #endregion
        #endregion

        #region generate_grid
        private void MainForm_Load(object sender, EventArgs e)
        {
            DGV = new DataGridView();
            DGV.Name = "DGV";
            DGV.EditingControlShowing += DGV_EditingControlShowing; //event that handles the input from player (only integers allowed)
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToAddRows = false;
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = false;
            DGV.GridColor = Color.DarkBlue;
            DGV.DefaultCellStyle.BackColor = Color.White;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(cSidelength, cSidelength);
            DGV.Location = new Point(20, 42);
            DGV.Font = new System.Drawing.Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            DGV.ForeColor = Color.DarkBlue;
            DGV.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // add 81 cells
            for (int i = 0; i < cMaxCell; i++)
            {
                DataGridViewTextBoxColumn TxCol = new DataGridViewTextBoxColumn();
                TxCol.MaxInputLength = 1;   // only one digit allowed in a cell
                DGV.Columns.Add(TxCol);
                DGV.Columns[i].Name = "Col " + (i + 1).ToString();
                DGV.Columns[i].Width = cColWidth;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewRow row = new DataGridViewRow();
                row.Height = cRowHeight;
                DGV.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            DGV.Columns[2].DividerWidth = 2;
            DGV.Columns[5].DividerWidth = 2;
            DGV.Rows[2].DividerHeight = 2;
            DGV.Rows[5].DividerHeight = 2;
            
            Controls.Add(DGV);

            cells_read_only_enabled();
        }
        #endregion

        //Functions

        #region accept_only_numbers
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '0')
            {
                e.Handled = true;
            }
            if (e.KeyChar == 22)
            {
                e.Handled = true;
            }
        }
        private void CheckMouseEvents(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SendKeys.Send("{Esc}");
            }
        }
        private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += CheckKey;
            e.Control.MouseUp += CheckMouseEvents;
        }
        #endregion

        #region verify_unique_numbers
        //Checking rows for an unique value
        public int rowChk(int row, int cell, int val)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Convert.ToInt32(DGV.Rows[row].Cells[i].Value) == val)
                    count++;
            }
            if (count > 0)
                return 0;
            else return 1;
        }

        //Checking columns for an unique value		
        public int colChk(int row, int cell, int val)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Convert.ToInt32(DGV.Rows[i].Cells[cell].Value) == val)
                    count++;
            }
            if (count > 0)
                return 0;
            else return 1;
        }

        //Checking sub-squares for an unique value
        public int subsqChk(int row, int cell, int val)
        {
            int count = 0;

            #region rows_0_1_2
            if (row == 0 || row == 1 || row == 2)
            {
                if (cell == 0 || cell == 1 || cell == 2)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 3 || cell == 4 || cell == 5)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 3; j < 6; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 6 || cell == 7 || cell == 8)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 6; j < 9; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
            }
            #endregion

            #region rows_3_4_5
            else if (row == 3 || row == 4 || row == 5)
            {
                if (cell == 0 || cell == 1 || cell == 2)
                {
                    for (int i = 3; i < 6; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 3 || cell == 4 || cell == 5)
                {
                    for (int i = 3; i < 6; i++)
                        for (int j = 3; j < 6; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 6 || cell == 7 || cell == 8)
                {
                    for (int i = 3; i < 6; i++)
                        for (int j = 6; j < 9; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
            }
            #endregion

            #region rows_6_7_8
            else if (row == 6 || row == 7 || row == 8)
            {
                if (cell == 0 || cell == 1 || cell == 2)
                {
                    for (int i = 6; i < 9; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 3 || cell == 4 || cell == 5)
                {
                    for (int i = 6; i < 9; i++)
                        for (int j = 3; j < 6; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
                else if (cell == 6 || cell == 7 || cell == 8)
                {
                    for (int i = 6; i < 9; i++)
                        for (int j = 6; j < 9; j++)
                        {
                            if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == val)
                            {
                                count++;
                                break;
                            }
                        }
                }
            }
            #endregion

            if (count > 0)
                return 0;
            else return 1;
        }
        #endregion

        #region can_be_solved
       
        #endregion

        #region functions_to_generate_and_load_boards
        #region generate_boards
        private void generate_easy_board()
        {
            cells_read_only_disabled();

            if (was_generated == false)
            {
                while (max_easy >= 0)
                {
                    int row_rnd = rnd.Next(DGV.Rows.Count);
                    int cell_rnd = rnd.Next(DGV.ColumnCount);
                    int val = rnd.Next(1, 10);

                    if (rowChk(row_rnd, cell_rnd, val) == 1 && colChk(row_rnd, cell_rnd, val) == 1 && subsqChk(row_rnd, cell_rnd, val) == 1)
                    {
                        DGV.Rows[row_rnd].Cells[cell_rnd].Value = val;
                        rnd_occupied[row_rnd, cell_rnd] = true;
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.Style.ForeColor = Color.RoyalBlue;
                        cell.ReadOnly = true;
                        max_easy--;
                    }
                    else
                    {
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.ReadOnly = false;
                    }
                }
                lblStatus.Text = "Easy table \ngenerated.";
                hintToolStripMenuItem.Enabled = false;
                btnSolve.Enabled = false;
            }
            was_generated = true;
            timer.Start();
        }
        private void generate_medium_board()
        {
            cells_read_only_disabled();

            if (was_generated == false)
            {
                while (max_medium >= 0)
                {
                    int row_rnd = rnd.Next(DGV.Rows.Count);
                    int cell_rnd = rnd.Next(DGV.ColumnCount);
                    int val = rnd.Next(1, 10);

                    if (rowChk(row_rnd, cell_rnd, val) == 1 && colChk(row_rnd, cell_rnd, val) == 1 && subsqChk(row_rnd, cell_rnd, val) == 1)
                    {
                        DGV.Rows[row_rnd].Cells[cell_rnd].Value = val;
                        rnd_occupied[row_rnd, cell_rnd] = true;
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.Style.ForeColor = Color.RoyalBlue;
                        cell.ReadOnly = true;
                        max_medium--;
                    }
                    else
                    {
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.ReadOnly = false;
                    }
                }
                lblStatus.Text = "Medium table \ngenerated.";
                hintToolStripMenuItem.Enabled = false;
                btnSolve.Enabled = false;
            }
            was_generated = true;
            timer.Start();
        }
        private void generate_hard_board()
        {
            cells_read_only_disabled();

            if (was_generated == false)
            {
                while (max_hard >= 0)
                {
                    int row_rnd = rnd.Next(DGV.Rows.Count);
                    int cell_rnd = rnd.Next(DGV.ColumnCount);
                    int val = rnd.Next(1, 10);

                    if (rowChk(row_rnd, cell_rnd, val) == 1 && colChk(row_rnd, cell_rnd, val) == 1 && subsqChk(row_rnd, cell_rnd, val) == 1)
                    {
                        DGV.Rows[row_rnd].Cells[cell_rnd].Value = val;
                        rnd_occupied[row_rnd, cell_rnd] = true;
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.Style.ForeColor = Color.RoyalBlue;
                        cell.ReadOnly = true;
                        max_hard--;
                    }
                    else
                    {
                        DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                        cell.ReadOnly = false;
                    }
                }
                lblStatus.Text = "Hard table \ngenerated.";
                hintToolStripMenuItem.Enabled = false;
                btnSolve.Enabled = false;
            }
            was_generated = true;
            timer.Start();
        }
        #endregion

        #region load_boards

        #region easy
        private void load_easy_board_1()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy_board_1[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = easy_board_1[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            easy_board_1_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_easy_board_2()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy_board_2[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = easy_board_2[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            easy_board_2_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_easy_board_3()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy_board_3[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = easy_board_3[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            easy_board_3_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_easy_board_4()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy_board_4[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = easy_board_4[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            easy_board_4_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_easy_board_5()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (easy_board_5[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = easy_board_5[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            easy_board_5_generated = true;
            was_generated = true;
            timer.Start();
        }
        #endregion

        #region medium
        private void load_medium_board_1()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (medium_board_1[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = medium_board_1[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            medium_board_1_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_medium_board_2()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (medium_board_2[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = medium_board_2[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            medium_board_2_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_medium_board_3()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (medium_board_3[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = medium_board_3[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            medium_board_3_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_medium_board_4()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (medium_board_4[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = medium_board_4[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            medium_board_4_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_medium_board_5()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (medium_board_5[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = medium_board_5[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            medium_board_5_generated = true;
            was_generated = true;
            timer.Start();
        }
        #endregion

        #region hard
        private void load_hard_board_1()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (hard_board_1[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = hard_board_1[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            hard_board_1_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_hard_board_2()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (hard_board_2[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = hard_board_2[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            hard_board_2_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_hard_board_3()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (hard_board_3[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = hard_board_3[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            hard_board_3_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_hard_board_4()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (hard_board_4[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = hard_board_4[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            hard_board_4_generated = true;
            was_generated = true;
            timer.Start();
        }
        private void load_hard_board_5()
        {
            if (was_generated == false)
            {
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (hard_board_5[i, j] != 0)
                        {
                            DGV.Rows[i].Cells[j].Value = hard_board_5[i, j];
                            DataGridViewCell cell = DGV.Rows[i].Cells[j];
                            cell.Style.ForeColor = Color.RoyalBlue;
                            cell.ReadOnly = true;
                        }
                    }
            }
            hard_board_5_generated = true;
            was_generated = true;
            timer.Start();
        }
        #endregion

        #endregion
        #endregion

        #region functions_to_check_boards
        #region easy
        private void check_easy_board_1()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_easy_board_1[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_easy_board_2()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_easy_board_2[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_easy_board_3()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_easy_board_3[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_easy_board_4()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_easy_board_4[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_easy_board_5()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_easy_board_5[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        #endregion

        #region medium
        private void check_medium_board_1()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_medium_board_1[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_medium_board_2()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_medium_board_2[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_medium_board_3()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_medium_board_3[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_medium_board_4()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_medium_board_4[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_medium_board_5()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_medium_board_5[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        #endregion

        #region hard
        private void check_hard_board_1()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_hard_board_1[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_hard_board_2()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_hard_board_2[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_hard_board_3()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_hard_board_3[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_hard_board_4()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_hard_board_4[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        private void check_hard_board_5()
        {
            int counter = 0;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToInt32(DGV.Rows[i].Cells[j].Value) == sol_hard_board_5[i, j])
                    {
                        counter++;
                    }
                }

            if (counter == 81)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Congratulations!";
                timer.Stop();
            }
            else
            {
                lblStatus.ForeColor = Color.IndianRed;
                lblStatus.Text = "Puzzle is not solved!";
            }
        }
        #endregion
        #endregion

        #region functions_to_solve_boards
        #region easy
        private void solve_easy_board_1()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_1[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_1[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_easy_board_2()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_2[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_2[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_easy_board_3()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_3[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_3[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_easy_board_4()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_4[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_4[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_easy_board_5()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_5[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_easy_board_5[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        #endregion

        #region medium
        private void solve_medium_board_1()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_1[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_1[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_medium_board_2()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_2[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_2[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_medium_board_3()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_3[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_3[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_medium_board_4()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_4[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_4[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_medium_board_5()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_5[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_medium_board_5[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        #endregion

        #region hard
        private void solve_hard_board_1()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_1[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_1[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_hard_board_2()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_2[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_2[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_hard_board_3()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_3[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_3[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_hard_board_4()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_4[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_4[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        private void solve_hard_board_5()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_5[i, j];
                        DataGridViewCell cell = DGV.Rows[i].Cells[j];
                        cell.Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        DGV.Rows[i].Cells[j].Value = sol_hard_board_5[i, j];
                    }

                }
            timer.Stop();
            hintToolStripMenuItem.Enabled = false;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = "Puzzle solved!";
        }
        #endregion
        #endregion

        #region functions_to_give_hints
        #region easy
        private void give_hint_easy_board_1()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_1[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_1[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_easy_board_2()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_2[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_2[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_easy_board_3()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_3[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_3[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_easy_board_4()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_4[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_4[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_easy_board_5()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_5[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_easy_board_5[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        #endregion

        #region medium
        private void give_hint_medium_board_1()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_1[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_1[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_medium_board_2()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_2[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_2[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_medium_board_3()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_3[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_3[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_medium_board_4()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_4[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_4[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_medium_board_5()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_5[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_medium_board_5[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        #endregion

        #region hard
        private void give_hint_hard_board_1()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_1[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_1[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_hard_board_2()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_2[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_2[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_hard_board_3()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_3[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_3[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_hard_board_4()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_4[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_4[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        private void give_hint_hard_board_5()
        {
            int pos_x = rnd.Next(9);
            int pos_y = rnd.Next(9);
            if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
            {
                DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_5[pos_x, pos_y];
                DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                cell.Style.ForeColor = Color.OrangeRed;
                cell.ReadOnly = true;
            }
            else
            {
                while (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) != "")
                {
                    pos_x = rnd.Next(9);
                    pos_y = rnd.Next(9);
                    if (Convert.ToString(DGV.Rows[pos_x].Cells[pos_y].Value) == "")
                    {
                        DGV.Rows[pos_x].Cells[pos_y].Value = sol_hard_board_5[pos_x, pos_y];
                        DataGridViewCell cell = DGV.Rows[pos_x].Cells[pos_y];
                        cell.Style.ForeColor = Color.OrangeRed;
                        cell.ReadOnly = true;
                        break;
                    }
                }
            }
        }
        #endregion
        #endregion

        #region reset board
        private void boardReset()
        {
            timer.Stop();

            cells_read_only_enabled();

            was_generated = false;

            easy_board_1_generated = false;
            easy_board_2_generated = false;
            easy_board_3_generated = false;
            easy_board_4_generated = false;
            easy_board_5_generated = false;

            medium_board_1_generated = false;
            medium_board_2_generated = false;
            medium_board_3_generated = false;
            medium_board_4_generated = false;
            medium_board_5_generated = false;

            hard_board_1_generated = false;
            hard_board_2_generated = false;
            hard_board_3_generated = false;
            hard_board_4_generated = false;
            hard_board_5_generated = false;

            max_easy = 30;
            max_medium = 20;
            max_hard = 10;

            tmr_seconds = 1;

            btnSolve.Enabled = true;

            hintToolStripMenuItem.Enabled = true;
            available_hints = 10;

            lblStatus.ForeColor = Color.DarkBlue;
            lblStatus.Text = "awaiting user...";
            lblSeconds.Text = Convert.ToString(0);
            lblTmrDisplay.Text = "seconds elapsed";

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    DGV.Rows[i].Cells[j].Value = null;
                    DataGridViewCell cell = DGV.Rows[i].Cells[j];
                    cell.Style.ForeColor = Color.DarkBlue;
                }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            boardReset();
        }
        #endregion

        #region cells_read_only
        public void cells_read_only_enabled()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    DataGridViewCell cell = DGV.Rows[i].Cells[j];
                    cell.ReadOnly = true;
                }
        }

        private void cells_read_only_disabled()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    DataGridViewCell cell = DGV.Rows[i].Cells[j];
                    cell.ReadOnly = false;
                }
        }
        #endregion

        #region board_sum
        private int board_sum()
        {
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sum += Convert.ToInt32(DGV.Rows[i].Cells[j].Value);
                }
            }
            return sum;
        }
        #endregion 

        #region board_is_full
        private bool board_is_full()
        {
            int count = 0;
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (Convert.ToString(DGV.Rows[i].Cells[j].Value) == "")
                        count++;
                }
            }
            if (count >= 1)
                return false;
            else return true;
        }
        #endregion

        //Load, check, solve, hints

        #region buttons_generate_boards
        //Generate easy level
        private void btnGenerateEasy_Click(object sender, EventArgs e)
        {
            generate_easy_board();
        }

        //Generate medium level
        private void btnGenerateMedium_Click(object sender, EventArgs e)
        {
            generate_medium_board();
        }

        //Generate hard level
        private void btnGenerateHard_Click(object sender, EventArgs e)
        {
            generate_hard_board();
        }
        #endregion

        #region load_boards
        #region easy
        private void board1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_easy_board_1();
        }

        private void board2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_easy_board_2();
        }

        private void board3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_easy_board_3();
        }

        private void board4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_easy_board_4();
        }

        private void board5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_easy_board_5();   
        }
        #endregion

        #region medium
        private void board1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_medium_board_1();
        }

        private void board2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_medium_board_2();
        }

        private void board3ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_medium_board_3();
        }

        private void board4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_medium_board_4();
        }

        private void board5ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_medium_board_5();
        }
        #endregion

        #region hard
        private void board1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_hard_board_1();
        }

        private void board2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_hard_board_2();
        }

        private void board3ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_hard_board_3();
        }

        private void board4ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_hard_board_4();
        }

        private void board5ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cells_read_only_disabled();
            load_hard_board_5();
        }
        #endregion
        #endregion

        #region check_board
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (was_generated == true)
            {
                #region easy
                if (easy_board_1_generated == true)
                {
                    check_easy_board_1();
                }
                else if (easy_board_2_generated == true)
                {
                    check_easy_board_2();
                }
                else if (easy_board_3_generated == true)
                {
                    check_easy_board_3();
                }
                else if (easy_board_4_generated == true)
                {
                    check_easy_board_4();
                }
                else if (easy_board_5_generated == true)
                {
                    check_easy_board_5();   
                }
                #endregion

                #region medium
                else if (medium_board_1_generated == true)
                {
                    check_medium_board_1();
                }
                else if (medium_board_2_generated == true)
                {
                    check_medium_board_2();
                }
                else if (medium_board_3_generated == true)
                {
                    check_medium_board_3();
                }
                else if (medium_board_4_generated == true)
                {
                    check_medium_board_4();
                }
                else if (medium_board_5_generated == true)
                {
                    check_medium_board_5();
                }
                #endregion

                #region hard
                else if (hard_board_1_generated == true)
                {
                    check_hard_board_1();
                }
                else if (hard_board_2_generated == true)
                {
                    check_hard_board_2();
                }
                else if (hard_board_3_generated == true)
                {
                    check_hard_board_3();
                }
                else if (hard_board_4_generated == true)
                {
                    check_hard_board_4();
                }
                else if (hard_board_5_generated == true)
                {
                    check_hard_board_5();
                }
                #endregion

                else
                {
                    if (board_sum() == 405)
                    {
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Congratulations!";
                        timer.Stop();
                    }
                    else
                    {
                        lblStatus.ForeColor = Color.IndianRed;
                        lblStatus.Text = "Puzzle is not solved!";
                    }
                }
            }
        }
        #endregion

        #region solve_board
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (was_generated == true)
            {
                cells_read_only_enabled();

                #region easy
                if (easy_board_1_generated == true)
                {
                    solve_easy_board_1();
                }
                else if (easy_board_2_generated == true)
                {
                    solve_easy_board_2();
                }
                else if (easy_board_3_generated == true)
                {
                    solve_easy_board_3();
                }
                else if (easy_board_4_generated == true)
                {
                    solve_easy_board_4();
                }
                else if (easy_board_5_generated == true)
                {
                    solve_easy_board_5();
                }
                #endregion

                #region medium
                else if (medium_board_1_generated == true)
                {
                    solve_medium_board_1();
                }
                else if (medium_board_2_generated == true)
                {
                    solve_medium_board_2();
                }
                else if (medium_board_3_generated == true)
                {
                    solve_medium_board_3();
                }
                else if (medium_board_4_generated == true)
                {
                    solve_medium_board_4();
                }
                else if (medium_board_5_generated == true)
                {
                    solve_medium_board_5();
                }
                #endregion

                #region hard
                else if (hard_board_1_generated == true)
                {
                    solve_hard_board_1();
                }
                else if (hard_board_2_generated == true)
                {
                    solve_hard_board_2();
                }
                else if (hard_board_3_generated == true)
                {
                    solve_hard_board_3();
                }
                else if (hard_board_4_generated == true)
                {
                    solve_hard_board_4();
                }
                else if (hard_board_5_generated == true)
                {
                    solve_hard_board_5();
                }
                #endregion
                else
                {

                }
            }
        }
        #endregion       

        #region hints
        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (available_hints > 0 && board_is_full() == false) //De revizuit
            {
                if (was_generated == true)
                {
                    #region easy
                    if (easy_board_1_generated == true)
                    {
                        give_hint_easy_board_1();
                    }
                    else if (easy_board_2_generated == true)
                    {
                        give_hint_easy_board_2();
                    }
                    else if (easy_board_3_generated == true)
                    {
                        give_hint_easy_board_3();
                    }
                    else if (easy_board_4_generated == true)
                    {
                        give_hint_easy_board_4();
                    }
                    else if (easy_board_5_generated == true)
                    {
                        give_hint_easy_board_5();
                    }
                    #endregion

                    #region medium
                    else if (medium_board_1_generated == true)
                    {
                        give_hint_medium_board_1();
                    }
                    else if (medium_board_2_generated == true)
                    {
                        give_hint_medium_board_2();
                    }
                    else if (medium_board_3_generated == true)
                    {
                        give_hint_medium_board_3();
                    }
                    else if (medium_board_4_generated == true)
                    {
                        give_hint_medium_board_4();
                    }
                    else if (medium_board_5_generated == true)
                    {
                        give_hint_medium_board_5();
                    }
                    #endregion

                    #region hard
                    else if (hard_board_1_generated == true)
                    {
                        give_hint_hard_board_1();
                    }
                    else if (hard_board_2_generated == true)
                    {
                        give_hint_hard_board_2();
                    }
                    else if (hard_board_3_generated == true)
                    {
                        give_hint_hard_board_3();
                    }
                    else if (hard_board_4_generated == true)
                    {
                        give_hint_hard_board_4();
                    }
                    else if (hard_board_5_generated == true)
                    {
                        give_hint_hard_board_5();
                    }
                    #endregion
                    else
                    {
                        hintToolStripMenuItem.Enabled = false;
                    }
                }
                available_hints--;
            }
            else
                hintToolStripMenuItem.Enabled = false;
        }
        #endregion

        //Timer event

        #region timer
        private void timer_Tick(object sender, EventArgs e)
        {
            if (tmr_seconds == 1)
            {
                lblSeconds.Text = Convert.ToString(tmr_seconds);
                lblTmrDisplay.Text = "second elapsed";
                tmr_seconds++;
            }
            else
            {
                lblSeconds.Text = Convert.ToString(tmr_seconds);
                lblTmrDisplay.Text = "seconds elapsed";
                tmr_seconds++;
            }
        }
        #endregion

        //Auxiliary forms & environment

        #region colorCodes_and_about
        private void colorCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cc = new ColorCodes();
            cc.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.ShowDialog();
        }
        #endregion

        #region exit_application
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion


        //ToDo:
        //can_be_solved()


    }
}
