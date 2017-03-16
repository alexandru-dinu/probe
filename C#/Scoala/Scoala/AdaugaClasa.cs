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
    public partial class AdaugaClasa : Form
    {
        public AdaugaClasa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Nu ati completat toate campurile!");
                return;
            }

            claseTableAdapter1.Insert(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text);
            Close();
        }
    }
}
