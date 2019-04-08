using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace grafika4
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 3);
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 1);


        PointF[] tab = new PointF[100];

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        

        private void button1_Click(object sender, EventArgs e)
        { //HERMITE'A

            pictureBox1.Refresh();

            PointF P1 = new PointF(100,100);
            PointF P4 = new PointF(300,100);
            PointF R1 = new PointF(100,100);
            PointF R4 = new PointF(100,100);

            int amount = 100;
            float dt =(float) 1 /(float) amount;

            PointF[] points = new PointF[amount];

            float t = 0;

            for(int i=0; i<amount; i++)
            {
                points[i].X = ((2 * t * t * t) - (3 * t * t) + 1) * P1.X + ((-2 * t * t * t) + (3 * t * t)) * P4.X + ((t * t * t) - (2 * t * t) + t) * R1.X + ((t * t * t) - (t * t)) * R4.X;
                points[i].Y = ((2 * t * t * t) - (3 * t * t) + 1) * P1.Y + ((-2 * t * t * t) + (3 * t * t)) * P4.Y + ((t * t * t) - (2 * t * t) + t) * R1.Y + ((t * t * t) - (t * t)) * R4.Y;
                t += dt;
            }

            g.DrawLines(pen,points);

            g.DrawLine(pen1, P1.X, P1.Y, P1.X + R1.X, P1.Y + R1.Y);
            g.DrawLine(pen1, P4.X, P4.Y, P4.X + R4.X, P4.Y + R4.Y);

        }

        private void button2_Click(object sender, EventArgs e)
        {//bezier
            pictureBox1.Refresh();

            PointF P1 = new PointF(100, 100);
            PointF P2 = new PointF(100, 200);
            PointF P3 = new PointF(250, 10);
            PointF P4 = new PointF(300, 100);

            int amount = 1000;
            float dt = (float)1 / (float)amount;
            PointF[] points = new PointF[amount];
            float t = 0;
            for (int i = 0; i < amount; i++)
            {
                points[i].X = (1 - t) * (1 - t) * (1 - t) * P1.X + 3 * t * (1 - t) * (1 - t) * P2.X + 3 * t * t * (1 - t) * P3.X + t * t * t * P4.X;
                points[i].Y = (1 - t) * (1 - t) * (1 - t) * P1.Y + 3 * t * (1 - t) * (1 - t) * P2.Y + 3 * t * t * (1 - t) * P3.Y + t * t * t * P4.Y;
                t += dt;
            }
            g.DrawLines(pen1, points);

            g.DrawEllipse(pen, P1.X, P1.Y, 5, 5);
            g.DrawEllipse(pen, P2.X, P2.Y, 5, 5);
            g.DrawEllipse(pen, P3.X, P3.Y, 5, 5);
            g.DrawEllipse(pen, P4.X, P4.Y, 5, 5);
        }

        private void button3_Click(object sender, EventArgs e)
        {//sklejana

            pictureBox1.Refresh();

            PointF[] tabDane = new PointF[6];
            pictureBox1.Refresh();
            tabDane[0].X = 100;
            tabDane[0].Y = 100;
            tabDane[1].X = 150;
            tabDane[1].Y = 200;
            tabDane[2].X = 200;
            tabDane[2].Y = 100;
            tabDane[3].X = 250;
            tabDane[3].Y = 50;
            tabDane[4].X = 300;
            tabDane[4].Y = 200;
            tabDane[5].X = 400;
            tabDane[5].Y = 90;

            pen.Color = Color.Red;
            for (int j = 0; j < 6; j++)
            {
                g.DrawEllipse(pen, tabDane[j].X, tabDane[j].Y, 2, 2);
            }
            pen.Color = Color.Black;

            for (int i = 3; i < 6; i++)
            {
                int j = 0;
                for (double t = 0; t < 1; t += 0.01)
                {
                    tab[j].X = (float)((Math.Pow(1 - t, 3)) / 6 * tabDane[i - 3].X + (3 * Math.Pow(t, 3) - 6 * Math.Pow(t, 2) + 4) / 6 * tabDane[i - 2].X + (-3 * Math.Pow(t, 3) + 3 * Math.Pow(t, 2) + 3 * t + 1) / 6 * tabDane[i - 1].X + Math.Pow(t, 3) / 6 * tabDane[i].X);
                    tab[j].Y = (float)((Math.Pow(1 - t, 3)) / 6 * tabDane[i - 3].Y + (3 * Math.Pow(t, 3) - 6 * Math.Pow(t, 2) + 4) / 6 * tabDane[i - 2].Y + (-3 * Math.Pow(t, 3) + 3 * Math.Pow(t, 2) + 3 * t + 1) / 6 * tabDane[i - 1].Y + Math.Pow(t, 3) / 6 * tabDane[i].Y);
                    j++;
                }
                g.DrawLines(pen1, tab);
            }


        }
    }
}





//t sie zmienia 0-1 w zaleznosci od ilosci pkt (100 pkt - zmiana o 1/100)
