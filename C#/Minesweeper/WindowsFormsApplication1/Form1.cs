using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        readonly Button[] buttonArray = new Button[1024];
        Random rnd = new Random();
        readonly bool[] isMine = new bool[1024];
        private const bool Generated = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int posX = 0;
            int posY = 30;
            int cells = Convert.ToInt32(comboBox1.SelectedItem);
            int lineSplit = 1; //line splitter

            for (int i = 0; i < Math.Pow(cells,2); i++)
                {
                    if (i == 0) //first cell
                    {
                        posX = 30;
                        posY = 30;
                    }
                    else if ((i == lineSplit * cells) && (lineSplit < cells)) //to split into a new line
                    {
                        posX = 30;
                        posY += 30;
                        lineSplit++; 
                    }
                    else
                    {
                        posX += 60;
                    }                     

                    buttonArray[i] = new Button
                    {
                        Location = new Point(posX, posY),
                        Size = new Size(60, 23),
                        Text = Convert.ToString(i)
                    };
                    buttonArray[i].Click += Button_Click;

                    groupBox1.Controls.Add(buttonArray[i]);
                }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cells = Convert.ToInt32(comboBox1.SelectedItem);
            for(int i = 0;i<6;i++)
            {
                isMine[rnd.Next(1,Convert.ToInt32(Math.Pow(cells,2)))] = true;
            }
            label1.ForeColor = Color.OrangeRed;
            label1.Text = "Mines placed";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cells = Convert.ToInt32(comboBox1.SelectedItem);
            for (int i = 0; i < Math.Pow(cells, 2); i++)
            {
                if(isMine[i]==true)
                {
                    buttonArray[i].Text = Convert.ToString(i);
                    buttonArray[i].ForeColor = Color.Red;
                }
                else
                {
                    buttonArray[i].Text = Convert.ToString(i);
                    buttonArray[i].ForeColor = Color.Green;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int pos = Convert.ToInt32(sender.ToString().Remove(0,35));
            if (isMine[pos] == true)
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Mine touched!";
            }
            else
            {
                buttonArray[pos].Enabled = false;
                label2.ForeColor = Color.Green;
                label2.Text = "Escaped!";
            }
            
        }

    }
}
