using ProjectRSA.Operations;
using Xunit;

namespace ProjectRSA.UnitTests.Operations
{
    public class NumberTheoryOperationsTests
    {
        [Theory]
        [InlineData(11316, 1221, 3)]
        [InlineData(621, 345, 69)]
        public void GetGcd_ShouldReturnGcdGivenTwoNumbers(int bigNumber, int smallNumber, int expectedGcd)
        {
            var gcd = NumberTheoryOperations.CalculateGcd(bigNumber, smallNumber);

            Assert.Equal(expectedGcd, gcd);
        }

        [Theory]
        [InlineData(167, 32)]
        [InlineData(67, 23)]
        public void GetGcd_ShouldReturnOne_WhenNumberDoesntHaveGcd(int bigNumber, int smallNumber)
        {
            var gcd = NumberTheoryOperations.CalculateGcd(bigNumber, smallNumber);

            Assert.Equal(1, gcd);
        }

        [Theory]
        [InlineData(60, 37, 13)]
        [InlineData(504, 5, 101)]
        [InlineData(13, 12, 12)]
        public void CalculateD_ShouldCalculateD_GivenEAndPhiN(int phiN, int e, int expectedInverse)
        {
            var d = NumberTheoryOperations.CalculateMultiplicativeInverse(phiN, e);

            Assert.Equal(expectedInverse, d);
        }

        [Theory]
        [InlineData(7, 6, 11, 4)]
        [InlineData(15, 37, 77, 71)]
        [InlineData(159, 101, 551, 11)]
        [InlineData(7106336, 15935561, 1169623627, 169484800)]
        public void CalculateSquareAndMultiply_ShouldGetModularExponentialNumber(long @base, long exponent, long mod, long expectedResult)
        {
            var result = NumberTheoryOperations.CalculateSquareAndMultiply(exponent, @base, mod);

            Assert.Equal(expectedResult, result);
        }
    }
}
