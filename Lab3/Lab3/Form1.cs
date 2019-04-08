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

namespace grafika3
{
    public partial class Form1 : Form
    { 
        double promien;
        float alfa=0;
        float dalfa;
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 2);
        PointF[] punkty = new PointF[1000];

        Matrix newMatrix = new Matrix();

        void rysuj()
        {
            promien = 0;
            dalfa = (float)(Math.PI * 2) / 100;
            float h = (float)0.5 * pictureBox1.Height;
            float w = (float)0.5 * pictureBox1.Width;

            for (int i=0; i<1000; i++)
            {
                alfa += dalfa;
                punkty[i].X = (float)(promien * Math.Cos(alfa)) + w;
                punkty[i].Y = (float)(promien * Math.Sin(alfa)) + h;

                promien += 0.1;

            }
            for(int i=1; i<1000; i++)
            {
                g.DrawLine(pen, punkty[i - 1], punkty[i]);
            }


        }
        

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {//Translacja

            pictureBox1.Refresh();
            Matrix myMatrix = new Matrix();
            myMatrix.Translate(25, 50);
            myMatrix.TransformPoints(punkty);

            for (int i = 1; i < 1000; i++)
            {
                g.DrawLine(pen, punkty[i - 1], punkty[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Rotacja

            pictureBox1.Refresh();
            Matrix myMatrix = new Matrix();
            float h = (float)0.5 * pictureBox1.Height;
            float w = (float)0.5 * pictureBox1.Width;
            myMatrix.Translate(w, h);

            myMatrix.Rotate(15);

            myMatrix.Translate(-w, -h);

            myMatrix.TransformPoints(punkty);

            for (int i = 1; i < 1000; i++)
            {
                g.DrawLine(pen, punkty[i - 1], punkty[i]);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {//Skalowanie

            pictureBox1.Refresh();
            float h = (float)0.5 * pictureBox1.Height;
            float w = (float)0.5 * pictureBox1.Width;
            Matrix myMatrix = new Matrix();
            myMatrix.Scale(0.5f, 0.5f);
            myMatrix.Translate(w, h);
            myMatrix.TransformPoints(punkty);

            for (int i = 1; i < 1000; i++)
            {
                g.DrawLine(pen, punkty[i - 1], punkty[i]);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {//rysuj spirale
            rysuj();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Refresh();
            Matrix myMatrix = new Matrix();
            float h = (float)0.5 * pictureBox1.Height;
            float w = (float)0.5 * pictureBox1.Width;
            myMatrix.Translate(w, h);

            myMatrix.Rotate(15);

            myMatrix.Translate(-w, -h);

            myMatrix.TransformPoints(punkty);

            for (int i = 1; i < 1000; i++)
            {
                g.DrawLine(pen, punkty[i - 1], punkty[i]);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //START/STOP

            if (timer1.Enabled == true)
            {
                this.Text = "Animacja Start";
                timer1.Enabled = false;
            }
            else
            {
                this.Text = "Animacja Stop";
                timer1.Enabled = true;
            }

        }
    }
}
