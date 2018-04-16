using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class SearchTests
    {
        [TestCase(new int[] { 1, 4, 61, 64, 71, 431 }, 64, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 4, 12, 424, 523, 526 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { -421, 4, 45, 63, 124, 532, 612, 4444 }, 612, ExpectedResult = 6)]
        [TestCase(new int[] { }, 3, ExpectedResult = -1)]
        public static int BinarySearch_InIntegerArray_Result(int[] array, int element) => array.BinarySearch(element);


        [TestCase(new string[] { "A", "b", "B","C", "d" }, "B", ExpectedResult = 2)]
        [TestCase(new string[] { "A", "b", "B", "C", "d" }, "d",ExpectedResult = 4)]
        [TestCase(new string[] { "A", "b", "B", "C", "d" }, "N", ExpectedResult = -1)]
        public static int BinarySearch_InStringArray_Result(string[] array, string element)
        {
            Comparison<string> comparison = (string lhs, string rhs) => lhs.CompareTo(rhs);
            return array.BinarySearch(element,comparison);
        }




    }
}
