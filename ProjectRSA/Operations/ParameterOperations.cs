using ProjectRSA.Extensions;
using System;

namespace ProjectRSA.Operations
{
    public class ParameterOperations
    {
        private const int MinValue = 32768;
        private const int MaxValue = 65535;

        public static long GetPrimeRandomNumber()
        {
            int random;
            do
            {
                random = new Random().Next(MinValue, MaxValue);
            } while (!PrimeExtensions.IsPrime(random));
           return random;
        }

        public static long CalculateN(long p, long q) => p * q;

        public static long CalculatePhiN(long p, long q) => (p - 1) * (q - 1);

        public static long CalculateE(long phiN)
        {
            long e;
            do
            {
                e = RandomExtensions.Next(1, phiN - 1);
            } while (NumberTheoryOperations.CalculateGcd(phiN, e) != 1);
            return e;
        }

        public static long CalculateD(long phiN, long e)  => 
            NumberTheoryOperations.CalculateMultiplicativeInverse(phiN, e);
    }
}
