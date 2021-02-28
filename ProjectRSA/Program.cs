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
            var N = p * q;
            Console.WriteLine($"N = {N}");
            var PhiN = (p-1) * (q-1);
            Console.WriteLine($"Phi(N) = {PhiN}");
        }

        public static int GetPrimeRandomNumber(int seed)
        {
            var random = 0;
            while (!PrimeExtensions.IsPrime(random))
            {
                random = new Random(seed).Next(32768, 65535);
                seed += 2;
            }
            return random;
        }
    }
}
