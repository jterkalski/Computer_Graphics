using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_lab1
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            g.DrawLine(pen1, 0, 0, 100, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //łuk 

            pictureBox1.Refresh();

            Pen greenPen = new Pen(Color.Green, 3);

            Rectangle rect = new Rectangle(0, 0, 100, 100);

            g.DrawArc(greenPen, rect, 100 , 200);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Bezier

            pictureBox1.Refresh();

            Pen redPen = new Pen(Color.Red, 3);
            g.DrawBezier(redPen, 0, 110, 35, 0, 65, 200, 100, 100);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Polygon

            pictureBox1.Refresh();

            Pen greenPen = new Pen(Color.Green, 3);

            Point[] punkty = new Point[4];

            punkty[0].X = 50;
            punkty[0].Y = 50;
            punkty[1].X = 100;
            punkty[1].Y = 25;
            punkty[2].X = 200;
            punkty[2].Y = 5;
            punkty[3].X = 250;
            punkty[3].Y = 150;

            g.DrawPolygon(greenPen, punkty);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Tort

            pictureBox1.Refresh();

            Pen purplePen = new Pen(Color.Purple, 3);

            Rectangle rectN = new Rectangle(0, 0, 160, 180);
            g.DrawPie(purplePen, rectN, 20, 50);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Elipsa

            pictureBox1.Refresh();

            Pen blackPen = new Pen(Color.Black, 3);

            Rectangle rect1 = new Rectangle(0, 0, 200, 100);

            g.DrawEllipse(blackPen, rect1);
        }


        int x = 0;
        int y = 0;
        bool w_prawo = true;
        bool w_dol = true;

        Pen blackPen1 = new Pen(Color.Black, 3);

        private void timer1_Tick(object sender, EventArgs e)
        {
           

           if(w_prawo)
            {
                x++;
                if (x > pictureBox1.Width - 50)
                    w_prawo = false;
            }
            else
            {
                x--;

                if(x<50)
                {
                    w_prawo = true;
                }
            }
           if(w_dol)
            {
                y++;
                if(y>pictureBox1.Height - 50)
                {
                    w_dol = false;
                }
            }
            else
            {
                y--;
                if(y<50)
                {
                    w_dol = true;
                }
            }

            pictureBox1.Refresh();
            g.DrawEllipse(blackPen1, x, y, 50, 50);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled==true)
            {
                button8.Text = "Animacja Start";
                timer1.Enabled = false;
            }
            else
            {
                button8.Text = "Animacja Stop";
                timer1.Enabled = true;
            }
        }
    }
}
