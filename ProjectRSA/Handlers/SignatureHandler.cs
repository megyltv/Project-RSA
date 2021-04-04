using ProjectRSA.Model;
using System;
using System.Linq;

namespace ProjectRSA.Handlers
{
    public class SignatureHandler
    {
        public void CalculateSignature()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowSignatureMenu();
            }
        }

        private void SignMessage()
        {
            Console.WriteLine("\n----- Sign Message -----\n");
            var rsa = new Rsa
            {
                N = TryParse(ReadLineFromConsole("N")),
                D = TryParse(ReadLineFromConsole("d"))
            };

            Console.Write("Enter message to sign: ");
            var message = Console.ReadLine();
            rsa.SignMessage(message);
        }

        private void VerifySignature()
        {
            Console.WriteLine("\n----- Verify Signature -----\n");
            var rsa = new Rsa
            {
                N = TryParse(ReadLineFromConsole("N")),
                E = TryParse(ReadLineFromConsole("e"))
            };
            Console.Write("Enter signature: ");
            var cipher = Console.ReadLine();
            Console.Write("Enter message to verify: ");
            var message = Console.ReadLine();
            var ciphers = cipher.Split(',').ToList();
            var cipherNumbers = ciphers.Select(cipher => TryParse(cipher.Trim()));
            rsa.VerifyMessage(cipherNumbers, message);
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
            if (success)
                return value;
            Console.WriteLine($"Invalid value provided: \"{valueString}\". Set value to 1");
            throw new ArgumentException("valueString", "The value must be a number");
        }

        private bool ShowSignatureMenu()
        {
            Console.WriteLine("\n----- Signature -----\n");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Sign message");
            Console.WriteLine("2. Verify signature");
            Console.WriteLine("3. Exit");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    SignMessage();
                    return true;
                case "2":
                    VerifySignature();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
