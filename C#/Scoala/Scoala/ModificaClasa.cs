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
    public partial class ModificaClasa : Form
    {
        public ModificaClasa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            claseTableAdapter1.ModificaClasa(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, int.Parse(textBox5.Text), textBox6.Text);
            Close();
        }
    }
}
