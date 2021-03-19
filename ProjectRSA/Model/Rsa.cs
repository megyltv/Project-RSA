using ProjectRSA.Operations;
using System;

namespace ProjectRSA.Model
{
    public class Rsa
    {
        public long P { get; set; }
        public long Q { get; set; }
        public long N { get; set; }
        public long PhiN { get; set; }
        public long E { get; set; }
        public long D { get; set; }

        public void SetValues()
        {
            Console.WriteLine("Calculate p and q");
            P = ParameterOperations.GetPrimeRandomNumber(125);
            Console.WriteLine($"p = {P}. p is prime");
            Q = ParameterOperations.GetPrimeRandomNumber(6110);
            Console.WriteLine($"q = {Q}. q is prime");
            N = ParameterOperations.CalculateN(P, Q);
            Console.WriteLine($"N = {N}");
            PhiN = ParameterOperations.CalculatePhiN(P, Q);
            Console.WriteLine($"Phi(N) = {PhiN}");
            Console.WriteLine("Calculate e and d");
            E = ParameterOperations.CalculateE(PhiN);
            Console.WriteLine($"e = {E}");
            D = ParameterOperations.CalculateD(PhiN, E);
            Console.WriteLine($"d = {D}");
        }
    }
}
