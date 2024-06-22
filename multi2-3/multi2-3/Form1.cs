using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi2_3
{
    public partial class Form1 : Form
    {
        private int xOld;
        private int yOld;
        private int ct = 0;
        private bool isDrag;
        private List<Form1> leftFrm = new List<Form1>();
        private List<Form1> rightFrm = new List<Form1>();

        public Form1()
        {
            this.BackColor = Color.Turquoise;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            yOld = e.Y;
            isDrag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dy = e.Y - yOld;
                if (dy < 0)
                {
                    moveYup(dy);
                }
                else
                {
                    moveYdown(dy);
                }
                yOld = e.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                xOld = e.X;
                yOld = e.Y;
            }
            if (e.Button == MouseButtons.Right && ct < 2)
            {
                if (ct == 0)
                {
                    int space = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        Form1 pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(100, 100);
                        pnn.BackColor = Color.Tomato;
                        pnn.Location = new Point(this.Location.X + this.ClientSize.Width, (this.Location.Y) + space);

                        leftFrm.Add(pnn);
                        space += 100;
                    }
                }
                else
                {
                    int space = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        Form1 pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(100, 100);
                        pnn.BackColor = Color.Teal;
                        pnn.Location = new Point((this.Location.X) - 120, (this.Location.Y) + space);

                        rightFrm.Add(pnn);
                        space += 100;
                    }
                }
                ct++;
            }
        }

        private void moveYup(int dy)
        {
            for (int i = 0; i < 4; i++)
            {
                leftFrm[i].Location = new Point((leftFrm[i].Location.X), (leftFrm[i].Location.Y) + dy);
                rightFrm[i].Location = new Point((rightFrm[i].Location.X), (rightFrm[i].Location.Y) + dy);
            }
        }

        private void moveYdown(int dy)
        {
            for (int i = 0; i < 4; i++)
            {
                leftFrm[i].Location = new Point((leftFrm[i].Location.X), (leftFrm[i].Location.Y) + dy);
                rightFrm[i].Location = new Point((rightFrm[i].Location.X), (rightFrm[i].Location.Y) + dy);
            }
        }
    }
}