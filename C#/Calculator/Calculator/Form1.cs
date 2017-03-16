using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // declararea și setarea valorilor implicite pentru variabilele globale
        private double rezultat = 0;
        private double operand = 0;
        private double memorie = 0;
        private string operatorul = "";
        private bool primaCifra=true; // are valoarea adevărat de fiecare dată când formez un număr nou
        private bool primulOperator = true;

        private void btnCifra_Click(object sender, EventArgs e)
        {
            Button c = (Button)sender;
            if (primaCifra == true && (c.Text == "0" || c.Text == "000"))
                txtAfisare.Text = "0";
            else if (primaCifra)
            {
                txtAfisare.Text = c.Text;
                primaCifra = false; // după introducerea primei cifre a numărului variabila preia valoarea fals
            }
            else
                txtAfisare.Text += c.Text;

            operand = Convert.ToDouble(txtAfisare.Text);

            if (operatorul!="")
                primulOperator = false;
        }

        private void btnZecimal_Click(object sender, EventArgs e)
        {
            txtAfisare.Text += ",";
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (!primulOperator)
                btnRezultat_Click(sender, e);
            Button c = (Button)sender;
            operatorul = c.Text;
            primaCifra = true;
            rezultat = Convert.ToDouble(txtAfisare.Text);
        }
  
        private void btnRezultat_Click(object sender, EventArgs e)
        {
            switch (operatorul)
            {
                case "+":
                    rezultat += operand;
                    break;
                case "-":
                    rezultat -= operand;
                    break;
                case "*":
                    rezultat *= operand;
                    break;
                case "/":
                    rezultat /= operand;
                    break;
                default:
                    rezultat = operand;
                    break;
            }
            txtAfisare.Text = rezultat.ToString();
            primulOperator = true;
            primaCifra = true;
        }

        private void btnCurata_Click(object sender, EventArgs e)
        {
            // resetarea valorilor implicite pentru variabilele globale
            txtAfisare.Text="0";
            rezultat = 0;
            operand = 0;
            operatorul = "";
            primaCifra = true;
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            memorie = Convert.ToDouble(txtAfisare.Text);
            btnMemorie.Enabled = true;
            btnCurata_Click(sender, e);
        }

        private void btnMemorie_Click(object sender, EventArgs e)
        {
            txtAfisare.Text = memorie.ToString();
        }

        private void btnMemSterge_Click(object sender, EventArgs e)
        {
            memorie = 0;
            btnMemorie.Enabled = false;
        }

    }
}
