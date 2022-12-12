using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1_kg_
{
    internal partial class Laws : Form
    {
        private PictureBox LE;
        private PictureBox EE;
        private PictureBox ES;
        private PictureBox ER;
        private PictureBox LR;
        private PictureBox LS;
        private PictureBox RR;
        private PictureBox SR;
        private PictureBox SS;

        public Laws(Bitmap sourceImage)
        {
            InitializeComponent();

            Bitmap[] Laws = CalculateLaws(sourceImage);

            LE.Image = Laws[0]; LS.Image = Laws[1]; LR.Image = Laws[2];
            EE.Image = Laws[3]; ES.Image = Laws[4]; ER.Image = Laws[5];
            SS.Image = Laws[6]; SR.Image = Laws[7]; RR.Image = Laws[8];
        }

        public Bitmap[] CalculateLaws(Bitmap sourceImage)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);
            resImage = Preprocess(sourceImage);

            int[] L = { 1, 4, 6, 4, 1 };
            int[] E = { -1, -2, 0, 2, 1 };
            int[] S = { -1, 0, 2, 0, -1 };
            int[] R = { 1, -4, 6, -4, 1 };

            int[][] m = { L, E, S, R };
            int[,] mask;
            Bitmap[] result = new Bitmap[16];
            for (int i = 0; i < 16; i++)
                result[i] = new Bitmap(resImage.Width, resImage.Height);
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    mask = mult(m[i], m[j]);
                    Bitmap Fk = GetFilter(resImage, mask);
                    result[i * 4 + j] = Fk;
                }
            Bitmap LE = GetMean(result[1], result[4]);
            Bitmap LS = GetMean(result[2], result[8]);
            Bitmap LR = GetMean(result[3], result[12]);
            Bitmap EE = result[5];
            Bitmap ES = GetMean(result[6], result[9]);
            Bitmap ER = GetMean(result[7], result[13]);
            Bitmap SS = result[10];
            Bitmap SR = GetMean(result[11], result[14]);
            Bitmap RR = result[15];

            Bitmap[] tmp = new Bitmap[9];
            tmp[0] = LE; tmp[1] = LS; tmp[2] = LR;
            tmp[3] = EE; tmp[4] = ES; tmp[5] = ER;
            tmp[6] = SS; tmp[7] = SR; tmp[8] = RR;

            return tmp;
        }

        private Bitmap Preprocess(Bitmap sourceImage)
        {
            Bitmap resImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int lm;
                    int s = 0, c = 0;
                    int radius = 7;
                    for (int l = -radius; l <= radius; l++)
                        for (int k = -radius; k <= radius; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);

                            s += GetBrightness(sourceImage.GetPixel(idX, idY));
                            c++;
                        }
                    lm = clamp(s / c, 0, 255);
                    byte t = GetBrightness(sourceImage.GetPixel(x, y));
                    int res = clamp(t - lm, 0, 255); //t-lm
                    Color color = Color.FromArgb(res, res, res);
                    resImage.SetPixel(x, y, color);
                }
            return resImage;
        }
        private int[,] mult(int[] v1, int[] v2)
        {
            int[,] m = new int[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    m[i, j] = 0;

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    m[i, j] += v1[i] * v2[j];
            return m;
        }

        private Bitmap GetFilter(Bitmap sourceImage, int[,] kernel)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            Bitmap resImage = new Bitmap(width, height);

            for (int y = 0; y < sourceImage.Height; y++)
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    int radiusX = kernel.GetLength(0) / 2;
                    int radiusY = kernel.GetLength(1) / 2;
                    float resultR = 0, resultG = 0, resultB = 0;

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);
                            resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                            resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                            resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    resImage.SetPixel(x, y, Color.FromArgb(clamp((int)resultR, 0, 255),
                                         clamp((int)resultG, 0, 255),
                                         clamp((int)resultB, 0, 255)));
                }
            return resImage;
        }

        private Bitmap GetMean(Bitmap image1, Bitmap image2)
        {
            Bitmap res = new Bitmap(image1.Width, image1.Height);
            for (int y = 0; y < image1.Height; y++)
                for (int x = 0; x < image1.Width; x++)
                {
                    int c1 = GetBrightness(image1.GetPixel(x, y));
                    int c2 = GetBrightness(image2.GetPixel(x, y));
                    int c = (c1 + c2) / 2;
                    res.SetPixel(x, y, Color.FromArgb(c, c, c));
                }
            return res;
        }

        public static byte clamp(float value, float min, float max)
        {
            return (byte)(Math.Min(Math.Max(min, value), max));
        }

        public static int clamp(int value, int min, int max)
        {
            return (int)(Math.Min(Math.Max(min, value), max));
        }

        private static byte GetBrightness(Color color)
        {
            return (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
        }

        

        private void Laws_Load(object sender, EventArgs e)
        {

        }

    }
}