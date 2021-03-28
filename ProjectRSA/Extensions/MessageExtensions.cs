using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRSA.Extensions
{
    public class MessageExtensions
    {
       private const int SizeChunks = 3;

       public static List<long> ConvertToInt(string message)
       {
            var messageChunks = SeparateMessageChunks(message);
            Console.WriteLine($"Message chunks: {string.Join(',', messageChunks)}");

            var result = new List<long>();
            foreach (var chunk in messageChunks)
            {
                var hexadecimals = Encoding.Default.GetBytes(chunk);
                var hexadecimalString = BitConverter.ToString(hexadecimals);
                hexadecimalString = hexadecimalString.Replace("-", "");
                result.Add(int.Parse(hexadecimalString, System.Globalization.NumberStyles.HexNumber));
            }

            return result;
        }

        public static string ConvertToMessage(List<long> decipherNumbers)
        {
            var chunks = new List<string>();
            foreach(var cipher in decipherNumbers)
            {
                var hexadecimalString = cipher.ToString("X");
                var bytes = new byte[hexadecimalString.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(hexadecimalString.Substring(i * 2, 2), 16);
                }
                chunks.Add(Encoding.ASCII.GetString(bytes));
            }
            Console.WriteLine($"Message chunks: {string.Join(',', chunks)}");
            var message = string.Join(string.Empty, chunks);
            return message;
        }

        private static List<string> SeparateMessageChunks(string message)
        {
            var messageChunks = new List<string>();
            var index = 0;
            while (index + SizeChunks < message.Length)
            {
                messageChunks.Add(message.Substring(index, SizeChunks));
                index += SizeChunks;
            }
            messageChunks.Add(message[index..]);

            return messageChunks;
        }
    }
}
