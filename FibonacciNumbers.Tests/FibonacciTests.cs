using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static FibonacciNumbers.Fibonacci;

namespace FibonacciNumbers.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        public static IEnumerable FibonacciTestCases
        {
            get
            {
                yield return new TestCaseData(5).Returns(new BigInteger[] { 0, 1, 1, 2, 3 });
                yield return new TestCaseData(7).Returns(new BigInteger[] { 0, 1, 1, 2, 3, 5, 8 });
                yield return new TestCaseData(11).Returns(new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 });
                yield return new TestCaseData(17).Returns(new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 });
                yield return new TestCaseData(23).Returns(new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711 });

            }
        }

        [Test, TestCaseSource(nameof(FibonacciTestCases))]
        public IEnumerable<BigInteger> FibonacciSequance_Result(int quantity) => FibonacciSequance(quantity);


        [TestCase(0)]
        [TestCase(-1)]
        public void FibonacciSequance_ArgumentException(int quantity) =>
            Assert.Throws<ArgumentException>(() => FibonacciSequance(quantity));

    }
}
