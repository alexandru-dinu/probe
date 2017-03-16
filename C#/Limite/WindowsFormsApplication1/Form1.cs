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
        public Form1()
        {
            InitializeComponent();
        }

        private double sum = 0;
        double _infty = double.PositiveInfinity;
        private double _i = 1.0;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sum += 1 / (_i);
            textBox1.Text = sum.ToString();
            textBox2.Text = _i.ToString();
            textBox3.Text = Math.Round(sum).ToString();
            _i += 1.0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double _bigValue = Math.Pow(10, 20);
            double cos = Math.Cos(_bigValue);
            double value = Math.Pow(cos, 3)/_bigValue;
            textBox1.Text = value.ToString();
            textBox3.Text = Math.Round(value).ToString();
        }
    }
}
