using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi4_1
{
    public partial class Form1 : Form
    {
        public class cnode
        {
            public int X, Y;
            public int W, H;

            public Color cl;
        }

        private int Ylvl;
        private int flagYlvl = 1;
        private int flagPos = 1;
        private int i = -1;
        private int k = -1;
        private int flagUp = 0;
        private int flagDown = 0;
        private int flagLeft = 0;
        private int flagS = 0;
        private List<cnode> posUp = new List<cnode>();
        private List<cnode> posDown = new List<cnode>();
        private cnode center = new cnode();

        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (flagLeft == 1)
                    {
                        i--;
                        if (i < 0)
                        {
                            i++;
                        }
                        posUp[i].cl = Color.Gray;
                        if (i < posUp.Count - 1)
                        {
                            posUp[i].cl = Color.Gray;
                            posUp[i + 1].cl = Color.Red;
                        }
                    }

                    break;

                case Keys.Right:
                    flagLeft = 1;
                    i++;
                    if (i == posUp.Count)
                    {
                        i--;
                    }
                    posUp[i].cl = Color.Gray;
                    if (i > 0)
                    {
                        posUp[i].cl = Color.Gray;
                        posUp[i - 1].cl = Color.Red;
                    }
                    break;

                case Keys.Up:
                    if (flagS == 1)
                    {
                        k--;
                        if (k < 0)
                        {
                            k++;
                        }
                        posDown[k].cl = Color.Gray;
                        if (k < posDown.Count - 1)
                        {
                            posDown[k].cl = Color.Gray;
                            posDown[k + 1].cl = Color.Green;
                        }
                    }
                    break;

                case Keys.Down:
                    flagS = 1;
                    k++;
                    if (k == posDown.Count)
                    {
                        k--;
                    }
                    posDown[k].cl = Color.Gray;
                    if (k > 0)
                    {
                        posDown[k].cl = Color.Gray;
                        posDown[k - 1].cl = Color.Green;
                    }
                    break;
            }
            DrawScene(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (flagYlvl == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Ylvl = e.Y;
                    this.Text = $"{Ylvl}";
                    center.X = 0;
                    center.Y = e.Y;
                    center.cl = Color.Black;
                    center.W = this.Width;
                    center.H = 1;
                }
                flagYlvl = 0;
            }
            else
            {
                if (flagYlvl == 0)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if ((flagPos == 1 && e.Y < Ylvl) || (flagPos == 2 && e.Y >= Ylvl))
                        {
                            if (flagPos == 1)
                            {
                                cnode pnn = new cnode();
                                pnn.Y = e.Y;
                                pnn.X = e.X;
                                pnn.W = 10; pnn.H = 10;
                                pnn.cl = Color.Red;
                                posUp.Add(pnn);
                                flagPos = 2;
                                flagUp = 1;
                            }
                            else
                            {
                                cnode pnn = new cnode();
                                pnn.Y = e.Y;
                                pnn.X = e.X;
                                pnn.W = 10; pnn.H = 10;
                                pnn.cl = Color.Green;
                                posDown.Add(pnn);
                                flagPos = 1;
                                flagDown = 1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error!!!");
                        }
                    }
                }
            }
            DrawScene(this.CreateGraphics());
        }

        private void DrawScene(Graphics g)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);

            Pen P = new Pen(center.cl, 5);
            SolidBrush brsh = new SolidBrush(center.cl);
            int x = center.X;
            int y = center.Y;
            g.FillRectangle(brsh, x, y, center.W, center.H);
            g.DrawRectangle(P, x, y, center.W, center.H);

            if (flagUp == 1)
            {
                for (int i = 0; i < posUp.Count; i++)
                {
                    P = new Pen(posUp[i].cl, 5);
                    brsh = new SolidBrush(posUp[i].cl);
                    x = posUp[i].X;
                    y = posUp[i].Y;
                    g.FillEllipse(brsh, x - posUp[i].W / 2, y - posUp[i].H / 2, posUp[i].W, posUp[i].H);
                    g.DrawEllipse(P, x - posUp[i].W / 2, y - posUp[i].H / 2, posUp[i].W, posUp[i].H);
                }
            }
            if (flagDown == 1)
            {
                for (int i = 0; i < posDown.Count; i++)
                {
                    P = new Pen(posDown[i].cl, 5);
                    brsh = new SolidBrush(posDown[i].cl);
                    x = posDown[i].X;
                    y = posDown[i].Y;
                    g.FillEllipse(brsh, x - posDown[i].W / 2, y - posDown[i].H / 2, posDown[i].W, posDown[i].H);
                    g.DrawEllipse(P, x - posDown[i].H / 2, y - posDown[i].H / 2, posDown[i].W, posDown[i].H);
                }
            }
        }
    }
}