using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi2_1
{
    public partial class Form1 : Form
    {
        private int ct = 0;
        private int X = 0;
        private int Y = 0;
        private int flag = 0;
        private List<Form1> frm = new List<Form1>();

        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //craete forms
                if (ct == 0)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();

                    pnn.BackColor = Color.Teal;
                    pnn.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y - this.Height);

                    frm.Add(pnn);
                    ct++;
                    return;
                }
                if (ct == 1)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();

                    pnn.BackColor = Color.Violet;
                    pnn.Location = new Point(this.Location.X - this.ClientSize.Width, this.Location.Y - this.Height);

                    frm.Add(pnn);
                    ct++;
                    return;
                }
                if (ct == 2)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();

                    pnn.BackColor = Color.Green;
                    pnn.Location = new Point(this.Location.X - this.ClientSize.Width, this.Location.Y + this.Height);
                    frm.Add(pnn);
                    ct++;
                    return;
                }
                if (ct == 3)
                {
                    Form1 pnn = new Form1();
                    pnn.Show();

                    pnn.BackColor = Color.Tomato;
                    pnn.Location = new Point(this.Location.X + this.ClientSize.Width, this.Location.Y + this.Height);

                    frm.Add(pnn);
                    ct++;
                    return;
                }
            }
            if (ct >= 3 && e.Button == MouseButtons.Right)
            {
                for (; ; )
                {
                    if (flag == 0)
                    {
                        moveXleft(0);
                        moveXright(2);
                        moveYup(3);
                        moveYdown(1);
                    }
                    if (flag == 1)
                    {
                        moveXleft(3);
                        moveXright(1);
                        moveYup(2);
                        moveYdown(0);
                    }
                    if (flag == 2)
                    {
                        moveXleft(2);
                        moveXright(0);
                        moveYup(1);
                        moveYdown(3);
                    }
                    if (flag == 3)
                    {
                        moveXleft(1);
                        moveXright(3);
                        moveYup(0);
                        moveYdown(2);
                    }
                    if (frm[0].Location.X == (this.Location.X - this.ClientSize.Width) && frm[0].Location.Y == (this.Location.Y - this.Height) && flag == 0)
                    {
                        flag = 1;
                    }
                    if (frm[0].Location.X == (this.Location.X - this.ClientSize.Width) && frm[0].Location.Y == (this.Location.Y + this.Height) && flag == 1)
                    {
                        flag = 2;
                    }
                    if (frm[0].Location.X == (this.Location.X + this.ClientSize.Width) && frm[0].Location.Y == (this.Location.Y + this.Height) && flag == 2)
                    {
                        flag = 3;
                    }
                    if (frm[0].Location.X == (this.Location.X + this.ClientSize.Width) && frm[0].Location.Y == (this.Location.Y - this.Height) && flag == 3)
                    {
                        flag = 0;
                    }
                }
            }
        }

        private void moveXleft(int i)
        {
            frm[i].Location = new Point((frm[i].Location.X) - 1, (frm[i].Location.Y));
        }

        private void moveXright(int i)
        {
            frm[i].Location = new Point((frm[i].Location.X) + 1, (frm[i].Location.Y));
        }

        private void moveYup(int i)
        {
            frm[i].Location = new Point((frm[i].Location.X), (frm[i].Location.Y) - 1);
        }

        private void moveYdown(int i)
        {
            frm[i].Location = new Point((frm[i].Location.X), (frm[i].Location.Y) + 1);
        }
    }
}