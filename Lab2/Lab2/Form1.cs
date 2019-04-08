using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace grafika2
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen0 = new System.Drawing.Pen(Color.Red, 2);


        double n;
        double r;



        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Okrąg 1.2a
            // 30
            // 150

            

            Double.TryParse(textBox1.Text, out n);
            Double.TryParse(textBox2.Text, out r);

            double alfa1 = 0;
            double alfa2 = 2 * Math.PI / n;

            for (int i = 0; i <= n; i++)
            {
                double x1 = r * Math.Cos(alfa1);
                double y1 = r * Math.Sin(alfa1);
                double x2 = r * Math.Cos(alfa1 + alfa2);
                double y2 = r * Math.Sin(alfa1 + alfa2);

                float h = (float)0.5 * pictureBox1.Height;
                float w = (float)0.5 * pictureBox1.Width;
                alfa1 += alfa2;

                g.DrawLine(pen0, (float)x1 + w, (float)y1 + h, (float)x2 + w, (float)y2 + h);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 100
            // 200

           

            Double.TryParse(textBox1.Text, out n);
            Double.TryParse(textBox2.Text, out r);

            double alfa1 = 0;
            double alfa2 = 360 / n;

            for (int i = 0; i <= n; i++)
            {
                double x1 = r * Math.Cos(alfa1);
                double y1 = r * Math.Sin(alfa1);
                double x2 = r * Math.Cos(alfa1 + alfa2);
                double y2 = r * Math.Sin(alfa1 + alfa2);

                float h = (float)0.5 * pictureBox1.Height;
                float w = (float)0.5 * pictureBox1.Width;
                alfa1 += alfa2;

                g.DrawLine(pen0, (float)x1 + w, (float)y1 + h, (float)x2 + w, (float)y2 + h);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1.3

           

            //Double.TryParse(textBox1.Text, out n);
            //Double.TryParse(textBox2.Text, out r);
            //Double.TryParse(textBox3.Text, out c);

            //double alfa1 = 0;
            //double alfa2 = 2 * Math.PI / n;

            //for (int j = 0; j < 10; j++)
            //{

            //    for (int i = 0; i <= n; i++)
            //    {
            //        double x1 = r * Math.Cos(alfa1);
            //        double y1 = c * Math.Sin(alfa1);
            //        double x2 = r * Math.Cos(alfa1 + alfa2);
            //        double y2 = c * Math.Sin(alfa1 + alfa2);

            //        float h = (float)0.5 * pictureBox1.Height;
            //        float w = (float)0.5 * pictureBox1.Width;
            //        alfa1 += alfa2;

            //        g.DrawLine(pen0, (float)x1 + w, (float)y1 + h, (float)x2 + w, (float)y2 + h);

            //    }
            //}


            ////r = c;
            ////c += sth





        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1.4
            //500
           

            Double.TryParse(textBox1.Text, out n);
            r = 0;

            double alfa1 = 0;
            double alfa2 = 2 * Math.PI / n;

            for (int i = 0; i <= 2*n; i++)
            {
                double x1 = r * Math.Cos(alfa1);
                double y1 = r * Math.Sin(alfa1);
                double x2 = r * Math.Cos(alfa1 + alfa2);
                double y2 = r * Math.Sin(alfa1 + alfa2);

                float h = (float)0.5 * pictureBox1.Height;
                float w = (float)0.5 * pictureBox1.Width;
                alfa1 += alfa2;
                r += 0.2;

                g.DrawLine(pen0, (float)x1 + w, (float)y1 + h, (float)x2 + w, (float)y2 + h);

            }

           


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
