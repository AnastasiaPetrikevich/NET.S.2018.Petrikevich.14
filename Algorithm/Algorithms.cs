using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Algorithms
    {
        #region Binary search

        /// <summary>
        /// Binary search in a sorted array.
        /// </summary>
        /// <param name="array">Sorted ascending array.</param>
        /// <param name="element">Search element.</param>
        /// <param name="comparer">How to compare elements.</param>
        /// <returns>Returns the index of searched element.</returns>
        public static int BinarySearch<T>(T[] array, T element, Comparison<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} mustn't be null.");
            }

            if (comparer == null)
            {
                comparer = Default;
            }

            if (!IsArraySorted(array, comparer))
            {
                throw new ArgumentException($"{nameof(array)} must be sorted.");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int middle = first + (last - first) / 2;

                if (comparer(element, array[middle]) == 0)
                {
                    return middle;
                }

                if (comparer(element, array[middle]) < 0)
                {
                    last = middle;
                }

                else
                {
                    first = middle + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Checks the array is sorted or not.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <param name="comparer">How to compare elements.</param>
        /// <returns>Returns true if array sorted.</returns>
        private static bool IsArraySorted<T>(T[] array, Comparison<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (comparer(array[i], array[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Default comparison value.
        /// </summary>
        private static int Default<T>(T first, T second) =>
            first.GetHashCode().CompareTo(second.GetHashCode());
        
        #endregion


        #region Fibonacci numbers

        /// <summary>
        /// Generates a Fibonacci sequence of a given length.
        /// </summary>
        /// <param name="quantity">Quantity of a numbers in the sequance.</param>
        /// <returns>Fibonacci sequance.</returns>
        public static List<long> FibonacciSequance(int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentNullException($"{nameof(quantity)} must be grater than or equal to 1");
            }

            List<long> numbers = new List<long>();
            for (int i = 0; i < quantity; i++)
            {
                numbers.Add(FibonacciNumber(i));
            }

            return numbers;
        }

        /// <summary>
        /// Find Fibonacci number.
        /// </summary>
        /// <param name="index">Index of a Fibonacci number.</param>
        /// <returns>Fibonacci number.</returns>
        private static long FibonacciNumber(int index)
        {
            long number = 0;

            if (index > 1)
            {
                number = FibonacciNumber(index - 1) + FibonacciNumber(index - 2);
            }

            else
            {
                return 1;
            }

            return number;
        }

        #endregion
    }
}
