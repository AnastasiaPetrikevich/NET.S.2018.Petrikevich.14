using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithm.Algorithms;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class AlgorithmsTests
    {
        #region Binary search tests

        [TestCase(new[] {1, 4, 61, 64, 71, 431}, 64, ExpectedResult = 3)]
        [TestCase(new[] {1, 4, 12, 424, 523, 526}, 1, ExpectedResult = 0)]
        [TestCase(new[] {-421, 4, 45, 63, 124, 532, 612, 4444}, 612, ExpectedResult = 6)]
        [TestCase(new[] {21, 42, 4124, 5555, 66634}, 66634, ExpectedResult = 4)]
        [TestCase(new[] {-421, 4, 6, 8, 122, 445, 615}, 4, ExpectedResult = 1)]
        [TestCase(new[] {1, 4, 7, 10, 14, 415, 655}, 3, ExpectedResult = -1)]
        [TestCase(new int[0], 3, ExpectedResult = -1)]
        public static int BinarySearch_Result(int[] array, int element) => BinarySearch(array, element, null);

        #endregion



        #region Fibonacci numbers tests

        [TestCase(4, ExpectedResult = new int[] {1, 1, 2, 3})]
        [TestCase(10, ExpectedResult = new int[] {1, 1, 2, 3, 5, 8, 13, 21, 34, 55})]
        [TestCase(22, ExpectedResult = new int[]
            {1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711})]
        public static List<int> Fibonaccinumbers_Result(int quantity) => FibonacciSequance(quantity);

        #endregion
    }
}
