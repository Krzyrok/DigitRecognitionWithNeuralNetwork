using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Networks
{
    /// <summary>
    /// Class cuts number from image and prepares vector of integers from image
    /// </summary>
    public class Model : IModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        public Model()
        {
        }

        /// <summary>
        /// Finds the bounds of picture (which color is given in argument) on image and return rectangle.
        /// </summary>
        /// <param name="Image">The image.</param>
        /// <param name="colorOfPicture">The color of picture.</param>
        /// <returns>Rectangle which bounds are bounds of  picture</returns>
        public Rectangle FindBoundsOfPictureOnImageAndReturnRectangle(Image Image, Color colorOfPicture)
        {
            Bitmap bitmap = new Bitmap(Image);
            int xLeft = FindLeftBoundOfLetter(bitmap, colorOfPicture);
            int yTop = FindTopBoundOfLetter(bitmap, colorOfPicture);
            int xRight = FindRightBoundOfLetter(bitmap, colorOfPicture);
            int yBottom = FindBottomBoundOfLetter(bitmap, colorOfPicture);

            return new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop);
        }

        /// <summary>
        /// Gives the array of integers from image.
        /// Prepares vector of integers for first layer of neural network.
        /// Element of vector says that pixel was or wasn't painted.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="colorOfPpainted">The color of painted part of image.</param>
        /// <returns>
        /// double[] - vector of bytes. 1 means that pixel was painted (different than colorofUnpainted), 0 means that pixel was unpainted
        /// </returns>
        public double[] GiveArrayOfIntegersFromImage(Image image, Color colorOfPpainted)
        {
            Bitmap bitmap = new Bitmap(image);
            double[] result = new double[bitmap.Width * bitmap.Height];

            for (int line = 0; line < bitmap.Height; line++)
            {
                for (int column = 0; column < bitmap.Width; column++)
                {
                    Color color = bitmap.GetPixel(column, line);
                    if (color.ToArgb() == colorOfPpainted.ToArgb())
                    {
                        result[line * bitmap.Width + column] = 1;
                    }
                    else
                    {
                        result[line * bitmap.Width + column] = 0;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the left bound of letter.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="color">The color.</param>
        /// <returns>left bound of letter or if didn't find returns left bound of image</returns>
        private int FindLeftBoundOfLetter(Bitmap bitmap, Color color)
        {
            for (int x = 0; x < bitmap.Size.Width; x++)
            {
                for (int y = 0; y < bitmap.Size.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == color.ToArgb())
                    {
                        if (x > 0)
                            return x - 1;
                        else
                            return x;
                    }
                }

            }
            return 0;
        }

        /// <summary>
        /// Finds the top bound of letter.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="color">The color.</param>
        /// <returns>top bound of letter or if didn't find returns top bound of image</returns>
        private int FindTopBoundOfLetter(Bitmap bitmap, Color color)
        {
            for (int y = 0; y < bitmap.Size.Height; y++)
            {
                for (int x = 0; x < bitmap.Size.Width; x++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == color.ToArgb())
                    {
                        if (y > 0)
                            return y - 1;
                        else
                            return y;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Finds the right bound of letter.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="color">The color.</param>
        /// <returns>right bound of letter or if didn't find returns right bound of image</returns>
        private int FindRightBoundOfLetter(Bitmap bitmap, Color color)
        {
            for (int x = bitmap.Size.Width - 1; x >= 0; x--)
            {
                for (int y = bitmap.Size.Height - 1; y >= 0; y--)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == color.ToArgb())
                    {
                        if (x < bitmap.Size.Width - 1)
                            return x + 1;
                        else
                            return x;
                    }
                }
            }
            return bitmap.Size.Width - 1;
        }

        /// <summary>
        /// Finds the bottom bound of letter.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="color">The color.</param>
        /// <returns>bottom bound of letter or if didn't find returns bottom bound of image</returns>
        private int FindBottomBoundOfLetter(Bitmap bitmap, Color color)
        {
            for (int y = bitmap.Size.Height - 1; y >= 0; y--)
            {
                for (int x = bitmap.Size.Width - 1; x >= 0; x--)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() == color.ToArgb())
                    {
                        if (y < bitmap.Size.Height - 1)
                            return y + 1;
                        else
                            return y;                     
                    }
                }
            }
            return bitmap.Size.Height - 1;
        }
    }
}
