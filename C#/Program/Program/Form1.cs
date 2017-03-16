using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "Sunt ";

            if ((checkBox1.Checked) && (checkBox2.Checked))
            {
                MessageBox.Show("Imposibil.");
                Application.Exit();
            }

            else

                if (checkBox1.Checked)
                    msg += checkBox1.Text;
            if (checkBox2.Checked)
                msg += checkBox2.Text;


            msg += " (de) persoane care vor pleca in ";

            if (radioButton1.Checked)
                msg += radioButton1.Text;
            if (radioButton2.Checked)
                msg += radioButton2.Text;
            if (radioButton3.Checked)
                msg += radioButton3.Text;
            if (radioButton4.Checked)
                msg += radioButton4.Text;

            msg += " cu ";

            if (checkBox3.Checked)
                msg += checkBox3.Text;
            if (checkBox4.Checked)
                msg += checkBox4.Text;
            if (checkBox5.Checked)
                msg += checkBox5.Text;
            if (checkBox6.Checked)
                msg += checkBox6.Text;

            MessageBox.Show(msg + ".");
        }
    }
}