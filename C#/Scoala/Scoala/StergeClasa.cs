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
    public partial class StergeClasa : Form
    {
        public StergeClasa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            claseTableAdapter1.StergeClasa(textBox1.Text);
            Close();
        }
    }
}
