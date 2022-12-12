using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_kg_
{
    internal class Tools
    {
        static public int clamp(int value, int min, int max) { return value < min ? min : value > max ? max : value; }
        static public Bitmap Gray(Bitmap Image)
        {
            int max = 0, min = 255;
            Bitmap imageC = new Bitmap(Image.Width, Image.Height);

            for (int i = 0; i < Image.Width; i++)
                for (int j = 0; j < Image.Height; j++)
                {
                    Color color = Image.GetPixel(i, j);
                    int x = (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                    if (x > max) max = x;
                    if (x < min) min = x;
                    imageC.SetPixel(i, j, Color.FromArgb(x, x, x));   // To grey
                }
            /*
            for (int i = 0; i < Image.Width; i++)
                for (int j = 0; j < Image.Height; j++)
                {
                    int intensivity = imageC.GetPixel(i, j).R;
                    intensivity = (int) ((intensivity - min) * 255 / (max - min));
                    imageC.SetPixel(i, j, Color.FromArgb(intensivity, intensivity, intensivity)); //linear stretch
                }*/

            return imageC;
        }

        static public int[,] IntensivityMatrix(Bitmap Image)
        {
            int[,] Intensivities = new int[Image.Width, Image.Height];
            for (int i = 0; i < Image.Width; i++)
                for (int j = 0; j < Image.Height; j++)
                    Intensivities[i, j] = Image.GetPixel(i, j).R;

            return Intensivities;
        }

        static public int[,] ZerosMatrix(uint a)
        {
            if (a < 1) return null;
            int[,] Zeros = new int[a, a];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < a; j++)
                    Zeros[i, j] = 0;
            return Zeros;
        }

        static public int[,] MatrixPart(int[,] image, uint radius, uint x, uint y)
        {
            int[,] result = new int[Math.Min(x, radius) + 1 + Math.Min(radius, image.GetLength(0) - x - 1), Math.Min(y, radius) + 1 + Math.Min(radius, image.GetLength(1) - y - 1)];

            int i1 = 0, i2 = 0;

            for (int i = -(int)radius; i <= radius; i++)
            {

                for (int j = -(int)radius; j <= radius; j++)
                {
                    if (x + i >= 0 && x + i <= image.GetLength(0) - 1 && y + j >= 0 && y + j <= image.GetLength(1) - 1)
                    {
                        result[i1, i2] = image[x + i, y + j];
                        i2++;
                    }
                }

                if (i2 != 0)
                {
                    i1++;
                    i2 = 0;
                }
            }

            return result;

        }

        public static int[] GetHistogramArray(Bitmap image)
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

        public static Bitmap GrayScaleImage(Bitmap sourceImage)
        {
            Bitmap resImage = sourceImage;

            int width = resImage.Width;
            int height = resImage.Height;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color color = resImage.GetPixel(x, y);
                    byte gray = (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
                    resImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }

            return resImage;
        }

        public static byte ClampByte(float value, float min, float max)
        {
            return (byte)(Math.Min(Math.Max(min, value), max));
        }

        public static int ClampInt(float value, float min, float max)
        {
            return (int)(Math.Min(Math.Max(min, value), max));
        }

        public static byte GetBrightness(Color color)
        {
            return (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
        }
    }
}
