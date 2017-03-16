using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controale
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
            button1.BackColor = Color.Blue;
            button1.Text = "Albastru";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            // Resetăm culoarea de fundal și textul butonului
            button1.BackColor = Color.Green;
            button1.Text = "Verde";
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
