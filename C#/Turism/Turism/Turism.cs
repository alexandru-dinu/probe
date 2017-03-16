using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Turism
{
    public partial class Turism : Form
    {
        public Turism()
        {
            InitializeComponent();
        }

        
        private void menuDatePersonale_Click(object sender, EventArgs e)
        {
            DP fDatePersonale = new DP();
            DialogResult rez = fDatePersonale.ShowDialog();
            
            if (rez == DialogResult.OK)
            {
                txtVacanta.Text += fDatePersonale.strNume+"\r\n";
                txtVacanta.Text += fDatePersonale.strPrenume + "\r\n";
                txtVacanta.Text += fDatePersonale.strCNP + "\r\n";
                txtVacanta.Text += fDatePersonale.strDataNasterii + "\r\n";
                txtVacanta.Text += fDatePersonale.strJudet;
            }
        }

        private void menuVacanta_Click(object sender, EventArgs e)
        {

        }
    }
}
