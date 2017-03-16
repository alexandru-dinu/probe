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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRunTime_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(f2);
            
            Control c = (Control)sender;
            DateTimePicker dtp = new DateTimePicker(); // Creaza runtime un obiect de tip DateTimePicker
            dtp.Location = new Point(20, 20); // Stabileste o locatie pentru controlul nou creat
            f2.Controls.Add(dtp); //Adauga control la Form2
            Label lb = new Label(); // Creaza runtime un obiect de tip Label
            lb.Location = new Point(20, 100); // Stabileste o locatie pentru controlul nou creat
            lb.Size = new Size(300, 100);
            lb.Text = "Ati apasat controlul " + c.Name + " cu eticheta " + c.Text + ".\nIn panel2 s-au creat programatic un control de tip DateTimePicker si unul de tip Label.";
            f2.Controls.Add(lb); //Adauga control la Form2

            f2.Show();
            f2.Dock = DockStyle.Fill;
        }

        private void btnButoane_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(f3);
            f3.Show();
            f3.Dock = DockStyle.Fill;
        }

        private void btnOptiuni_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(f4);
            f4.Show();
            f4.Dock = DockStyle.Fill;
        }
    }
}
