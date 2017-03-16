using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Password
{
    public partial class Form1 : Form
    {

        String[] args;
        public Form1()
        {
            args = Environment.GetCommandLineArgs();
            InitializeComponent();
        }

        public int i = 0;

        public bool completed = false;

        public void _getPass()
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = args[2];
            prc.Start();
            this.Close();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(args[1]))
            {
                _getPass();
            }
            else
            {
                this.Close();
                
                /*
                DialogResult dg = MessageBox.Show("Try again.", "Password required", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dg == DialogResult.Yes)
                {
                    textBox1.Clear();

                    if (textBox1.Text.Equals(args[1]))
                    {
                        _getPass();
                    }

                    i++;
                }
                else
                {
                    this.Close();
                }
                if (i == 3)
                {
                    this.Close();
                }
                */
            }
        }

        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox1.Text.Equals(args[1]))
                {
                    _getPass();
                }
                else
                {
                    this.Close();

                    /*
                    DialogResult dg = MessageBox.Show("Try again.", "Password required", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dg == DialogResult.Yes)
                    {
                        textBox1.Clear();

                        if (textBox1.Text.Equals(args[1]))
                        {
                            _getPass();
                        }

                        i++;
                    }
                    else
                    {
                        this.Close();
                    }
                    if (i == 3)
                    {
                        this.Close();
                    }
                    */
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }
    }
}
