using System;

namespace ProjectRSA.RSA
{
    public class RsaHandler
    {
        public void CalculateRsa()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowRsaMenu();
            }
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

        private bool ShowRsaMenu()
        {
            Console.WriteLine("----- RSA -----");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Select parameters");
            Console.WriteLine("2. Cipher message");
            Console.WriteLine("3. Decipher message");
            Console.WriteLine("4. Exit");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    SelectionOfParameters();
                    return true;
                case "2":
                    CipherMessage();
                    return true;
                case "3":
                    DecipherMessage();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
