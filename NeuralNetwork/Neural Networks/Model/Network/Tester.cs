using System;

namespace Neural_Networks
{
    /// <summary>
    /// Classe tests network
    /// </summary>
    public class Tester
    {
        /// <summary>
        /// Gets or sets the testing collection.
        /// </summary>
        /// <value>
        /// The testing collection.
        /// </value>
        TestingCollection TestingCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tester"/> class.
        /// </summary>
        /// <param name="testingCollection">The testing collection.</param>
        public Tester(TestingCollection testingCollection)
        {
            TestingCollection = testingCollection;
        }

        /// <summary>
        /// Tests the network.
        /// </summary>
        /// <param name="network">The network.</param>
        public void TestNetwork(TeachableNetwork network)
        {
            int passedTests = 0;
            int failedTests = 0;
            foreach (TestingSet testingSet in TestingCollection.Values)
            {
                network.ComputeNetworkResponse(testingSet.Input);
                double[] response = network.GetResponse();

                double max = -1;
                int index = 0;
                for (int i = 0; i < response.Length; i++)
                {
                    if (response[i] > max)
                    {
                        max = response[i];
                        index = i;
                    }
                }

                if (index == testingSet.Value)
                {
                    Console.WriteLine("Test passed: {0} recognized.", testingSet.Value);
                    passedTests++;
                }
                else
                {
                    Console.WriteLine("Test failed: {0} recognized instead {1}.", index, testingSet.Value);
                    failedTests++;
                }
            }
            Console.WriteLine("All passed tests: {0}.", passedTests);
            Console.WriteLine("All failed tests: {0}.", failedTests);
        }
    }
}
