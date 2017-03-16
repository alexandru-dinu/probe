using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scoala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Scoala_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scoalaDataSet.Elevi' table. You can move, or remove it, as needed.
            this.eleviTableAdapter.Fill(this.scoalaDataSet.Elevi);
            // TODO: This line of code loads data into the 'scoalaDataSet.Clase' table. You can move, or remove it, as needed.
            this.claseTableAdapter.Fill(this.scoalaDataSet.Clase);

        }

        private void adaugaClasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdaugaClasa fAdaugaClasa = new AdaugaClasa();
            fAdaugaClasa.ShowDialog();
            claseTableAdapter.Fill(scoalaDataSet.Clase);
        }

        private void stergeClasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StergeClasa fStergeClasa = new StergeClasa();
            fStergeClasa.ShowDialog();
            claseTableAdapter.Fill(scoalaDataSet.Clase);
        }

        private void modificaClasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificaClasa fModificaClasa = new ModificaClasa();
            fModificaClasa.ShowDialog();
            claseTableAdapter.Fill(scoalaDataSet.Clase);
            eleviTableAdapter.Fill(scoalaDataSet.Elevi);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
