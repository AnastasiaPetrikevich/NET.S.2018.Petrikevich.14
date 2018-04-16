using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generates a Fibonacci sequence of a given length.
        /// </summary>
        /// <param name="quantity">Quantity of a numbers in the sequance.</param>
        /// <returns>Fibonacci sequance.</returns>
        public static IEnumerable<BigInteger> FibonacciSequance(int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentException(nameof(quantity));
            }

            return GenerateFibonacciSequance(quantity);
        }

        /// <summary>
        /// Generates a Fibonacci sequence of a given length.
        /// </summary>
        /// <param name="quantity">Quantity of a numbers in the sequance.</param>
        /// <returns>Fibonacci sequance.</returns>
       private static IEnumerable<BigInteger> GenerateFibonacciSequance(int quantity)
        {
            int current = 0;
            int next = 1;

            while (quantity > 0)
            {
                quantity--;
                yield return current;

                int temp = current + next;
                current = next;
                next = temp;
            }

        }
    }
}
