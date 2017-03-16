using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);

            Calculator calc = new Calculator();
            richTextBox1.Text += Convert.ToString(calc.Sum(x, y));
            richTextBox1.Text += "\r\n";
            richTextBox1.Text += Convert.ToString(calc.Sub(x, y));
            richTextBox1.Text += "\r\n\n";
        }
    }
}
