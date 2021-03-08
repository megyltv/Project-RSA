﻿namespace ProjectRSA
{
    public class NumberTheoryOperations
    {
        /// <summary>
        /// Euclidian algorithm
        /// </summary>
        /// <param name="bigNumber"></param>
        /// <param name="smallNumber"></param>
        /// <returns></returns>
        public static int CalculateGcd(int bigNumber, int smallNumber)
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
        public static int CalculateMultiplicativeInverse(int number, int inverse)
        {
            var x = 1;
            var y = 0;
            var number0 = number;
            var r = 0;
            var s = 1;
            var valueToInverse = inverse;

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
    }
}
