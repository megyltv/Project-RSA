using ProjectRSA.Extensions;
using System;

namespace ProjectRSA.Operations
{
    public class ParameterOperations
    {
        public static int GetPrimeRandomNumber(int seed)
        {
            int random;
            do
            {
                random = new Random(seed).Next(32768, 65535);
                seed += 2;
            } while (!PrimeExtensions.IsPrime(random));
            return random;
        }

        public static int CalculateN(int p, int q) => p * q;

        public static int CalculatePhiN(int p, int q) => (p - 1) * (q - 1);

        public static int CalculateE(int phiN)
        {
            int e;
            var seed = 100;
            do
            {
                e = new Random(seed).Next(1, phiN - 1);
                seed += 2;
            } while (NumberTheoryOperations.CalculateGcd(phiN, e) != 1);
            return e;
        }

        public static int CalculateD(int phiN, int e)  => 
            NumberTheoryOperations.CalculateMultiplicativeInverse(phiN, e);
    }
}
