using System;

namespace ProjectRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = GetPrimeRandomNumber(125);
            Console.WriteLine($"p = {p}. p is prime");
            var q = GetPrimeRandomNumber(6110);
            Console.WriteLine($"q = {q}. q is prime");
        }

        private static int GetPrimeRandomNumber(int seed)
        {
            var random = 0;
            while (!IsPrime(random))
            {
                random = new Random(seed).Next(32768, 65535);
                seed += 2;
            }

            return random;
        }

        /// <summary>
        ///  n = 2^s⋅d + 1
        ///  randomHelper in [2, n-2]
        /// </summary>
        private static bool IsPrime(int number)
        {
            if (number <= 1 || number % 2 == 0) return false;
            if (number <= 3) return true;
            int d = number - 1;
            if (d % 2 == 0)
                d /= 2;

            var witnesses = 10;
            for(var i=0; i < witnesses; i++)
            {
                var randomHelper = new Random().Next(2, number-2);
                var powMod = 1;
                var dAux = d;
                 while(dAux > 0)
                {
                    if (d % 2 == 1) powMod = (powMod * randomHelper) % number;
                    dAux = dAux / 2;
                    randomHelper = (int)Math.Pow(randomHelper, 2) % number;
                }

                if (powMod == 1 || powMod == number - 1) return true;

                while(d != number - 1)
                {
                    powMod = (int)Math.Pow(powMod, 2) % number;
                    d *= 2;

                    if (powMod == 1) return false;
                    if (powMod == number - 1) return true;
                }
            }
            return false;
        }
    }
}
