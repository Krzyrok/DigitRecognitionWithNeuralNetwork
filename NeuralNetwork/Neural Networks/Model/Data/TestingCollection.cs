using System.Collections.Generic;

namespace Neural_Networks
{
    /// <summary>
    /// Structure for one data - one number(digit) to trainig network
    /// </summary>
    public struct TestingSet
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
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value of number.
        /// </value>
        public int Value
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Collection for all datas to testing network
    /// </summary>
    public class TestingCollection
    {
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// All datas to testing for network.
        /// </value>
        public List<TestingSet> Values
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestingCollection"/> class.
        /// </summary>
        public TestingCollection()
        {
            Values = new List<TestingSet>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestingCollection"/> class.
        /// </summary>
        /// <param name="n">Number of digits to learn for network.</param>
        public TestingCollection(int n)
        {
            Values = new List<TestingSet>(n);
        }

        /// <summary>
        /// Loads the standard data from file.
        /// </summary>
        /// <returns>Collection with datas</returns>
        public static TestingCollection LoadStandardData()
        {
            const int HOW_MANY_NUMBERS_TO_TEST_FROM_FILE = 100;
            TestingCollection collection = new TestingCollection(HOW_MANY_NUMBERS_TO_TEST_FROM_FILE);
            
            GiveItemsFromFile itemReturner = new GiveItemsFromFile();
            byte[] expectedResultFromFile = itemReturner.GiveArrayOfExpectedResultsToTest();
            sbyte[,] trainDataFromFile = itemReturner.GiveArrayOfTestData();
            const int SIZE_OF_IMAGE = 28 * 28;

            int[] indexes = RandomIndexes.GiveArrayOfRandomDifferentIntegers(HOW_MANY_NUMBERS_TO_TEST_FROM_FILE, 10000);

            for (int numberCounter = 0; numberCounter < HOW_MANY_NUMBERS_TO_TEST_FROM_FILE; numberCounter++)
            {
                int index = indexes[numberCounter];
                int expectedResult = expectedResultFromFile[index];

                double[] testData = new double[SIZE_OF_IMAGE];
                for (int i = 0; i < SIZE_OF_IMAGE; i++)
                {
                    testData[i] = trainDataFromFile[index, i];
                }

                TestingSet testingSet = new TestingSet();
                testingSet.Input = testData;
                testingSet.Value = expectedResult;

                collection.Values.Add(testingSet);
            }

            return collection;
        }
    }
}
