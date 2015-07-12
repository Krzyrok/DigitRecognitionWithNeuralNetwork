
namespace Neural_Networks
{
    /// <summary>
    /// Give informations about digits from file
    /// </summary>
    public class GiveItemsFromFile
    {
        private Reader _reader;
        private const int HOW_MANY_NUMBERS_TO_TRAIN = 60000;
        private const int HOW_MANY_NUMBERS_TO_TEST = 10000;
        private const int POSSIBILITIES_OF_RESULT = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="GiveItemsFromFile"/> class.
        /// </summary>
        public GiveItemsFromFile()
        {
            _reader = new Reader();
        }

        /// <summary>
        /// Gives the array of expected results.
        /// </summary>
        /// <returns>numbers</returns>
        public sbyte[,] GiveArrayOfExpectedResults()
        {
            return GiveArrayOfExpectedResults("train-labels.idx1-ubyte");
        }

        /// <summary>
        /// Gives the array of expected results.
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>numbers</returns>
        public sbyte[,] GiveArrayOfExpectedResults(string path)
        {
            sbyte[,] result = new sbyte[HOW_MANY_NUMBERS_TO_TRAIN, POSSIBILITIES_OF_RESULT];
            byte[] contentOfFile = _reader.Read(path);

            for (int number = 0; number < HOW_MANY_NUMBERS_TO_TRAIN; number++)
            {
                int numberFromFile = contentOfFile[number + 8];

                for (int i = 0; i < POSSIBILITIES_OF_RESULT; i++)
                {
                    if (i != numberFromFile)
                    {
                        result[number, i] = 0;
                    }
                    else
                    {
                        result[number, i] = 1;
                    }
                }
            }
            return result;
        }


        /// <summary>
        /// Gives the array of train data.
        /// </summary>
        /// <returns>values of pixels of numbers</returns>
        public sbyte[,] GiveArrayOfTrainData()
        {
            return GiveArrayOfTrainData("train-images.idx3-ubyte");
        }


        /// <summary>
        /// Gives the array of train data.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>values of pixels of numbers</returns>
        public sbyte[,] GiveArrayOfTrainData(string path)
        {
            const int sizeOfImage = 28 * 28; // heightOfImage * widthOfImage (28 x 28 pixel);
            sbyte[,] result = new sbyte[HOW_MANY_NUMBERS_TO_TRAIN, sizeOfImage];
            byte[] contentOfFile = _reader.Read(path);

            for (int number = 0; number < HOW_MANY_NUMBERS_TO_TRAIN; number++)
            {
                for (int i = 0; i < sizeOfImage; i++)
                {
                    if (contentOfFile[number * sizeOfImage + i + 16] < 50)
                    {
                        result[number, i] = 0;
                    }
                    else
                    {
                        result[number, i] = 1;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gives the array of expected results.
        /// </summary>
        /// <returns>numbers</returns>
        public byte[] GiveArrayOfExpectedResultsToTest()
        {
            return GiveArrayOfExpectedResultsToTest("t10k-labels.idx1-ubyte");
        }

        /// <summary>
        /// Gives the array of expected results.
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>numbers</returns>
        public byte[] GiveArrayOfExpectedResultsToTest(string path)
        {
            byte[] result = new byte[HOW_MANY_NUMBERS_TO_TEST];
            byte[] contentOfFile = _reader.Read(path);

            for (int number = 0; number < HOW_MANY_NUMBERS_TO_TEST; number++)
            {
                byte numberFromFile = contentOfFile[number + 8];
                result[number] = numberFromFile;
            }
            return result;
        }

        /// <summary>
        /// Gives the array of Test data.
        /// </summary>
        /// <returns>
        /// values of pixels of numbers
        /// </returns>
        public sbyte[,] GiveArrayOfTestData()
        {
            return GiveArrayOfTestData("t10k-images.idx3-ubyte");
        }

        /// <summary>
        /// Gives the array of Test data.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>values of pixels of numbers</returns>
        public sbyte[,] GiveArrayOfTestData(string path)
        {
            const int sizeOfImage = 28 * 28; // heightOfImage * widthOfImage (28 x 28 pixel);
            sbyte[,] result = new sbyte[HOW_MANY_NUMBERS_TO_TEST, sizeOfImage];
            byte[] contentOfFile = _reader.Read(path);

            for (int number = 0; number < HOW_MANY_NUMBERS_TO_TEST; number++)
            {
                for (int i = 0; i < sizeOfImage; i++)
                {
                    if (contentOfFile[number * sizeOfImage + i + 16] < 50)
                    {
                        result[number, i] = 0;
                    }
                    else
                    {
                        result[number, i] = 1;
                    }
                }
            }
            return result;
        }
    }
}
