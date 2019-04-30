using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7 // filtry punktowe 10/10
{
    public partial class Form1 : Form
    {
        private Bitmap tmpbmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                tmpbmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;


            for(int i=0; i<bmp.Width; i++)
            {
                for (int j=0; j<bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    // R=0;
                    G = 0;
                    B = 0;

                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;

        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    R=0;
                   // G = 0;
                    B = 0;

                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    R=0;
                    G = 0;
                    //B = 0;

                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    R = 255 - R;
                    G = 255 - G;
                    B = 255 - B;

                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    double gray = 0.299 * R + 0.587 * G + 0.114 * B;

                    R = G = B = (int)gray;


                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;

        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;

                    int contrast;
                    int.TryParse(textBox1.Text, out contrast);

                    R = R - 128;
                    G = G - 128;
                    B = B - 128;

                    R = R * contrast;
                    G = G * contrast;
                    B = B * contrast;

                    R = R + 128;
                    G = G + 128;
                    B = B + 128;
                    
                    if (R<0) { R = 0; }
                    else if (R>255) { R = 255; }

                    if (G < 0) { G = 0; }
                    else if (G > 255) { G = 255; }

                    if (B<0) { B = 0; }
                    else if (B>255) { B = 255; }




                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;


        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = bmp.Width;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //Color colour = bmp.GetPixel(i, j);
                    Color colour = tmpbmp.GetPixel(i, j);

                    int R = colour.R;
                    int G = colour.G;
                    int B = colour.B;





                    //stopień zmiany koloru
                    int change; //100
                    int.TryParse(textBox2.Text, out change);

                    R = R + change;
                    G = G + change;
                    B = B + change;


                    if (R > 255) { R = 255; }
                    if (G > 255) { G = 255; }
                    if (B > 255) { B = 255; }




                    colour = Color.FromArgb(R, G, B);

                    bmp.SetPixel(i, j, colour);
                }
                progressBar1.Value = i;
            }

            pictureBox1.Image = bmp;
        }






    }
}

//filtry morfologiczne - otoczenie piksela wpływa na jego wartość