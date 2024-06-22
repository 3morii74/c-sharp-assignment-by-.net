using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi3_3
{
    public class CActor//CNode
    {
        public int X, Y;
        public int W, H;

        public Color cl;
    }

    public partial class Form1 : Form
    {
        private List<CActor> LActs = new List<CActor>();
        private int flag = 1;
        private int ct = 0;
        private int i = 0;
        private int x, y, w, h;

        public Form1()
        {
            this.BackColor = Color.DarkGray;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (flag == 1)
                {
                    ct++;

                    CActor pnn = new CActor();
                    pnn.X = e.X;
                    pnn.Y = e.Y;
                    pnn.W = 1;
                    pnn.H = 1;
                    pnn.cl = Color.Blue;
                    LActs.Add(pnn);

                    if (ct == 2)
                    {
                        flag = 2;
                    }
                }
                if (flag == 2)
                {
                    CActor pnn = new CActor();
                    pnn.X = e.X;
                    pnn.Y = e.Y;
                    pnn.W = 1;
                    pnn.H = 1;
                    pnn.cl = Color.Blue;
                    LActs.Add(pnn);
                    if (LActs[i - 1].X < LActs[i].X)
                    {
                        if (LActs[i - 1].Y > LActs[i].Y) //////right up
                        {
                            CActor pnn2 = new CActor();
                            pnn.X = (LActs[i - 1].X);
                            pnn.Y = LActs[i].Y;
                            pnn.W = (LActs[i].X) - (LActs[i - 1].X + 1);
                            pnn.H = (LActs[i - 1].Y) - (LActs[i].Y + 1);
                            pnn.cl = Color.Green;
                            LActs.Add(pnn2);
                            ct = 0;
                            flag = 1;
                            i--;
                        }
                        else if (LActs[i - 1].Y < LActs[i].Y)/////right down
                        {
                            CActor pnn2 = new CActor();
                            pnn.X = (LActs[i - 1].X);
                            pnn.Y = LActs[i - 1].Y;
                            pnn.W = (LActs[i].X) - (LActs[i - 1].X + 1);
                            pnn.H = (LActs[i].Y) - (LActs[i - 1].Y + 1);
                            pnn.cl = Color.Green;
                            LActs.Add(pnn2);
                            ct = 0;
                            flag = 1;
                            i--;
                        }
                    }
                    else if (LActs[i - 1].X > LActs[i].X)
                    {
                        if (LActs[i - 1].Y > LActs[i].Y) //////left up
                        {
                            CActor pnn2 = new CActor();
                            pnn.X = (LActs[i].X);
                            pnn.Y = LActs[i].Y;
                            pnn.W = (LActs[i - 1].X) - (LActs[i].X + 1);
                            pnn.H = (LActs[i - 1].Y) - (LActs[i].Y + 1);
                            pnn.cl = Color.Green;
                            LActs.Add(pnn2);
                            ct = 0;
                            flag = 1;
                            i--;
                        }
                        else if (LActs[i - 1].Y < LActs[i].Y)/////left down
                        {
                            CActor pnn2 = new CActor();
                            pnn.X = (LActs[i].X);
                            pnn.Y = LActs[i - 1].Y;
                            pnn.W = (LActs[i - 1].X) - (LActs[i].X + 1);
                            pnn.H = (LActs[i].Y) - (LActs[i - 1].Y + 1);
                            pnn.cl = Color.Green;
                            LActs.Add(pnn2);
                            ct = 0;
                            flag = 1;
                            i--;
                        }
                    }
                }
                DrawScene();
            }
        }

        private void DrawScene()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.DarkGray);

            for (; i < LActs.Count; i++)
            {
                Pen P = new Pen(LActs[i].cl, 5);
                SolidBrush brsh = new SolidBrush(LActs[i].cl);
                int x = LActs[i].X;
                int y = LActs[i].Y;
                g.FillRectangle(brsh, x, y, LActs[i].W, LActs[i].H);
                g.DrawRectangle(P, x, y, LActs[i].W, LActs[i].H);
            }
        }
    }
}