using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double soldInitial = 100;

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.Tranzactii' table. You can move, or remove it, as needed.
            this.tranzactiiTableAdapter.Fill(this.dbDataSet.Tranzactii);
      
            DataGridViewRow rand;
            rand = dataGridView1.Rows[dataGridView1.Rows.Count-1];
            if (rand.Cells[3].Value.ToString() == "")
                rand.Cells[5].Value = soldInitial - double.Parse(rand.Cells[4].Value.ToString());
            else
                rand.Cells[5].Value = soldInitial + double.Parse(rand.Cells[3].Value.ToString());

            for (int i = dataGridView1.Rows.Count - 2; i >= 0; i--)
            {
                ;
            }
        }
    }
}
