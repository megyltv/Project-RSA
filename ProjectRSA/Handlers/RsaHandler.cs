using ProjectRSA.Model;
using System;

namespace ProjectRSA.Handlers
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
            var rsa = new Rsa();
            // N, e, m
            Console.Write("Enter N: ");
            rsa.N = int.Parse(Console.ReadLine());
            Console.Write("Enter e: ");
            rsa.E = int.Parse(Console.ReadLine());
            Console.Write("Enter message: ");
            var message = Console.ReadLine();
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
                    var rsa = new Rsa();
                    rsa.SetValues();
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
