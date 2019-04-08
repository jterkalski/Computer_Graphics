using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafika5
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 2);
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 1);


        PointF a, b, c, d;

        PointF [] punkty;



        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }







        private void button4_Click(object sender, EventArgs e)
        {
            //przynależność do wielokąta

            pictureBox1.Refresh();

            punkty = new PointF[4];

            PointF xy = new PointF(150, 225);

            punkty[0].X = 100;
            punkty[0].Y = 100;
            punkty[1].X = 300;
            punkty[1].Y = 100;
            punkty[2].X = 100;
            punkty[2].Y = 300;
            punkty[3].X = 100;
            punkty[3].Y = 100;

            g.DrawLines(pen1, punkty);

            g.DrawEllipse(pen, xy.X, xy.Y, 5, 5);
            if(czyWSrodku(punkty,xy)==1) MessageBox.Show("W srodku");
            else MessageBox.Show("Na zewnatrz");



        }




        private void button3_Click(object sender, EventArgs e)
        {
            // czyPrzecinaja


            pictureBox1.Refresh();

            a.X = 100;
            a.Y = 100;
            b.X = 500;
            b.Y = 500;
            c.X = 150;
            c.Y = 50;
            d.X = 300;
            d.Y = 50;
            //d.Y=500; //żeby się przecinały

            g.DrawLine(pen1, a, b);
            g.DrawLine(pen1, c, d);

            if(czyPrzecinaja(a,b,c,d) == 1)
            {
                MessageBox.Show("Proste przecinaja sie");
            }
            else
            {
                MessageBox.Show("Proste nie przecinaja sie");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            // czyPoTejSamej

            pictureBox1.Refresh();

            a.X = 100;
            a.Y = 100;
            b.X = 500;
            b.Y = 500;
            c.X = 150;
            c.Y = 50;
            //d.X = 300;
            //d.Y = 50;
            d.X = 150;
            d.Y = 300;

            g.DrawLine(pen1, a, b);
            g.DrawEllipse(pen, c.X, c.Y, 5, 5);
            g.DrawEllipse(pen, d.X, d.Y, 5, 5);

            if (czyPoTejSamej(a, b, c, d) == 1)
            {
                MessageBox.Show("Punkty leza po tej samej stronie");
            }
            else
            {
                MessageBox.Show("Punkty leza po przeciwnych stronach");
            }

        }





        private void button1_Click(object sender, EventArgs e)
        {
            //poKtorej

            pictureBox1.Refresh();

            a.X = 100;
            a.Y = 100;
            b.X = 200;
            b.Y = 200;
            c.X = 150;
            c.Y = 150;

            g.DrawLine(pen1, a, b);
            g.DrawEllipse(pen, c.X, c.Y, 5, 5);

            int wynik = poKtorej(a, b, c);

            if(wynik == -1)
            {
                MessageBox.Show("Punkt lezy po prawej stronie");
            }
            else if (wynik == 0)
            {
                MessageBox.Show("Punkt lezy na prostej");
            }
            else
            {
                MessageBox.Show("Punkt lezy po lewej stronie");
            }


        }







        // FUNKCJE

        public int poKtorej(PointF a, PointF b, PointF c)
        {

            float det = a.X * b.Y * 1 + a.Y * 1 * c.X + 1 * b.X * c.Y - 1 * b.Y * c.X - a.Y * b.X * 1 - a.X * 1 * c.Y;

            return Math.Sign(det);
        }





        public int czyPoTejSamej(PointF a, PointF b, PointF c, PointF d)
        {
            int wynikC = poKtorej(a, b, c);
            int wynikD = poKtorej(a, b, d);

            if (wynikC == wynikD)
            {
                return 1;
            }
            else return -1;
        }





        public int czyPrzecinaja(PointF a, PointF b, PointF c, PointF d)
        {
            int wynikAB = czyPoTejSamej(a, b, c, d);
            int wynikCD = czyPoTejSamej(c, d, a, b);

            if (wynikAB == wynikCD && wynikAB==-1)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }



        int czyWSrodku( PointF [] punktu, PointF a)
        {
            int licznik=0;
            int wynik;
            PointF testowy = new PointF(0, 0);
            for(int i=0; i<punkty.Length-1; i++)
            {
                wynik = czyPrzecinaja(punkty[i], punkty[i + 1], testowy, a);
                if (wynik == 1) licznik++;
            }
            if (licznik % 2 == 0) return 0;
            else return 1;
        }


    }
}
