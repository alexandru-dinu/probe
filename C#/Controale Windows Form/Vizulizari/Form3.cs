using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vizulizari
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            // Setăm culoarea de fundal și textul butonului
            button1.BackColor = Color.Yellow;
            button1.Text = "Galben";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            // Resetăm culoarea de fundal și textul butonului
            button1.BackColor = Color.Red;
            button1.Text = "Roșu";
        }

        private void linkWordPad_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkWordPad.LinkVisited = true;
            System.Diagnostics.Process.Start("wordpad.exe", @"c:\Salut.doc");
        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
