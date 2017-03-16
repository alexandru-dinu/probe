using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _Puzzle
{
    public partial class Form1 : Form
    {
        bool pick;

        PictureBox[] pic = new PictureBox[10];
        Bitmap bmpImg;
        Form2 FrmImg;

        int[] posX = new int[10];
        int[] posY = new int[10];


        public Form1()
        {

            InitializeComponent();

            
            pic[1] = pictureBox1;
            pic[2] = pictureBox2;
            pic[3] = pictureBox3;
            pic[4] = pictureBox4;
            pic[5] = pictureBox5;
            pic[6] = pictureBox6;
            pic[7] = pictureBox7;
            pic[8] = pictureBox8;
            pic[9] = pictureBox9;
        
 
            for (int cont = 1; cont < 10; cont++)
            {
                pic[cont].MouseDown += new MouseEventHandler(Down);
                pic[cont].MouseUp += new MouseEventHandler(Up);
                pic[cont].MouseMove += new MouseEventHandler(Muta);
                
                posX[cont] = pic[cont].Location.X;
                posY[cont] = pic[cont].Location.Y;
            }
            
        }


        private void Down(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BringToFront();
            pick = true;
        }


        private void Up(object sender, MouseEventArgs e)
        {
            pick = false;
            PictureBox pcb = ((PictureBox)sender);


            //-------------------------LEFT----------------------------------
            if ((pcb.Left + pcb.Width / 2) > posX[1] && (pcb.Left + pcb.Width/2) < posX[2]) 
            { pcb.Left = posX[1];}
            
            else if ((pcb.Left + pcb.Width / 2) > posX[2] && (pcb.Left + pcb.Width / 2) < posX[3])
            { pcb.Left = posX[2]; }
           
            else if ((pcb.Left + pcb.Width / 2) > posX[3] && (pcb.Left + pcb.Width / 2) < posX[3] + pcb.Width)
            { pcb.Left = posX[3]; }


            //----------------------------------TOP-----------------------------------
            if ((pcb.Top + pcb.Height / 2) > posY[1] && (pcb.Top + pcb.Height / 2) < posY[4])
            { pcb.Top = posY[1]; }

            else if ((pcb.Top + pcb.Height / 2) > posY[4] && (pcb.Top + pcb.Height / 2) < posY[7])
            { pcb.Top = posY[4]; }

            else if ((pcb.Top + pcb.Height / 2) > posY[7] && (pcb.Top + pcb.Height / 2) < posY[7] + pcb.Height)
            { pcb.Top = posY[7]; }

            Verifica();

        }


        private void Muta(object sender, MouseEventArgs e)
        {
            PictureBox pcb = ((PictureBox)sender);

            if (pick == true)
            {
               pcb.Left = (MousePosition.X - this.Left) - pcb.Width / 2;
               pcb.Top = (MousePosition.Y - this.Top) - pcb.Height / 2;
               this.Refresh();
            }
        }


        private void MS_N_Img_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                FrmImg = new Form2(this);

                Aranjeaza();

                FrmImg.exibir(open.FileName);
                
                FrmImg.Show(); 
            }
        }


        private void quebrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmpImg = new Bitmap(FrmImg.pcb_image.Image);
            int Wid, Hei;

            Wid = bmpImg.Width / 3;
            Hei = bmpImg.Height / 3;

            for (int cont = 1; cont < 10; cont++ )
            {
                Bitmap bmpCut = new Bitmap(Wid, Hei);
                
                for (int contH = 0; contH < bmpCut.Height; contH++)
                {
                    for (int contW = 0; contW < bmpCut.Width; contW++)
                    {

                        switch (cont)
                        {
                            case 1:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW, contH));
                                break;

                            case 2:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + Wid, contH));
                                break;

                            case 3:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + 2*Wid, contH));
                                break;

                            case 4:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW, contH + Hei));
                                break;

                            case 5:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + Wid, contH + Hei));
                                break;

                            case 6:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + 2*Wid, contH + Hei));
                                break;

                            case 7:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW, contH + 2 * Hei));
                                break;

                            case 8:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + Wid, contH + 2 * Hei));
                                break;

                            case 9:
                                bmpCut.SetPixel(contW, contH, bmpImg.GetPixel(contW + 2 * Wid, contH + 2 * Hei));
                                break;

                        }

                    }
                }

                pic[cont].Image = bmpCut;
            }
        }

        private void MS_O_Aranjeaza_Click(object sender, EventArgs e)
        {
            Aranjeaza();
        }

        private void MS_O_Amesteca_Click(object sender, EventArgs e)
        {
            Amesteca();
        }




        private void Aranjeaza()
        {
            for (int cont = 1; cont < 10; cont++)
            {
                pic[cont].Left = posX[cont];
                pic[cont].Top = posY[cont];
            }
        }

        private void Amesteca()
        {
            int rnd;
            Random random = new Random();

            for (int cont = 1; cont < 10; cont++)
            {
                rnd = random.Next(1, 10);

                pic[rnd].Left = posX[cont];
                pic[rnd].Top = posY[cont];
            }
        }

        private void Verifica()
        {
            byte teste = 0;

            for (byte cont = 1; cont < 10; cont++ )
            {
                if (pic[cont].Left == posX[cont] && pic[cont].Top == posY[cont]) { teste += 1; }
            }

            if (teste == 9) { MessageBox.Show("Felicitări ați asamblat puzzle-ul !!"); }
        }



    }
}
