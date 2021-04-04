using System;

namespace ProjectRSA.Extensions
{
    public static class ParseExtensions
    {
        public static long TryParse(string valueString)
        {
            var success = long.TryParse(valueString, out long value);
            if (success)
                return value;
            Console.WriteLine($"Invalid value provided: \"{valueString}\". Set value to 1");
            throw new ArgumentException("The value must be a number", "valueString");
        }
    }
}
