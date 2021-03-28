using ProjectRSA.Extensions;
using ProjectRSA.Model;
using ProjectRSA.Operations;
using System;
using System.Linq;

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
            Console.WriteLine("\n----- Decryption -----\n");
            var rsa = new Rsa();
            Console.Write("Enter N: ");
            rsa.N = long.Parse(Console.ReadLine());
            Console.Write("Enter d: ");
            rsa.D = long.Parse(Console.ReadLine());
            Console.Write("Enter message: ");
            var cipher = Console.ReadLine();
            var ciphers = cipher.Split(',');
            var cipherNumbers = ciphers.Select(cipher => long.Parse(cipher.Trim()));
            var deciphers = cipherNumbers.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(rsa.D, msg, rsa.N)).ToList();
            var message = MessageExtensions.ConvertToMessage(deciphers);
            Console.WriteLine($"Message: {message}");
        }

        private void CipherMessage()
        {
            Console.WriteLine("\n----- Encryption -----\n");
            var rsa = new Rsa();
            Console.Write("Enter N: ");
            rsa.N = long.Parse(Console.ReadLine());
            Console.Write("Enter e: ");
            rsa.E = long.Parse(Console.ReadLine());
            Console.Write("Enter message: ");
            var message = Console.ReadLine();
            var messageInts = MessageExtensions.ConvertToInt(message);
            var cipherMessage = messageInts.Select(msg => NumberTheoryOperations.CalculateSquareAndMultiply(rsa.E, msg, rsa.N)).ToList();
            var printMessage = string.Empty;
            cipherMessage.ForEach(cipher => printMessage += $"{cipher},");
            Console.WriteLine(printMessage.Substring(0, printMessage.Length-1));
        }

        private bool ShowRsaMenu()
        {
            Console.WriteLine("\n----- RSA -----\n");
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
