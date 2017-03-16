using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //declarațiile

        Button btn; //unul dintre cele 9 butoane din matrice
        bool[,] X,O,cells,current; //îi spune programului prin true sau false dacă poziția din matrice este ocupată sau nu și de cine
        string player; //determină textul care va apărea pe buton în funcție de jucătorul curent
        int turn = 0; //determină al cui îi este rândul : 0 = X / 1 = 0
        bool finished = false; //îi spune programului dacă jocul a fost terminat sau nu
        int counter=0; //va conține numărul de apăsări

        //funcțiile specifice

        private void start() //funcție auxiliară care determină, dacă este nevoie, cine va începe
        {
            DialogResult result;
            result = MessageBox.Show("Doriți să jucați cu X?", "Start", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                turn = 0;
            else
                turn = 1;
        }

        private void resetVariables() //funcția ce va reseta variabilele de fiecare dată când se apasă butonul reset sau când programul se va încărca
        {
            finished = false;
            X = new bool[3, 3];
            O = new bool[3, 3];
            cells = new bool[3, 3];
            counter = 0;
        }

        private bool wasClickedBefore(Button button, out int x, out int y) //returnează true sau false pentru a verifica dacă o zonă din matrice este ocupată
        {
            x = y = 0;
            switch(button.Name)
            {
                case "button1": x = 0; y = 0; break;
                case "button2": x = 0; y = 1; break;
                case "button3": x = 0; y = 2; break;
                case "button4": x = 1; y = 0; break;
                case "button5": x = 1; y = 1; break;
                case "button6": x = 1; y = 2; break;
                case "button7": x = 2; y = 0; break;
                case "button8": x = 2; y = 1; break;
                case "button9": x = 2; y = 2; break;
            }
            return (X[x,y]||O[x,y]);
        }

        //verificarea unui eventual câștig

        private bool checkwinROW(int c)
        {
            return (current[c, 0] && current[c, 1] && current[c, 2]);
        }

        private bool checkwinCOLUMN(int c)
        {
            return (current[0, c] && current[1, c] && current[2, c]);
        }

        private bool checkwinDIAGONALS()
        {
            return ((current[0, 0] && current[1, 1] && current[2, 2]) || (current[0, 2] && current[1, 1] && current[2, 0]));
        }

        //verificarea în timpul rulării

        private void rulare_Click(object sender, EventArgs e)
        {
            int x, y;
            if (wasClickedBefore(sender as Button, out x, out y) == false && finished == false) //dacă butonul nu a mai fost apăsat și jocul nu s-a terminat
            {
                counter++;
                btn = sender as Button;
                if (turn == 0)
                {
                    (sender as Button).ForeColor = Color.RoyalBlue;
                    player = "X";
                    X[x, y] = true;
                    current = X;
                }
                else
                {
                    (sender as Button).ForeColor = Color.Green;
                    player = "0";
                    O[x, y] = true;
                    current = O;
                }
                (sender as Button).Text = player;

                cells[x, y] = true; //poziția este acum ocupată

                turn = (turn + 1) % 2; //asigură continuarea jocului prin schimbarea rândului jucătorilor

                //verificăm un câștig

                if (counter >= 5) //un câștig poate exista începând cu cel puțin 5 apăsări
                {
                    if (checkwinROW(0) || checkwinROW(1) || checkwinROW(2) || checkwinCOLUMN(0) || checkwinCOLUMN(1) || checkwinCOLUMN(2) || checkwinDIAGONALS())
                    {
                        if (player == "X")
                        {
                            MessageBox.Show("X câștigă.");
                            lblX.Text = Convert.ToString((Convert.ToInt32(lblX.Text) + 1));
                        }
                        else
                        {
                            MessageBox.Show("0 câștigă.");
                            lbl0.Text = Convert.ToString((Convert.ToInt32(lbl0.Text) + 1));
                        }

                        finished = true;
                        lblTotal.Text = Convert.ToString((Convert.ToInt32(lblTotal.Text) + 1));
                    }
                }

                if (counter == 9 && finished == false)
                {
                    MessageBox.Show("Egalitatate.");
                    finished = true;
                    lblEgalitate.Text = Convert.ToString((Convert.ToInt32(lblEgalitate.Text) + 1));
                    lblTotal.Text = Convert.ToString((Convert.ToInt32(lblTotal.Text) + 1));
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resetVariables();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = "";
            resetVariables();

        }

        private void btnInitializeaza_Click(object sender, EventArgs e)
        {
            lblX.Text = lbl0.Text = lblEgalitate.Text = Convert.ToString("0");
        }

        
    }
}
