using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBoxParola.PasswordChar = '*'; // Seteaza un caracter special pentru campul parolei
            TextBoxParola.Enabled = false;  // Seteaza activarea campului de parola
            btnAutentificare.Visible = false; //Initial, acest buton este invizibil 
        }
        private void btnIesire_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Multumim pentru interesul acordat.");
            Application.Exit();
        }
        private void TextBoxUtilizator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                if (TextBoxUtilizator.Text == "Alexandru Dinu")
                    TextBoxParola.Enabled = true;
                else
                {
                    MessageBox.Show("Utilizatorul nu exista.");
                    TextBoxUtilizator.Clear();
                }
        }

        private void TextBoxParola_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (TextBoxParola.Text == "Parola")

                    btnAutentificare.Visible = true;
                
                else
                {
                    MessageBox.Show("Verificati parola.");
                    TextBoxParola.Clear();
                }

        }

        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autentificare cu sucess." + Environment.NewLine + "Aplicatia Transport se va incarca." + Environment.NewLine + "Multumim pentru interesul acordat.");
            form2 form2 = new form2();
            form2.ShowDialog();
            this.Close();
        }
        
            
        
    }
}
