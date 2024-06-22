using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace multi9_2
{
    public partial class Form1 : Form
    {
        private class Puzzle
        {
        }

        private class Image
        {
            public Rectangle rcSrc;
            public Rectangle rcDst;
            public Bitmap img;
            public int val;
        }

        private Timer tt = new Timer();
        private Bitmap off;
        private int ctTick = 0;
        private List<Image> images = new List<Image>();
        private int red;

        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            tt.Tick += Tt_Tick;
            tt.Interval = 1;
            tt.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:

                    for (int i = 0; i < images.Count; i++)
                    {
                        if (e.X >= images[i].rcDst.X && e.X <= images[i].rcDst.X + images[i].rcDst.Width && e.Y >= images[i].rcDst.Y && e.Y <= images[i].rcDst.Y + images[i].rcDst.Height)
                        {
                            if (images[i].val != 2)
                            {
                                if (red == 0)
                                {
                                    if (i == 1 || i == 3)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 1)
                                {
                                    if (i == 0 || i == 2 || i == 4)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 2)
                                {
                                    if (i == 1 || i == 5)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 3)
                                {
                                    if (i == 0 || i == 6 || i == 4)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 4)
                                {
                                    if (i == red - 1 || i == red - 3 || i == red + 1 || i == red + 3)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 5)
                                {
                                    if (i == 8 || i == 2 || i == 4)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 6)
                                {
                                    if (i == 7 || i == 3)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 7)
                                {
                                    if (i == 6 || i == 8 || i == 4)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                                else if (red == 8)
                                {
                                    if (i == 7 || i == 5)
                                    {
                                        Image temp = images[i];
                                        images[i] = images[red];
                                        images[red] = temp;
                                        red = i;
                                        for (int k = 0; k < images.Count; k++)
                                        {
                                            Bitmap im = new Bitmap("1.bmp");
                                            int row = k / 3;
                                            int col = k % 3;
                                            images[k].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createPuzzle();
        }

        private void createPuzzle()
        {
            int pieceCount = 0;
            Random rnd = new Random();

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Image pnn = new Image();

                    if (pieceCount == 8)
                    {
                        pnn.img = new Bitmap("2.png");
                        int pieceWidth = pnn.img.Width / 3;
                        int pieceHeight = pnn.img.Height / 3;
                        pnn.rcSrc = new Rectangle(c * pieceWidth, r * pieceHeight, pieceWidth, pieceHeight);

                        // The destination rectangle will be set after shuffling
                        pnn.val = 2;
                    }
                    else
                    {
                        pnn.img = new Bitmap("1.bmp");
                        int pieceWidth = pnn.img.Width / 3;
                        int pieceHeight = pnn.img.Height / 3;
                        ;
                        pnn.rcSrc = new Rectangle(c * pieceWidth, r * pieceHeight, pieceWidth, pieceHeight);

                        pnn.val = 1;
                    }

                    images.Add(pnn);
                    pieceCount++;
                }
            }

            for (int i = 0; i < images.Count; i++)
            {
                int j = rnd.Next(i, images.Count);
                Image temp = images[i];
                images[i] = images[j];
                images[j] = temp;
                if (images[i].val == 2)
                {
                    red = i;
                }
            }

            for (int i = 0; i < images.Count; i++)
            {
                Bitmap im = new Bitmap("1.bmp");
                int row = i / 3;
                int col = i % 3;
                images[i].rcDst = new Rectangle(col * im.Width / 3, row * im.Height / 3, im.Width / 3, im.Height / 3);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.PaleGreen);
            g.Clear(Color.Black);
            for (int i = 0; i < images.Count; i++)
            {
                g.DrawImage(images[i].img, images[i].rcDst, images[i].rcSrc, GraphicsUnit.Pixel);
            }
        }

        private void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}