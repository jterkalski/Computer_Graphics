using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6 //   7/10 pkt
{
    public partial class Form1 : Form
    {

        private System.Drawing.Graphics a;
        private System.Drawing.Graphics b;
        private System.Drawing.Graphics c;
        private System.Drawing.Graphics d;
        private System.Drawing.Graphics e;
        private System.Drawing.Graphics f;

        private Bitmap bitmapa1;
        private Bitmap bitmapa2;
        private Bitmap bitmapa3;
        private Bitmap bitmapa4;
        private Bitmap bitmapa5;
        private Bitmap bitmapa6;

        private Graphics rysunek1;
        private Graphics rysunek2;
        private Graphics rysunek3;
        private Graphics rysunek4;
        private Graphics rysunek5;
        private Graphics rysunek6;



        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);


        public Form1()
        {
            InitializeComponent();
            a = pictureBox1.CreateGraphics(); 
            b = pictureBox2.CreateGraphics();
            c = pictureBox3.CreateGraphics();
            d = pictureBox4.CreateGraphics();
            e = pictureBox5.CreateGraphics();
            f = pictureBox6.CreateGraphics();


            bitmapa1 = new Bitmap(255, 255);
            pictureBox1.Image = bitmapa1;
            rysunek1 = Graphics.FromImage(pictureBox1.Image);

            bitmapa2 = new Bitmap(255, 255);
            pictureBox2.Image = bitmapa2;
            rysunek2 = Graphics.FromImage(pictureBox2.Image);

            bitmapa3 = new Bitmap(255, 255);
            pictureBox3.Image = bitmapa3;
            rysunek3 = Graphics.FromImage(pictureBox3.Image);

            bitmapa4 = new Bitmap(255, 255);
            pictureBox4.Image = bitmapa4;
            rysunek4 = Graphics.FromImage(pictureBox4.Image);

            bitmapa5 = new Bitmap(255, 255);
            pictureBox5.Image = bitmapa5;
            rysunek5 = Graphics.FromImage(pictureBox5.Image);

            bitmapa6 = new Bitmap(255, 255);
            pictureBox6.Image = bitmapa6;
            rysunek6 = Graphics.FromImage(pictureBox6.Image);


        }


        private void button1_Click(object sender, EventArgs e)
        {

            for(int i=0; i<=255; i++)
            {
                for(int j=0; j<=255; j++)
                {
                    pen1.Color = Color.FromArgb(i, j, 255);
                    rysunek1.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox1.Refresh();


            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                {
                    pen1.Color = Color.FromArgb(0, i, j);
                    rysunek2.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox2.Refresh();


            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                {
                    pen1.Color = Color.FromArgb(i,j,0);
                    rysunek3.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox3.Refresh();


            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                {
                    pen1.Color = Color.FromArgb(255, i,j);
                    rysunek4.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox4.Refresh();


            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                {
                    pen1.Color = Color.FromArgb(i,0,j);
                    rysunek5.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox5.Refresh();


            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                {
                    pen1.Color = Color.FromArgb(i,255,j);
                    rysunek6.DrawLine(pen1, i, j, i + 1, j + 1);
                }

            }
            pictureBox6.Refresh();




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }





        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color pixel1 = bitmapa1.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel1.R);
            string g = System.Convert.ToString(pixel1.G);
            string b = System.Convert.ToString(pixel1.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;

        }



        private void pictureBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            Color pixel2 = bitmapa2.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel2.R);
            string g = System.Convert.ToString(pixel2.G);
            string b = System.Convert.ToString(pixel2.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;
        }

        private void pictureBox3_MouseClick_1(object sender, MouseEventArgs e)
        {
            Color pixel3 = bitmapa3.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel3.R);
            string g = System.Convert.ToString(pixel3.G);
            string b = System.Convert.ToString(pixel3.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;
        }

        private void pictureBox4_MouseClick_1(object sender, MouseEventArgs e)
        {
            Color pixel4 = bitmapa4.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel4.R);
            string g = System.Convert.ToString(pixel4.G);
            string b = System.Convert.ToString(pixel4.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;
        }

        private void pictureBox5_MouseClick_1(object sender, MouseEventArgs e)
        {
            Color pixel5 = bitmapa5.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel5.R);
            string g = System.Convert.ToString(pixel5.G);
            string b = System.Convert.ToString(pixel5.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;
        }

        private void pictureBox6_MouseClick_1(object sender, MouseEventArgs e)
        {
            Color pixel6 = bitmapa6.GetPixel(e.X, e.Y);

            string r = System.Convert.ToString(pixel6.R);
            string g = System.Convert.ToString(pixel6.G);
            string b = System.Convert.ToString(pixel6.B);

            textBox1.Text = r;
            textBox2.Text = g;
            textBox3.Text = b;
        }
    }
}
