using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            long lB = Convert.ToInt32(numUpDownLB.Value);
            long uB = Convert.ToInt32(numUpDownUB.Value);

            progressBar1.Minimum = 1;
            progressBar1.Maximum = Convert.ToInt32(uB);

            if (lB < uB)
            {

                for (long i = lB; i <= uB; i++)
                {
                    if (primes(i) == true)
                    {
                        count++;
                        rtBoxPrimes.Text += Convert.ToString(i);
                        rtBoxPrimes.Text += "\r\n";
                        progressBar1.Increment(1);
                    }
                }
                txtBoxTotal.Text = Convert.ToString(count);
                btnGenerate.Enabled = false;
            }

            else
            {
                long aux = lB;
                lB = uB;
                uB = aux;

                numUpDownLB.Value = lB;
                numUpDownUB.Value = uB;

                for (long i = lB; i <= uB; i++)
                {
                    if (primes(i) == true)
                    {
                        count++;
                        rtBoxPrimes.Text += Convert.ToString(i);
                        rtBoxPrimes.Text += "\r\n";
                        progressBar1.Increment(Convert.ToInt32(1));
                    }
                }
                txtBoxTotal.Text = Convert.ToString(count);
                btnGenerate.Enabled = false;
            }
        }

        bool primes(long x) //Primality test algorithm
        {
            if (x == 0 || x == 1)
                return false;          
            else if (x % 2 == 0 && x != 2)
                return false;
            else
            {
                for (long i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                        return false;
                }
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = true;
            count = 0;
            numUpDownLB.Value = 1;
            numUpDownUB.Value = 1;
            txtBoxTotal.Text = string.Empty;
            rtBoxPrimes.Text = string.Empty;
            progressBar1.Value = 1;
        }

        private void numUpDownLB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void numUpDownUB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(rtBoxPrimes.Text == string.Empty)
            {
                MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files|*.txt";
                sfd.DefaultExt = "txt";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter SW = new StreamWriter(sfd.FileName, false, Encoding.ASCII);
                    SW.Write("The prime(s) between " + Convert.ToString(numUpDownLB.Value) + " and " + Convert.ToString(numUpDownUB.Value) + " is/are: " + "\r\n");
                    SW.Write(rtBoxPrimes.Text + "\r\n");
                    SW.Write("Total number of primes: " + Convert.ToString(count));
                    SW.Close();
                }
            }
        }

        private void txtBoxSpecNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int nr_of_primes = Convert.ToInt32(txtBoxSpecNumber.Text);
            int i = 2;
            while(nr_of_primes > 0)
            {
                if (primes(i))
                {
                    rtBoxSpecGen.Text += Convert.ToString(i);
                    rtBoxSpecGen.Text += "\r\n";
                    i++;
                    nr_of_primes--;
                }
                else
                    i++;
            }
            btnSpecGen.Enabled = false;
        }

        private void btnReset2_Click(object sender, EventArgs e)
        {
            btnSpecGen.Enabled = true;
            txtBoxSpecNumber.Text = string.Empty;
            rtBoxSpecGen.Text = string.Empty;
        }
    }
}
