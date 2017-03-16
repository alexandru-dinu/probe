using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Redimensionare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Visible = true;
                Point p = button2.Location;
                p.Y= listBox1.Location.Y + listBox1.Size.Height + 5;
                button2.Location = p;
            }
            else
            {
                listBox1.Visible = false;
                Point p = button2.Location;
                p.Y = button1.Location.Y + button1.Size.Height + 5;
                button2.Location = p;
            }
        }
    }
}
