using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        const int cColWidth = 45;
        const int cRowHeigth = 45;
        const int cMaxCell = 9;
        const int cSidelength = cColWidth * cMaxCell + 3;

        DataGridView DGV;

        Random rnd = new Random();
        int max = 30;

        int ok;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DGV = new DataGridView();
            DGV.Name = "DGV";
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToAddRows = false;
            DGV.RowHeadersVisible = false;
            DGV.ColumnHeadersVisible = false;
            DGV.GridColor = Color.DarkBlue;
            DGV.DefaultCellStyle.BackColor = Color.AliceBlue;
            DGV.ScrollBars = ScrollBars.None;
            DGV.Size = new Size(cSidelength, cSidelength);
            DGV.Location = new Point(50, 50);
            DGV.Font = new System.Drawing.Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
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
                row.Height = cRowHeigth;
                DGV.Rows.Add(row);
            }
            // mark the 9 square areas consisting of 9 cells
            DGV.Columns[2].DividerWidth = 2;
            DGV.Columns[5].DividerWidth = 2;
            DGV.Rows[2].DividerHeight = 2;
            DGV.Rows[5].DividerHeight = 2;

            Controls.Add(DGV);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int i = 0, j = 0;
            button1.Enabled = true;
            while (max >= 0)
            {
                int row_rnd = rnd.Next(DGV.Rows.Count);
                int cell_rnd = rnd.Next(DGV.ColumnCount);
                DGV.Rows[row_rnd].Cells[cell_rnd].Value = rnd.Next(1, 10);
                DataGridViewCell cell = DGV.Rows[row_rnd].Cells[cell_rnd];
                cell.Style.ForeColor = Color.Red;
                max--;
            }

            if (ok == 1)
            {
                max = 30;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = 0;
            for (int rows = 0; rows < DGV.Rows.Count; rows++)
            {

                for (int col = 0; col < DGV.Rows[rows].Cells.Count; col++)
                {
                    DGV.Rows[rows].Cells[col].Value = "";

                }
            }
            ok = 1;
        }

        private void verificare()
        {
            for (int i = 0; i < DGV.Rows.Count; i++)
            {

                if (Convert.ToInt32(DGV.Rows[i].Cells[i].Value) == Convert.ToInt32(DGV.Rows[i + 1].Cells[i + 1].Value))
                {
                    MessageBox.Show("Am gasit elemente egale");
                    break;
                }
                else
                {
                    MessageBox.Show("OK");
                    break;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verificare();
        }
    }
}
