using System;

namespace ProjectRSA.Extensions
{
    /// <summary>
    /// Reference: https://gist.github.com/subena22jf/c7bb027ea99127944981
    /// Licensed under CC-attribution: Right to share, use, and build upon a work that they (the author) have created
    /// </summary>
    public static class RandomExtensions
    {
        public static long Next(long minValue, long maxValue)
        {
            var random = new Random();

            if (maxValue <= minValue)
                throw new ArgumentOutOfRangeException("maxValue", "minValue cannot be greated than MaxValue");

            ulong randomLong;
            do
            {
                byte[] buffer = new byte[sizeof(ulong)];
                random.NextBytes(buffer);
                randomLong = BitConverter.ToUInt64(buffer, 0);
            } while ((randomLong > ulong.MaxValue) && (randomLong < ulong.MinValue));

            return (long)(randomLong % (ulong)(maxValue - minValue)) + minValue;
        }
    }
}
