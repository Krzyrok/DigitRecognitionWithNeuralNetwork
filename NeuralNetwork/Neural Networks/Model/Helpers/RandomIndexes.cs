using System;

namespace Neural_Networks
{
    /// <summary>
    /// Class gives random different indexes
    /// </summary>
    public class RandomIndexes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomIndexes"/> class.
        /// </summary>
        public RandomIndexes()
        {
        }


        /// <summary>
        /// Gives the array of random different integers.
        /// </summary>
        /// <param name="howMany">How many indexec user needs.</param>
        /// <param name="maxValue">The maximum value of one index.</param>
        /// <returns>The array of random different integers.</returns>
        public static int[] GiveArrayOfRandomDifferentIntegers(int howMany, int maxValue)
        {
            int[] result = new int[howMany];
            int[] dbForNumber = new int[maxValue];

            for (int i = 0; i < maxValue; i++)
            {
                dbForNumber[i] = i;
            }

            Random random = new Random();

            for (int i = 0; i < howMany; i++)
            {
                int newIndex = random.Next(maxValue - i);
                result[i] = dbForNumber[newIndex];
                dbForNumber[newIndex] = dbForNumber[maxValue - i - 1];
            }

            return result;
        }
    }
}
