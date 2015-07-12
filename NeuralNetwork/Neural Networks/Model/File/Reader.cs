using System.IO;

namespace Neural_Networks
{
    /// <summary>
    /// Give bbytes from file with digits
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// Reads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>all content of file</returns>
        public byte[] Read(string path)
        {
            FileStream fs = new FileStream(path,
                                           FileMode.Open,
                                           FileAccess.Read);
            return File.ReadAllBytes(path);
        }
    }
}
