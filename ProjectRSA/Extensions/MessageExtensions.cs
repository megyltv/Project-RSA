using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectRSA.Extensions
{
    public class MessageExtensions
    {
       private const int SizeChunks = 3;

       public static List<int> ConvertToInt(string message)
       {
            var messageChunks = SeparateMessageChunks(message);

            var result = new List<int>();
            foreach (var chunk in messageChunks)
            {
                var hexadecimals = Encoding.Default.GetBytes(chunk);
                var hexadecimalString = BitConverter.ToString(hexadecimals);
                hexadecimalString = hexadecimalString.Replace("-", "");
                result.Add(int.Parse(hexadecimalString, System.Globalization.NumberStyles.HexNumber));
            }

            return result;
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
