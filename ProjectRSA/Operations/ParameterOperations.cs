using ProjectRSA.Extensions;
using System;

namespace ProjectRSA.Operations
{
    public class ParameterOperations
    {
        public static long GetPrimeRandomNumber()
        {
            var random = new Random().Next(32768, 65535);
            while (!PrimeExtensions.IsPrime(random))
            {
                random = new Random().Next(32768, 65535);
            }
            return random;
        }

        public static long CalculateN(long p, long q) => p * q;

        public static long CalculatePhiN(long p, long q) => (p - 1) * (q - 1);

        public static long CalculateE(long phiN)
        {
            long e;
            var seed = 100;
            do
            {
                e = new Random(seed).Next(1, (int)phiN - 1);
                seed += 2;
            } while (NumberTheoryOperations.CalculateGcd(phiN, e) != 1);
            return e;
        }

        public static long CalculateD(long phiN, long e)  => 
            NumberTheoryOperations.CalculateMultiplicativeInverse(phiN, e);
    }
}
