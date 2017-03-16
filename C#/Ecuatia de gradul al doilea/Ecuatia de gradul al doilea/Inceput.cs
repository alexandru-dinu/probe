using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecuatia_de_gradul_al_doilea
{
    public partial class Inceput : Form
    {
        public Inceput()
        {
            InitializeComponent();
        }

        public bool apasat = false;

        private void btnIesire_Click(object sender, EventArgs e)
        {
            DialogResult dg = dg = MessageBox.Show("Doriți să închideți programul?", "Ieșire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            apasat = true;
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        } //permite închiderea programului prin apăsarea butonului Ieșire

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (apasat == true)
                Application.Exit();
            else
            {
                DialogResult dg = dg = MessageBox.Show("Doriți să închideți programul?", "Ieșire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnInsereaza_Click(object sender, EventArgs e)
        {
            Rezolva rezolva = new Rezolva();
            DialogResult dr = rezolva.ShowDialog();

            if (dr == DialogResult.OK)
            {
                if (rezolva.rezolvat == false)
                {
                    MessageBox.Show("Apăsați pe <<Rezolvă>> înainte de a trimite soluțiile.");
                }
                else if (Convert.ToDouble(rezolva.s1) == 0.0012 && Convert.ToDouble(rezolva.s2) == 0.0012)
                {
                    richTextBox1.Text += "Delta este negativ pentru această ecuație. " + "\r\n";
                    richTextBox1.Text += "----------" + "\r\n";
                }
                else if (Convert.ToDouble(rezolva.s1) == Convert.ToDouble(rezolva.s2))
                {
                    richTextBox1.Text += "Ecuația are soluția dublă x1 = x2 = " + rezolva.s1 + "." + "\r\n";
                    richTextBox1.Text += "----------" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "x1 = " + rezolva.s1 + "." + "\r\n";
                    richTextBox1.Text += "x2 = " + rezolva.s2 + "." + "\r\n";
                    richTextBox1.Text += "----------" + "\r\n";
                }
            }
        }

        private void btnCurata_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
