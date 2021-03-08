using System;

namespace ProjectRSA
{
    /// <summary>
    /// Determine if the number is prime using Miller-Rabin algorithm
    /// </summary>
    public static class PrimeExtensions
    {
        /// <summary>
        ///  n = 2^s*d + 1
        /// </summary>
        public static bool IsPrime(int number)
        {
            if (number % 2 == 0) return false;
            if (number <= 3) return true;

            var d = number - 1;
            d /= 2;

            var numberOfRounds = 5;
            for (var i = 0; i < numberOfRounds; i++)
            {
                var modularExponentiation = GetModularExponentiation(number, d);
                if (modularExponentiation == 1 || modularExponentiation == number - 1) return true;

                while (d != number - 1)
                {
                    modularExponentiation = (int)Math.Pow(modularExponentiation, 2) % number;
                    d = d*2;

                    if (IsComposite(modularExponentiation)) return false;
                    if (modularExponentiation == number - 1) return true;
                }
            }
            return false;
        }

        /// <summary>
        ///  Generate random in the range of [2, n-2]
        /// </summary>
        private static int GetModularExponentiation(int number, int d)
        {
            var random = new Random().Next(2, number - 2);
            var modularExponentiation = 1;
            while (d > 0)
            {
                if (d % 2 == 1)
                    modularExponentiation = (modularExponentiation * random) % number;
                d = d/2;
                random = (int)Math.Pow(random, 2) % number;
            }
            return modularExponentiation;
        }

        private static bool IsComposite(int modularExponentiation)
        {
            return modularExponentiation == 1;
        }
    }
}