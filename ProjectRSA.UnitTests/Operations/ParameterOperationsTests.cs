using ProjectRSA.Operations;
using Xunit;

namespace ProjectRSA.UnitTests.Operations
{
    public class ParameterOperationsTests
    {
        [Fact]
        public void CalculateN_ShouldCalculateN_GivenTwoPrimeNumbers()
        {
            var p = 11;
            var q = 7;

            var N = ParameterOperations.CalculateN(11, 7);

            Assert.Equal(77, N);
        }

        [Fact]
        public void CalculatePhiN_ShouldCalculatePhiN_GivenTwoPrimeNumbers()
        {
            var p = 11;
            var q = 7;

            var phiN = ParameterOperations.CalculatePhiN(p, q);

            Assert.Equal(60, phiN);
        }

        [Fact]
        public void CalculateE_ShouldGenerateRandomE()
        {
            var phiN = 60;

            var e = ParameterOperations.CalculateE(phiN);

            Assert.True(e < phiN);
            Assert.Equal(1, CalculateGcd(phiN, e));
        }

        [Fact]
        public void CalculateD_ShouldCalculateD_GivenEAndPhiN()
        {
            var phiN = 60;
            var e = 37;

            var d = ParameterOperations.CalculateD(phiN, e);

            Assert.Equal(13, d);
        }

        private int CalculateGcd(int bigNumber, int smallNumber)
        {
            var number1 = bigNumber;
            var number2 = smallNumber;

            while (number2 != 0)
            {
                var remainder = number1 % number2;
                number1 = number2;
                number2 = remainder;
            }
            return number1;
        }
    }
}
