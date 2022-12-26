using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Lab1_kg_
{
    public partial class Form1 : Form
    {
        private Bitmap image, image2, image3, prevImage;

        private bool ImageIsNull()
        {
            if (pictureBox1.Image == null) MessageBox.Show("Загрузите фото.", "Ошибка!");
            return pictureBox1.Image == null;
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bt = new Bitmap(pictureBox1.Image);
          
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color c = bt.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int avg = (r + g + b) / 3;
                    bt.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            pictureBox1.Image = bt;
        }


        private void pSNRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PSNR filter = new PSNR();
            if (ImageIsNull()) return;
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(PSNR.Execute((Bitmap)pictureBox1.Image, (Bitmap)pictureBox3.Image).ToString());
            Cursor.Current = Cursors.Default;
        }

        private void sSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SSIM filter = new SSIM();
            if (ImageIsNull()) return;
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show(SSIM.Execute((Bitmap)pictureBox1.Image, (Bitmap)pictureBox3.Image).ToString());
            Cursor.Current = Cursors.Default;
        }

        #region Niblack
        int Slice(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        int binSlice(int val, int level)
        {
            int resVal = 0;
            int maxVal = 255;
            if (val >= level) return maxVal;
            return resVal;
        }
        void niblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m_size = 3;
            int T = 0;
            double k = 0.2;
            double sig = 0;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int radX = m_size / 2;
                    int radY = m_size / 2;

                    double new_color = 0;
                    for (int a = -radY; a <= radY; a++)

                        for (int b = -radX; b <= radX; b++)
                        {
                            int idX = Slice(i + b, 0, image.Width - 1);
                            int idY = Slice(j + a, 0, image.Height - 1);
                            Color neibCol = image.GetPixel(idX, idY);
                            new_color += neibCol.G;
                        }

                    new_color = new_color / (m_size * m_size);

                    for (int a = -radY; a <= radY; a++)

                        for (int b = -radX; b <= radX; b++)
                        {
                            int idX = Slice(i + b, 0, image.Width - 1);
                            int idY = Slice(j + a, 0, image.Height - 1);
                            Color neibCol = image.GetPixel(idX, idY);
                            sig += (neibCol.G - new_color) * (neibCol.G - new_color);
                        }

                    sig = Math.Sqrt(sig / Math.Pow(m_size, 2));


                    T = (int)(new_color + k * sig);
                }
            }


            Bitmap temp = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceCol2 = image.GetPixel(i, j);
                    Color resultCol = Color.FromArgb((int)(binSlice((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)),
                                                     (int)(binSlice((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)),
                                                     (int)(binSlice((int)(0.299 * sourceCol2.R + 0.587 * sourceCol2.G + 0.114 * sourceCol2.B), T)));
                    temp.SetPixel(i, j, resultCol);
                }

            pictureBox1.Image = temp;
            pictureBox1.Refresh();

        }
        #endregion

        #region Global
        public int[] CalculateHistogram(Bitmap image)
        {
            int[] hist = new int[256];

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    Color color = image.GetPixel(x, y);
                    hist[color.R]++;
                }
            return hist;
        }

        public Bitmap GlobalGist(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);

            int[] hist = CalculateHistogram(sourceImage);

            int histSum = hist.Sum();
            int cut = (int)(histSum * 0.05);

            for (int i = 0; i < 255; i++)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }

                if (cut <= 0) break;
            }

            cut = (int)(histSum * 0.05);

            for (int i = 255; i < 0; i--)
            {
                if (hist[i] < cut)
                {
                    cut -= hist[i];
                    hist[i] = 0;
                }

                if (cut <= 0) break;
            }

            int t = 0;

            int weight = 0;
            for (int i = 0; i < 255; i++)
            {
                if (hist[i] == 0) continue;

                weight += hist[i] * i;
            }

            t = (int)(weight / hist.Sum());

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color color = sourceImage.GetPixel(x, y);
                    if (color.R >= t) resImage.SetPixel(x, y, Color.White);
                    else resImage.SetPixel(x, y, Color.Black);

                }
            return resImage;
        }


        private void globalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GlobalGist(image);
            pictureBox1.Image = result;
            pictureBox1.Refresh();
        }

        #endregion

        
        //nonlocal
        private void nonlocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image2 = new Bitmap(pictureBox1.Image);
            
            int[,] arrR = new int[image2.Width, image2.Height];
            int[,] arrG = new int[image2.Width, image2.Height];
            int[,] arrB = new int[image2.Width, image2.Height];

            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    arrR[i, j] = image2.GetPixel(i, j).R;
                    arrG[i, j] = image2.GetPixel(i, j).G;
                    arrB[i, j] = image2.GetPixel(i, j).B;
                }
            }

            for (int i = 1; i < image2.Width - 1; i++)
            {
                for (int j = 1; j < image2.Height - 1; j++)
                {
                    int arrRSum = 0, arrGSum = 0, arrBSum = 0;
                    int arrsrR = 0, arrsrG = 0, arrsrB = 0;
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            arrRSum = arrRSum + arrR[i + x, j + y];
                            arrGSum = arrGSum + arrG[i + x, j + y];
                            arrBSum = arrBSum + arrB[i + x, j + y];
                        }
                    }
                    arrsrR = arrRSum / 9;
                    arrsrG = arrGSum / 9;
                    arrsrB = arrBSum / 9;
                    image2.SetPixel(i, j, Color.FromArgb(arrsrR, arrsrG, arrsrB));
                }
            }

            pictureBox1.Image = image2;
        }
        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = null;
                image = new Bitmap(dialog.FileName);
                image2 = new Bitmap(image.Width, image.Height);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        //exp
        private void expToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Bitmap res = new Bitmap(pictureBox1.Image);
            Random rand = new Random();

            for (int i = 0; i < res.Width; i++)
                for (int j = 0; j < res.Height; j++)
                {
                    Color sourceCol = res.GetPixel(i, j);
                    res.SetPixel(i, j, Color.FromArgb(Slice((int)(sourceCol.R + Math.Log10(1 - rand.NextDouble()) * 255), 0, 255), Slice((int)(sourceCol.G + Math.Log(1 - rand.NextDouble()) * 255), 0, 255), Slice((int)(sourceCol.B + Math.Log(1 - rand.NextDouble()) * 255), 0, 255)));
                }
            
            prevImage = image;
            image = res;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            pictureBox3.Image = prevImage;
            pictureBox3.Refresh();
        }

        //pinpoint
        private void pinpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {

                Color curColor;
                int ret;

                for (int iX = 0; iX < image.Width; iX++)
                {

                    for (int iY = 0; iY < image.Height; iY++)
                    {
                        curColor = image.GetPixel(iX, iY);

                        ret = (int)((curColor.R + curColor.G + curColor.B) / 3.0);

                        if (ret > 120)
                            ret = 255;
                        else
                            ret = 0;

                        image.SetPixel(iX, iY, Color.FromArgb(ret, ret, ret));
                    }
                }
                Invalidate();
                pictureBox1.Image = image;
            }
        }

        //white
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap res = (Bitmap)image.Clone();
            Random coordRand = new Random();
            int countNoise = (int)((image.Width * image.Height)/10);
            for(int i = 0; i < countNoise; i++)
            {
             
                 int x = coordRand.Next(0, image.Width);
                 int y = coordRand.Next(0, image.Height);
                res.SetPixel(x, y, Color.White);

            }
            prevImage = image;
            image = res;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            pictureBox3.Image = prevImage;
            pictureBox3.Refresh();
        }


        

        

        private void gistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(image);
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];
                }
            }

            int histHeight = 128;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;   
                    g.DrawLine(Pens.Black,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))  
                        );
                }
            }
            pictureBox2.Image = img;
           
        }

        private void lawsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevImage = new Bitmap(pictureBox1.Image);
            Laws frame = new Laws(prevImage);
            frame.Show();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevImage = new Bitmap(pictureBox1.Image);
            Cursor.Current = Cursors.WaitCursor;
            var g = new RegionPaint();
            this.pictureBox1.Image = g.Compute((Bitmap)pictureBox1.Image);
            Cursor.Current = Cursors.Default;
        }

        private void кореляцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Radius = 3;
            Bitmap startimage = Tools.Gray(new Bitmap(pictureBox1.Image));
            int[,] image = Tools.IntensivityMatrix(startimage);

            float[,] resimagef = new float[image.GetLength(0), image.GetLength(1)];

            Bitmap resimage = new Bitmap(startimage);

            for (uint i = 0; i < resimagef.GetLength(0); i++)
                for (uint j = 0; j < resimagef.GetLength(1); j++)
                {
                    int[,] part = Tools.MatrixPart(image, (uint)Radius, i, j);
                    int[,] g = GLCM.DiagonalGLCM(part);
                    resimagef[i, j] = GLCM.Correlation(g, GLCM.CountPair(part.GetLength(0), part.GetLength(1), GLCM.GLCMType.Diagonal));
                }

            float min = resimagef[0, 0];
            float max = resimagef[0, 0];

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {
                    if (resimagef[i, j] > max) max = resimagef[i, j];
                    if (resimagef[i, j] < min) min = resimagef[i, j];
                }

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {


                    int intensivity = (int)((resimagef[i, j] - min) * 255 / (max - min));
                    resimage.SetPixel(i, j, Color.FromArgb(intensivity, intensivity, intensivity));

                }

            pictureBox3.Image = resimage;
        }

        private void aSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Radius = 3;
            Bitmap startimage = Tools.Gray(new Bitmap(pictureBox1.Image));
            int[,] image = Tools.IntensivityMatrix(startimage);

            float[,] resimagef = new float[image.GetLength(0), image.GetLength(1)];

            Bitmap resimage = new Bitmap(startimage);

            for (uint i = 0; i < resimagef.GetLength(0); i++)
                for (uint j = 0; j < resimagef.GetLength(1); j++)
                {
                    int[,] part = Tools.MatrixPart(image, (uint)Radius, i, j);
                    int[,] g = GLCM.DiagonalGLCM(part);
                    resimagef[i, j] = GLCM.ASM(g, GLCM.CountPair(part.GetLength(0), part.GetLength(1), GLCM.GLCMType.Diagonal));
                }

            float min = resimagef[0, 0];
            float max = resimagef[0, 0];

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {
                    if (resimagef[i, j] > max) max = resimagef[i, j];
                    if (resimagef[i, j] < min) min = resimagef[i, j];
                }

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {
                    int intensivity = (int)((resimagef[i, j] - min) * 255 / (max - min));
                    resimage.SetPixel(i, j, Color.FromArgb(intensivity, intensivity, intensivity));
                }

            pictureBox3.Image = resimage;
        }

        private void контрастToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Radius = 3;
            Bitmap startimage = Tools.Gray(new Bitmap(pictureBox1.Image));
            int[,] image = Tools.IntensivityMatrix(startimage);

            float[,] resimagef = new float[image.GetLength(0), image.GetLength(1)];

            Bitmap resimage = new Bitmap(startimage);

            for (uint i = 0; i < resimagef.GetLength(0); i++)
                for (uint j = 0; j < resimagef.GetLength(1); j++)
                {
                    int[,] part = Tools.MatrixPart(image, (uint)Radius, i, j);
                    int[,] g = GLCM.DiagonalGLCM(part);
                    resimagef[i, j] = GLCM.Contrast(g, GLCM.CountPair(part.GetLength(0), part.GetLength(1), GLCM.GLCMType.Diagonal));
                }

            float min = resimagef[0, 0];
            float max = resimagef[0, 0];

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {
                    if (resimagef[i, j] > max) max = resimagef[i, j];
                    if (resimagef[i, j] < min) min = resimagef[i, j];
                }

            for (int i = 0; i < resimagef.GetLength(0); i++)
                for (int j = 0; j < resimagef.GetLength(1); j++)
                {
                    int intensivity = (int)((resimagef[i, j] - min) * 255 / (max - min));
                    resimage.SetPixel(i, j, Color.FromArgb(intensivity, intensivity, intensivity));
                }

            pictureBox3.Image = resimage;
        }

        public int clamp(int value, int min, int max) { return value < min ? min : value > max ? max : value; }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)   
        {
            double rmax = image.GetPixel(0, 0).R;
            double gmax = image.GetPixel(0, 0).G;
            double bmax = image.GetPixel(0, 0).B;

            double rmin = image.GetPixel(0, 0).R;
            double gmin = image.GetPixel(0, 0).G;
            double bmin = image.GetPixel(0, 0).B;

            image3 = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color tmp = image.GetPixel(i, j);
                    if (tmp.R > rmax)
                        rmax = tmp.R;
                    if (tmp.G > gmax)
                        gmax = tmp.G;
                    if (tmp.B > bmax)
                        bmax = tmp.B;

                    if (tmp.R < rmin)
                        rmin = tmp.R;
                    if (tmp.G < gmin)
                        gmin = tmp.G;
                    if (tmp.B < bmin)
                        bmin = tmp.B;
                }

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    Color tmp = image.GetPixel(i, j);
                    image3.SetPixel(i, j, Color.FromArgb((int)((tmp.R - rmin) / (rmax - rmin) * 255.0),
                                                     (int)((tmp.G - gmin) / (gmax - gmin) * 255.0),
                                                     (int)((tmp.B - bmin) / (bmax - bmin) * 255.0)));
                } 
            pictureBox1.Image = image3;
            pictureBox1.Refresh();

        }

        public Form1()
        {
            InitializeComponent();
        }
    }

}