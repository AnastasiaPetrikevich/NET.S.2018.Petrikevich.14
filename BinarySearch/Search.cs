using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public static class Search
    {
        /// <summary>
        /// Binary search in a sorted array.
        /// </summary>
        /// <param name="array">Sorted ascending array.</param>
        /// <param name="element">Search element.</param>
        /// <param name="comparer">How to compare elements.</param>
        /// <returns>Returns the index of searched element.</returns>
        public static int BinarySearch<T>(this T[] array, T element, Comparison<T> comparer = null)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} mustn't be null.");
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default.Compare;
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
        /// Binary search in a sorted array.
        /// </summary>
        /// <param name="array">Sorted ascending array.</param>
        /// <param name="element">Search element.</param>
        /// <param name="comparer">How to compare elements.</param>
        /// <returns>Returns the index of searched element.</returns>
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} mustn't be null.");
            }

            if (array.Length == 0)
            {
                return -1;
            }

            return array.BinarySearch(element, comparer.Compare);
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
    }
}
