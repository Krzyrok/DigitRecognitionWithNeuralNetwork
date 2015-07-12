using System;
using System.Collections.Generic;

namespace Neural_Networks
{
    /// <summary>
    /// Class shuffles elements of list
    /// </summary>
    static class ShuffleList
    {
        static readonly Random Random = new Random();
        
        /// <summary>
        /// Shuffles the specified list.
        /// </summary>
        /// <typeparam name="T">Type of list's element</typeparam>
        /// <param name="list">The list.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
