using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace picture_puzzle
{

    // written by Christ Kennedy
    // November 7, 2009
    // because I was bored

    public partial class formPicturePuzzle : Form
    {
        enum directions { left, right, up, down };
        directions dirRememberLastMove;
        int intVerticalOffset = 35;                             // vertical gap to account for menustrip
        int intSquareSize = 100;                                // tile size
        int intWidth, intHeight;                                // number of horizontal-vertical tiles
        int intScrambleCounter = 0;                             // countdown var during scrambling
        int intScrambleViewCounter = 0;                         // interval counter to display puzzle while scrambling
        bool bolScrambling = false;                 
        
        udtCartesian udrMousePos;                               // set during mousemove event handler to track where the mouse is during mouseclick event
        udtCartesian udrHoleLoc;                                // location of hole tile
        udtCartesian[,] udrImageIndices;                        // 2d array of cartesian, initialized at newPuzzle() and used to draw image

        PictureBox pic = new PictureBox();                      // output picbox
        Bitmap[,] bmp;                                          // 2d array of images drawn according to their position tracked by udrImageIndices
        Label lblFeedback = new Label();                    
        PictureBox picSolution = new PictureBox();
        Audio DXCorrect;
        Audio DXApplause;
        bool bolStopScramble = false;
        
        public struct udtCartesian
        {
            public int x;
            public int y;
        }

        public formPicturePuzzle()
        {
            InitializeComponent();

            pic.BackColor = Color.Black;
            pic.SizeMode = PictureBoxSizeMode.Normal;
            Controls.Add(picSolution);
            picSolution.Visible = false;

            Controls.Add(lblFeedback);
            lblFeedback.BringToFront();
            lblFeedback.Font = new Font("ms sans-serif", 14);
            lblFeedback.AutoSize = true;
            lblFeedback.ForeColor = Color.White;

            SizeChanged += new EventHandler(formPicturePuzzle_SizeChanged);
            string strCurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            //DXCorrect = new Audio(strCurrentDirectory + "\\correct.wav");
            //DXApplause = new Audio(strCurrentDirectory + "\\applause.wav");

            newPuzzle(picture_puzzle.Properties.Resources.nessa18, false);
        }

        void formPicturePuzzle_SizeChanged(object sender, EventArgs e)
        {
            placeLabelFeedback();
            pic.Top = intVerticalOffset;
            pic.Left = 5;
        }

        void placeSolution()
        {
            picSolution.Left = (Width - picSolution.Width) / 2;
            picSolution.Top = (Height - picSolution.Height) / 2;
        }
        void placeLabelFeedback()
        {
            lblFeedback.Left = (Width - lblFeedback.Width) / 2;
            lblFeedback.Top = (Height - lblFeedback.Height) / 2;
        }

        void showFeedback(string strText)
        {
            lblFeedback.Text = strText;
            placeLabelFeedback();
            lblFeedback.Visible = true;
            lblFeedback.Refresh();
            lblFeedback.BringToFront();
        }

        void newPuzzle(Image img, bool bolResetTileSize)
        {
            // destroy old picBox to avoid event-handler from old puzzle (event handlers are created after scramble is complete)
            pic.Visible = false;
            pic.Dispose();
            pic = new PictureBox();

            // resize image if it doesn't fit the screen
            double dblImg_AspectRatio = (double)img.Width / (double)img.Height;
            Bitmap bmpPic = new Bitmap(img);
            showFeedback("generating puzzle");
            udtCartesian udrScreen = getCartesian(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - intVerticalOffset -25);
            if (bmpPic.Width > udrScreen.x)
                bmpPic = new Bitmap(bmpPic, udrScreen.x, (int)(dblImg_AspectRatio * udrScreen.y));
            if (bmpPic.Height > udrScreen.y )
                bmpPic = new Bitmap(bmpPic, (int)(udrScreen.y * dblImg_AspectRatio), udrScreen.y);

            picSolution.Image = new Bitmap(bmpPic);
            picSolution.Width = picSolution.Image.Width;
            picSolution.Height = picSolution.Image.Height;
            placeSolution();
            picSolution.Visible = false;

            // get user to set the size - loop until approved 
            do
            {
                if (bolResetTileSize)
                {
                    classMessageBox msgbox = new classMessageBox("Tiles Size", "What size do you want the tilse?", "small", "medium", "large", "extra large");
                    msgbox.Owner = this;
                    msgbox.ShowDialog();
                    string strReply = msgbox.Reply;
                    switch (strReply)
                    {
                        case "small":
                            intSquareSize = 25;
                            break;

                        case "medium":
                            intSquareSize = 50;
                            break;

                        case "large":
                            intSquareSize = 75;
                            break;

                        case "extra large":
                            intSquareSize = 100;
                            break;
                    }
                }

                // will round image by ignoring superfluous after (n X intSquareSize) vertical and horizontal
                intWidth = (int)Math.Floor((double)bmpPic.Width / (double)intSquareSize);
                intHeight = (int)Math.Floor((double)bmpPic.Height / (double)intSquareSize);

                picSolution.Image = new Bitmap(bmpPic, (int)((intWidth * intSquareSize) * .24), (int)((intHeight * intSquareSize) * .24));
                picSolution.Width = picSolution.Image.Width;
                picSolution.Height = picSolution.Image.Height;

                bmp = new Bitmap[intWidth, intHeight];      // create 2d array of bitmap pointers
                pic.Width = intWidth * (1 + intSquareSize); // plus one to show a gap between each tile
                pic.Height = intHeight * (1 + intSquareSize);
                udrImageIndices = new udtCartesian[intWidth, intHeight]; // resize index array to track all image tiles
                // cycle through every tile and copy the image from the source to the appropriate tile
                for (int intX = 0; intX < intWidth; intX++)
                    for (int intY = 0; intY < intHeight; intY++)
                    {
                        // calculate the area which needs to be copied
                        Rectangle recSaveArea = new Rectangle(intX * intSquareSize, intY * intSquareSize, intSquareSize, intSquareSize);
                        if (!(intX == intWidth - 1 && intY == intHeight - 1)) // leave bottom right blank
                        {
                            bmp[intX, intY] = new Bitmap(intSquareSize, intSquareSize);  // create a new bitmap 
                            // define rectangle of area in source image to be copied
                            Rectangle recSource = new Rectangle(intX * intSquareSize, intY * intSquareSize, intSquareSize, intSquareSize);
                            // define rectangle of area onto which the copied image will be pasted
                            Rectangle recDestination = new Rectangle(0, 0, intSquareSize, intSquareSize);
                            // create a new bitmap of the appropriate size
                            bmp[intX, intY] = new Bitmap(recDestination.Width, recDestination.Height);
                            // copy the cropped source image onto the new bitmap
                            using (Graphics g = Graphics.FromImage(bmp[intX, intY]))
                            { g.DrawImage(bmpPic, recDestination, recSource, GraphicsUnit.Pixel); }

                        }
                        else
                            bmp[intX, intY] = new Bitmap(picture_puzzle.Properties.Resources.blank_tile, intSquareSize, intSquareSize);  // create a new bitmap 
                       
                        udrImageIndices[intX, intY] = getCartesian(intX, intY);
                    }

                udrHoleLoc = getCartesian(intWidth - 1, intHeight - 1); // the bottom/right tile is the 'hole'

                Controls.Add(pic);

                pic.Visible = true;
                drawPuzzle();
                Width = pic.Width + picSolution.Width + 25;
                Height = pic.Top + pic.Height + intVerticalOffset + 25;
                picSolution.Left = pic.Left + pic.Width;
                picSolution.Top = pic.Top;
            } while (bolResetTileSize && MessageBox.Show("is this correct?", "ok?", MessageBoxButtons.YesNo) != DialogResult.Yes);

            lblFeedback.Visible = false;
        }

        void Scramble()
        {
            // set up variable for scrambler : done in timer tmrScramble.tick() event handler 
            intScrambleCounter = (int)(intWidth > intHeight ? Math.Pow(intWidth, 3) : Math.Pow(intHeight, 3)) * 2;
            intScrambleViewCounter = 2;

            System.Windows.Forms.Timer tmrScramble = new Timer();
            tmrScramble.Interval = 10;
            tmrScramble.Tick += new EventHandler(tmrScramble_Tick);
            bolScrambling = true;
            showFeedback("scrambling puzzle");
            tmrScramble.Enabled = true;
        }

        bool puzzleSolved()
        {
            //  if all tiles are in their place the puzzle is solved
            //  test all tiles, quit-false after first wrong tile is found, return true after exhaustive 'wrong-tile' search failed.
            for (int intX = 0; intX < intWidth; intX++)
                for (int intY = 0; intY < intHeight; intY++)
                    if (udrImageIndices[intX, intY].x != intX || udrImageIndices[intX, intY].y != intY)
                        return false;
            return true;
        }

        void tmrScramble_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tmrMe = (System.Windows.Forms.Timer)sender;
            tmrMe.Enabled = false;
            if (bolStopScramble)
                return;

            if (intScrambleCounter <= 0)  // countdown has reached the end, quit scrambling
            {
                pic.Click += new EventHandler(pic_Click);
                pic.MouseMove += new MouseEventHandler(pic_MouseMove);  
                drawPuzzle();
                lblFeedback.Visible = false;
                bolScrambling = false;
                return;
            }

            intScrambleCounter--;
            bool bolViewMove = false;

            if (intScrambleCounter % intScrambleViewCounter == 0) // flash the mixed puzzle at progressively longer periods until finished
            {
                intScrambleViewCounter *= 2;
                bolViewMove = true;
            }

            Random rnd = new Random();
            int intDir =(int) dirRememberLastMove;

            

            while (intDir ==(int) dirRememberLastMove)
                intDir = (int)(rnd.NextDouble() * 1000) % 4;  // random direction we're moving a tile adjacent to hole (if possible)
            dirRememberLastMove = (directions)intDir;

            udrMousePos = udrHoleLoc;  
            // movePiece() functions use the 'udrMousePos' from user-interface
            // setting it to the holeLoc here makes it easy to place it relative to the direction we're randomly moving the hole

            switch (intDir)
            {
                case 0:
                    if (udrHoleLoc.y > 0)
                    {
                        udrMousePos.y--;
                        movePiece(directions.down);
                    }
                    break;

                case 1:
                    if (udrHoleLoc.x < intWidth - 1)
                    {
                        udrMousePos.x++;
                        movePiece(directions.left);
                    }
                    break;

                case 2:
                    if (udrMousePos.x > 0)
                    {
                        udrMousePos.x--;
                        movePiece(directions.right);
                    }
                    break;

                case 3:
                    if (udrHoleLoc.y < intHeight - 1)
                    {
                        udrMousePos.y++;
                        movePiece(directions.up);
                    }
                    break;
            }

            if (bolViewMove)
                drawPuzzle();

            tmrMe.Enabled = true;

        }

        void pic_MouseMove(object sender, MouseEventArgs e)
        {
            udrMousePos = getCartesian((int)Math.Floor((double)e.X / (double)intSquareSize), (int)Math.Floor((double)e.Y / (double)intSquareSize));
        }

        void drawPuzzle()
        {
            Bitmap newPuzzleImage = new Bitmap((intSquareSize + 1) * intWidth, (intSquareSize + 1) * intHeight);
            {
                for (int intX = 0; intX < intWidth; intX++)
                    for (int intY = 0; intY < intHeight; intY++)
                        drawImageSquare(ref newPuzzleImage, getCartesian(intX, intY));
            }
            pic.Image = newPuzzleImage;
            pic.Refresh();
        }

        void drawImageSquare(ref Bitmap bmpInput, udtCartesian udrLoc)
        {
            using (Graphics g = Graphics.FromImage(bmpInput)) // new image on which we are drawing
            {
                //g.DrawImage(<original bitmap>, <pt.x of top-left image rel to top-left of new image>, <pt.y of top-left image rel to top-left of new image>)
                g.DrawImage(bmp[udrImageIndices[udrLoc.x, udrLoc.y].x, udrImageIndices[udrLoc.x, udrLoc.y].y],
                            udrLoc.x * (intSquareSize + 1), 
                            udrLoc.y * (intSquareSize + 1));
                
          
                // bmp[i,j] is a 2d array of bitmaps
                // udrImageIndice[,] is a 2d array of cartesian, each element holds the index (x,y) of the bmp[,] image which is now located
                // at udrImageIndice[i,j] on the output image
                // when puzzle is solved udrImageIndice[i, j].x = i and udrImageIndice[i,j].y = j, for all i,j
            }
        }

        void pic_Click(object sender, EventArgs e)
        {
            // the pic_MouseMove() event handler sets the udrMousePos cartesian variable to the index of the region of the picture that the mouse was on
            // not necesarily the bmp[,] indices, unless that tile is already in the correct location
            udtCartesian udrOldHole = udrHoleLoc;
            if (udrMousePos.x > 0)  // for each direction : test if selected piece can move and stay within the frame
            { 
               if (udrHoleLoc.x == udrMousePos.x-1 && udrHoleLoc.y == udrMousePos.y) // test if the hole is next to it in the correct direction
                    movePiece(directions.left, true);
            }

            if (udrMousePos.x < intWidth - 1)
            {
                if (udrHoleLoc.x == udrMousePos.x +1 && udrHoleLoc.y == udrMousePos.y)
                    movePiece(directions.right, true);
            }

            if (udrMousePos.y > 0)
            { 
                if (udrHoleLoc.x == udrMousePos.x && udrHoleLoc.y ==udrMousePos.y-1)
                    movePiece(directions.up, true);
            }

            if (udrMousePos.y < intHeight - 1)
            {
                if (udrHoleLoc.x == udrMousePos.x && udrHoleLoc.y == udrMousePos.y + 1)
                    movePiece(directions.down, true);
            }

          //drawPuzzle();
        }

        void movePiece(directions dir)
        { movePiece(dir, false); }
        void movePiece(directions dir, bool bolViewMove)
        {
            udtCartesian udrOldHole = udrHoleLoc;  // may need to redisplay these pieces (if bolViewMode)
            switch (dir)
            {
                case directions.down:
                    movePieceDown();
                    break;

                case directions.up:
                    movePieceUp();
                    break;

                case directions.left:
                    movePieceLeft();
                    break;

                case directions.right:
                    movePieceRight();
                    break;
            }

            if (bolViewMove)
            {
                Bitmap bmpNewMap = new Bitmap(pic.Image);
                drawImageSquare(ref bmpNewMap, udrOldHole);
                drawImageSquare(ref bmpNewMap, udrHoleLoc);
                pic.Image = bmpNewMap;
                pic.Refresh();
            }

            if (!bolScrambling)
            {
                // play a sound if the moved piece is now in the right place
                if (udrImageIndices[udrOldHole.x, udrOldHole.y].x == udrOldHole.x && udrImageIndices[udrOldHole.x, udrOldHole.y].y == udrOldHole.y)
                    playSound(DXCorrect);
                if (puzzleSolved())
                {  
                    showFeedback("congratulations!");
                    playSound(DXApplause);
                }
                else
                    lblFeedback.Visible = false;
            }
        }

        void playSound(Audio DXsound)
        {
            DXsound.CurrentPosition = 0;
            DXsound.Volume = 0;
            DXsound.Play();
        }

        void movePieceLeft()
        {  // 
            udrHoleLoc.x++;  // hole moves right                    
            udtCartesian udrTemp = udrImageIndices[udrMousePos.x, udrMousePos.y];
            udrImageIndices[udrMousePos.x, udrMousePos.y] = udrImageIndices[udrMousePos.x - 1, udrMousePos.y];
            udrImageIndices[udrMousePos.x - 1, udrMousePos.y] = udrTemp;
        }

        void movePieceRight()
        {
            udrHoleLoc.x--;  // hole moves left
            udtCartesian udrTemp = udrImageIndices[udrMousePos.x, udrMousePos.y];
            udrImageIndices[udrMousePos.x, udrMousePos.y] = udrImageIndices[udrMousePos.x + 1, udrMousePos.y];
            udrImageIndices[udrMousePos.x + 1, udrMousePos.y] = udrTemp;
        }

        void movePieceUp()
        {
            udrHoleLoc.y++;  // hole moves down                   
            udtCartesian udrTemp = udrImageIndices[udrMousePos.x, udrMousePos.y];
            udrImageIndices[udrMousePos.x, udrMousePos.y] = udrImageIndices[udrMousePos.x, udrMousePos.y - 1];
            udrImageIndices[udrMousePos.x, udrMousePos.y - 1] = udrTemp;
        }

        void movePieceDown()
        {
            udrHoleLoc.y--;  // hole moves up                   
            udtCartesian udrTemp = udrImageIndices[udrMousePos.x, udrMousePos.y];
            udrImageIndices[udrMousePos.x, udrMousePos.y] = udrImageIndices[udrMousePos.x, udrMousePos.y + 1];
            udrImageIndices[udrMousePos.x, udrMousePos.y + 1] = udrTemp;
        }

        udtCartesian getCartesian(int x, int y)
        {
            udtCartesian udrRetVal = new udtCartesian();
            udrRetVal.x = x;
            udrRetVal.y = y;
            return udrRetVal;
        }

        private void mnuLoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "pics | *.bmp;*.jpg;*.gif;*.png";
            ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PictureBox pic = new PictureBox();
                bolStopScramble = true;
                pic.Load(ofd.FileName);
                newPuzzle(pic.Image, true);
            }
        }

        private void mnuShowSolution_Click(object sender, EventArgs e)
        {
            picSolution.Visible = !picSolution.Visible;
            picSolution.BringToFront();
        }

        private void mnuFile_Scramble_Click(object sender, EventArgs e)
        {
            bolStopScramble = false;
            Scramble();
        }

        private void mnuFile_Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

public class classMessageBox : Form
{
    string reply;
    int intButtonLeft;
    public System.Windows.Forms.Button[] btns = new System.Windows.Forms.Button[0];
    public System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();

    public classMessageBox(string strTitle, string strText,params string[] strButtons)
    {
        Text = strTitle;
        Controls.Add(lbl);
        lbl.Text = strText;
        lbl.Top = 5; lbl.Left = 5;
        lbl.AutoSize = true;
        
     
        foreach (string strButton in strButtons)
            addButton(strButton);

        resizeForm();
    }
    
    void addButton(string strThisButton)
    {
        System.Windows.Forms.Button btnNew = new System.Windows.Forms.Button();
        Controls.Add(btnNew);
        btnNew.Visible = true;
        btnNew.AutoSize = true; btnNew.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnNew.Text = strThisButton.Trim();
       
        btnNew.Click += new EventHandler(btn_Click);
        btnNew.FontChanged += new EventHandler(btnNew_FontChanged);
     
        Array.Resize<System.Windows.Forms.Button>(ref btns, btns.Length + 1);
        btns[btns.Length - 1] = btnNew;
    }
    
    void btn_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.Button btnThis = (System.Windows.Forms.Button)sender;
        reply = btnThis.Text;
        Close();
    }

    void btnNew_FontChanged(object sender, EventArgs e) 
    { initResize(); }
    void lbl_FontChanged(object sender, EventArgs e) { initResize(); }

    void initResize()
    {
        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        tmr.Interval = 5;
        tmr.Tick += new EventHandler(tmr_Tick);
        tmr.Enabled = true;
    }

    void tmr_Tick(object sender, EventArgs e)
    {
        System.Windows.Forms.Timer tmrMe = (System.Windows.Forms.Timer)sender;
        tmrMe.Enabled = false;
        resizeForm();
    }

    void resizeForm()
    {
        intButtonLeft = 5;
        foreach (System.Windows.Forms.Button btn in btns)
        {
            btn.Left = intButtonLeft;
            intButtonLeft += btn.Width + 5;
        }

        Width = btns[btns.Length - 1].Left + btns[btns.Length - 1].Width + 25;
        lbl.AutoSize = true;
        // resize label
        int intNumLines = (int)Math.Ceiling((double)lbl.Width / (double)Width) +1;
        lbl.AutoSize = false;
        lbl.FontChanged += new EventHandler(lbl_FontChanged);
        lbl.Height = lbl.Font.Height  * intNumLines;
        lbl.Width = Width - 20;

        int intTallestButtonHeight = 0;
        foreach (System.Windows.Forms.Button thisButton in btns)
        {
            thisButton.Top = lbl.Top + lbl.Height + 5;
            if (intTallestButtonHeight < thisButton.Height)
                intTallestButtonHeight = thisButton.Height;
        }

        Height = btns[0].Top + intTallestButtonHeight  + 35;
    }

    public string Reply { get { return reply; } }
}
