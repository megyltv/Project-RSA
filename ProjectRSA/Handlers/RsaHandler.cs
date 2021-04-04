using ProjectRSA.Model;
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
            var rsa = new Rsa
            {
                N = TryParse(ReadLineFromConsole("N")),
                D = TryParse(ReadLineFromConsole("d"))
            };
            Console.Write("Enter message: ");
            var cipher = Console.ReadLine();
            var ciphers = cipher.Split(',').ToList();
            var cipherNumbers = ciphers.Select(cipher => TryParse(cipher.Trim()));
            rsa.DecipherMessage(cipherNumbers);
        }

        private void CipherMessage()
        {
            Console.WriteLine("\n----- Encryption -----\n");
            var rsa = new Rsa
            {
                N = TryParse(ReadLineFromConsole("N")),
                E = TryParse(ReadLineFromConsole("e"))
            };
            Console.Write("Enter message: ");
            var message = Console.ReadLine();
            rsa.CipherMessage(message);
        }

        private string ReadLineFromConsole(string parameterName)
        {
            string line;
            do
            {
                Console.Write($"Enter {parameterName}: ");
                line = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(line));
            return line;
        }

        private long TryParse(string valueString)
        {
            var success = long.TryParse(valueString, out long value);
            if(success)
                return value;
            Console.WriteLine($"Invalid value provided: \"{valueString}\". Set value to 1");
            throw new ArgumentException("valueString", "The value must be a number");
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
