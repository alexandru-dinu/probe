using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int verif; //Verifica un eventual castig
        public int nr = 0; //Calculeaza numarul de generari
        public bool click = false; //Verifica daca s-a generat o combinatie

        public void button1_Click(object sender, EventArgs e)
        {
            {
                click = true;

                nr = nr + 1;

                //Generarea numerelor

                Random rnd = new Random();
                int a = rnd.Next(1, 50);
                int b = rnd.Next(1, 50);
                int c = rnd.Next(1, 50);
                int d = rnd.Next(1, 50);
                int f = rnd.Next(1, 50);
                int g = rnd.Next(1, 50);

                if (a != b && b != c && c != d && d != f && f != g)
                {

                    textBox1.Text = a + " " + b + " " + c + " " + d + " " + f + " " + g; //Afisarea numerelor
                }
                else
                {
                    a = rnd.Next(1, 50);
                    b = rnd.Next(1, 50);
                    c = rnd.Next(1, 50);
                    d = rnd.Next(1, 50);
                    f = rnd.Next(1, 50);
                    g = rnd.Next(1, 50);
                }

                //Conditia de castig

                if (a == 10 && b == 43 && c == 28 && d == 24 && f == 46 && g == 11)
                {
                    verif = 1;
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (click == true)
            {
                textBox1.Clear();

                if (verif == 1)
                    MessageBox.Show("Ati castigat.");
                else
                    MessageBox.Show("Mult noroc data viitoare.");

                textBox1.Text = "Ati generat de " + Convert.ToString(nr) + " ori.";

                nr = 0;
            }
            else
                MessageBox.Show("Nu ati generat nicio combinatie.");
            
        }    
    }
}
