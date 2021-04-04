using ProjectRSA.Extensions;
using ProjectRSA.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRSA.Models
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
            Console.WriteLine("\n----- Parameters -----\n");
            Console.WriteLine("Calculate p and q");
            P = ParameterOperations.GetPrimeRandomNumber();
            Console.WriteLine($"p = {P}. p is prime");
            Q = ParameterOperations.GetPrimeRandomNumber();
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

        public void CipherMessage(string message)
        {
            var messageInts = MessageExtensions.ConvertToInt(message);
            var cipherMessage = messageInts.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(E, msg, N)).ToList();
            PrintMessage(cipherMessage);
        }

        public void DecipherMessage(IEnumerable<long> cipherNumbers)
        {
            var deciphers = cipherNumbers.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(D, msg, N)).ToList();
            var message = MessageExtensions.ConvertToMessage(deciphers);
            Console.WriteLine($"Message: {message}");
        }

        public void SignMessage(string message)
        {
            var messageInts = MessageExtensions.ConvertToInt(message);
            var messageSigned = messageInts.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(D, msg, N)).ToList();
            PrintMessage(messageSigned);
        }

        public void VerifyMessage(IEnumerable<long> cipherNumbers, string message)
        {
            var values = cipherNumbers.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(E, msg, N)).ToList();
            var messageSigned = MessageExtensions.ConvertToMessage(values);

            if (message != messageSigned)
                Console.WriteLine($"Different signatures");
            Console.WriteLine($"Signature verified");
            Console.WriteLine($"MessageSigned: {messageSigned} == Message: {message}");
        }

        private void PrintMessage(List<long> cipherMessage)
        {
            var printMessage = string.Empty;
            cipherMessage.ForEach(cipher => printMessage += $"{cipher},");
            Console.WriteLine(printMessage[0..^1]);
        }
    }
}
