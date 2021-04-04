using ProjectRSA.Handlers;
using System;

namespace ProjectRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var showMenu = true;
            while (showMenu) {
                showMenu = ShowMenu();
            }
        }

        private static bool ShowMenu()
        {
            Console.WriteLine("Project INSE-6110");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Project part 1 - RSA");
            Console.WriteLine("2. Project part 2 - Signature");
            Console.WriteLine("3. Exit");
            Console.Write("Option: ");
            switch (Console.ReadLine())
            {
                case "1":
                    var rsa = new RsaHandler();
                    rsa.CalculateRsa();
                    return true;
                case "2":
                    var signature = new SignatureHandler();
                    signature.CalculateSignature();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
