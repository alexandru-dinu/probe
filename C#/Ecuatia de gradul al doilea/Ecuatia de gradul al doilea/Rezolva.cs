using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecuatia_de_gradul_al_doilea
{
    public partial class Rezolva : Form
    {
        public Rezolva()
        {
            InitializeComponent();
        }

        public bool rezolvat = false;

        double x1 = 0.0012, x2 = 0.0012; //0.0012 = o valoare aleatorie care reprezintă inițializarea de bază

        private void txta_KeyPress(object sender, KeyPressEventArgs e) //obligă introducerea exclusivă a caracterelor numerice
        {
            char ch = e.KeyChar;
            if (Char.IsDigit(ch) == false && ch != 8 && ch != 44 && ch != 45) //clasa Char conține funcția IsDigit care verifică dacă parametrul transmis este un caracter numeric
            {                                         //egalitatea cu 8 = bksp / 44 = - / 45 = ,
                e.Handled = true; //în cazul în care se întâlnește un caracter nenumeric spunem că evenimentul este tratat  
            }
        }

        private void btnRezolva_Click(object sender, EventArgs e) //rezolvă ecuația
        {
            if (txta.Text == "" || txtb.Text == "" || txtc.Text == "")
            {
                MessageBox.Show("Unul sau mai multe câmpuri sunt goale.");
            }
            else
            {
                double a = Convert.ToDouble(txta.Text);
                double b = Convert.ToDouble(txtb.Text);
                double c = Convert.ToDouble(txtc.Text);
                double delta = 0;

                if (a == 0)
                {
                    MessageBox.Show("Coeficientul dominant este nul.");
                    txta.Text = "";
                }
                else
                {
                    delta = b * b - 4 * a * c;

                    if (delta < 0)
                    {
                        MessageBox.Show("Ecuația nu are rădăcini reale, delta are valoarea " + Convert.ToString(delta) + ".");
                    }
                    else if (delta == 0)
                    {
                        x1 = x2 = -b / (2 * a);
                        MessageBox.Show("Ecuația are o rădăcină dubla x1 = x2 = " + Convert.ToString(x1) + ".");
                    }
                    else
                    {
                        x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                        x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                        MessageBox.Show("Ecuația are două rădăcini reale și distincte x1 = " + Convert.ToString(x1) + " și x2 = " + Convert.ToString(x2) + ".");
                    }
                    rezolvat = true;
                }
            }

        }

        private void btnVizualizare_Click(object sender, EventArgs e) //permite vizualizarea formei ecuației
        {
            if (txta.Text == "" || txtb.Text == "" || txtc.Text == "")
            {
                MessageBox.Show("Unul sau mai multe câmpuri sunt goale.");
            }
            else
            {
                double a = Convert.ToDouble(txta.Text);
                double b = Convert.ToDouble(txtb.Text);
                double c = Convert.ToDouble(txtc.Text);

                if (a == 0)
                {
                    MessageBox.Show("Coeficientul dominant este nul.");
                    txta.Text = "";
                }
                else
                {
                    MessageBox.Show("Forma ecuației este : (" + Convert.ToString(a) + "x^2) + (" + Convert.ToString(b) + "x) + (" + Convert.ToString(c) + ") = 0.");
                }
            }
        }

        public String s1
        {
            get
            {
                return Convert.ToString(x1);
            }
        }

        public String s2
        {
            get
            {
                return Convert.ToString(x2);
            }
        }
    }
}
