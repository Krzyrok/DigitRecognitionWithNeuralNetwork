using System.Drawing;

namespace Neural_Networks
{
    /// <summary>
    /// Interface for model
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Finds the bounds of picture (which color is given in argument) on image and return rectangle.
        /// </summary>
        /// <param name="image">The image where function will be looking for bounds of picture.</param>
        /// <param name="colorOfPicture">The color of picture. This color will be sought</param>
        /// <returns>Rectangle which bounds are bounds of  picture</returns>
        Rectangle FindBoundsOfPictureOnImageAndReturnRectangle(Image image, Color colorOfPicture);

        /// <summary>
        /// Gives the array of integers from image.
        /// Prepares vector of integers for first layer of neural network.
        /// Element of vector says that pixel was or wasn't painted.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="colorOfPainted">The color of painted part of image.</param>
        /// <returns>double[] - vector of integers. 1 means that pixel was painted (different than colorofUnpainted), -1 means that pixel was unpainted </returns>
        double[] GiveArrayOfIntegersFromImage(Image image, Color colorOfPainted);
    }
}
