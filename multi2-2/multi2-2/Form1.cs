using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi2_2
{
    public partial class Form1 : Form
    {
        private bool isDrag;
        private int xOld = -1;
        private int yOld = -1;
        private int G = 0;
        private int R = 0;
        private int flag = 0;

        public Form1()
        {
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            xOld = e.X;
            yOld = e.Y;
            isDrag = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;
                if (dx >= 250)
                {
                    dx = 249;
                }
                if (dx < 0)
                {
                    dx = 0;
                }

                // Clamp G value within 0-255 range
                if (dy >= 250)
                {
                    dy = 249;
                }
                if (dy < 0)
                {
                    dy = 0;
                }

                //  if (dx > dy)
                //  {
                //      flag = 1;
                //  }
                //  else
                //  {
                //      if (dy > dx)
                //      {
                //          flag = 2;
                //      }
                //  }
                //if (flag == 1)
                //{
                this.BackColor = Color.FromArgb(dx, dy, 0);
                //  }
                //  if (flag == 2)
                //  {
                this.BackColor = Color.FromArgb(dx, dy, 0);
                //  }

                // Clamp R value within 0-255 range
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
        }
    }
}