using System;

namespace ProjectRSA.RSA
{
    public class RsaHandler
    {
        public void CalculateRsa()
        {
            SelectionOfParameters();
            CipherMessage();
            DecipherMessage();
        }

        private void DecipherMessage()
        {
            // N, d, c
        }

        private void CipherMessage()
        {
            // N, e, m
        }

        private void SelectionOfParameters()
        {
            Console.WriteLine("Calculate p and q");
            var p = ParameterSelection.GetPrimeRandomNumber(125);
            Console.WriteLine($"p = {p}. p is prime");
            var q = ParameterSelection.GetPrimeRandomNumber(6110);
            Console.WriteLine($"q = {q}. q is prime");
            var N = ParameterSelection.CalculateN(p, q);
            Console.WriteLine($"N = {N}");
            var PhiN = ParameterSelection.CalculatePhiN(p, q);
            Console.WriteLine($"Phi(N) = {PhiN}");
            Console.WriteLine("Calculate e and d");
            var e = ParameterSelection.CalculateE(PhiN);
            Console.WriteLine($"e = {e}");
            var d = ParameterSelection.CalculateD(PhiN, e);
            Console.WriteLine($"d = {d}");
        }
    }
}
