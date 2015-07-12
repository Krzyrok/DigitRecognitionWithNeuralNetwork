using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Neural_Networks
{
    /// <summary>
    /// Structure for one data - one number(digit) to testing network
    /// </summary>
    [Serializable]
    public struct TrainingSet
    {
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public double[] Input
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public double[] Response
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of number.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Collection for all datas to training network
    /// </summary>
    [Serializable]
    public class TrainingCollection
    {
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// All datas to learning for network.
        /// </value>
        public List<TrainingSet> Values
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingCollection"/> class.
        /// </summary>
        public TrainingCollection()
        {
            Values = new List<TrainingSet>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingCollection"/> class.
        /// </summary>
        /// <param name="n">Number of digits to learn for network</param>
        public TrainingCollection(int n)
        {
            Values = new List<TrainingSet>(n);
        }

        /// <summary>
        /// Loads the standard data from file.
        /// </summary>
        /// <returns>Collection with datas</returns>
        public static TrainingCollection LoadStandardData()
        {
            const int HOW_MANY_NUMBERS_TO_LEARN_FROM_FILE = 1000;
            TrainingCollection collection = new TrainingCollection(HOW_MANY_NUMBERS_TO_LEARN_FROM_FILE);
            
            GiveItemsFromFile itemReturner = new GiveItemsFromFile();
            sbyte[,] expectedResultFromFile = itemReturner.GiveArrayOfExpectedResults();
            sbyte[,] trainDataFromFile = itemReturner.GiveArrayOfTrainData();
            const int NUMBER_OF_RESULTS = 10;
            const int SIZE_OF_IMAGE = 28 * 28;

            for (int numberCounter = 0; numberCounter < HOW_MANY_NUMBERS_TO_LEARN_FROM_FILE; numberCounter++)
            {
                double[] expectedResult = new double[NUMBER_OF_RESULTS];
                int whatNumber = -1;
                for (int i = 0; i < NUMBER_OF_RESULTS; i++)
                {
                    expectedResult[i] = expectedResultFromFile[numberCounter, i];
                    if (expectedResult[i] == 1)
                        whatNumber = i;
                }

                double[] trainData = new double[SIZE_OF_IMAGE];
                for (int i = 0; i < SIZE_OF_IMAGE; i++)
                {
                    trainData[i] = trainDataFromFile[numberCounter, i];
                }

                TrainingSet trainingSet = new TrainingSet();
                trainingSet.Input = trainData;
                trainingSet.Response = expectedResult;
                trainingSet.Value = whatNumber;

                collection.Values.Add(trainingSet);
            }

            return collection;
        }

        /// <summary>
        /// Saves the user data (numbers which was added by user).
        /// </summary>
        /// <param name="path">The path, when datas will be saved.</param>
        public void SaveUserData(String path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, this);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Serialize was failed: " + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        /// <summary>
        /// Loads the user data (numbers which was added by user earlier).
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Collection of datas which was was added by user earlier</returns>
        public static TrainingCollection LoadUserData(String path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            TrainingCollection trainingCollection;

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                trainingCollection = (TrainingCollection)binaryFormatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine("Deserialize was failed: " + exception.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }

            return trainingCollection;
        }
    }
}
