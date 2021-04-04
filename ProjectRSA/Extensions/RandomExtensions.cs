using System;

namespace ProjectRSA.Extensions
{
    /// <summary>
    /// Reference: https://gist.github.com/subena22jf/c7bb027ea99127944981
    /// </summary>
    public static class RandomExtensions
    {
        public static long Next(long minValue, long maxValue)
        {
            var random = new Random();

            if (maxValue <= minValue)
                throw new ArgumentOutOfRangeException("maxValue", "minValue cannot be greated than MaxValue");

            ulong range = (ulong)(maxValue - minValue);

            ulong randomLong;
            do
            {
                byte[] buffer = new byte[8];
                random.NextBytes(buffer);
                randomLong = (ulong)BitConverter.ToInt64(buffer, 0);
            } while (randomLong > ulong.MaxValue - ((ulong.MaxValue % range) + 1) % range);

            return (long)(randomLong % range) + minValue;
        }
    }
}
