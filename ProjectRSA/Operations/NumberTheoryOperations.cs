using System;
using System.Linq;

namespace ProjectRSA.Operations
{
    public class NumberTheoryOperations
    {
        /// <summary>
        /// Euclidian algorithm
        /// </summary>
        /// <param name="bigNumber"></param>
        /// <param name="smallNumber"></param>
        /// <returns></returns>
        public static long CalculateGcd(long bigNumber, long smallNumber)
        {
            var number1 = bigNumber;
            var number2 = smallNumber;

            while (number2 != 0)
            {
                var remainder = number1 % number2;
                number1 = number2;
                number2 = remainder;
            }
            return number1;
        }

        /// <summary>
        /// Euclidian extended algorithm
        /// </summary>
        /// <param name="number"></param>
        /// <param name="inverse"></param>
        /// <returns></returns>
        public static long CalculateMultiplicativeInverse(long number, long inverse)
        {
            long x = 1;
            long y = 0;
            long number0 = number;
            long r = 0;
            long s = 1;
            long valueToInverse = inverse;

            while(valueToInverse > 0)
            {
                var wholeNumber = number0 / valueToInverse;
                var u = x - wholeNumber * r;
                var v = y - wholeNumber * s;
                var w = number0 - wholeNumber * valueToInverse;
                x = r;
                y = s;
                number0 = valueToInverse;
                r = u;
                s = v;
                valueToInverse = w;
            }

            return y > 0 ? y: number+y;
        }

        public static long CalculateSquareAndMultiply(long exponent, long @base, long mod)
        {
            var binary = Convert.ToString(exponent, 2);
            var binaryArray = binary.Select(b => int.Parse(b.ToString())).ToList();
            binaryArray.Reverse();
            long result = 1;

            for (var i = 0; i < binaryArray.Count; i++)
            {
                var bit = binaryArray.ElementAt(i);
                if (bit == 1)
                    result = (@base * result) % mod;

                @base = (long)(@base * @base) % mod;
            }
            return result;
        }
    }
}
