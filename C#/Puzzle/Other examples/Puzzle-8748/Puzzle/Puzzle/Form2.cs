using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _Puzzle
{
    public partial class Form2 : Form
    {
        public Form2(Form frm)
        {
            InitializeComponent();
        }

        public void exibir(String str)
        {
            pcb_image.ImageLocation = str;
        }
    }
}
