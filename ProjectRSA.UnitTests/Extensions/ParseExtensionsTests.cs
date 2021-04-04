using ProjectRSA.Extensions;
using System;
using Xunit;

namespace ProjectRSA.UnitTests.Extensions
{
    public class ParseExtensionsTests
    {
        [Fact]
        public void TryParse_ShouldReturnValue_WhenItIsParseToLong()
        {
            var valueToParse = "1234567890";

            var actualNumber = ParseExtensions.TryParse(valueToParse);

            Assert.Equal(1234567890, actualNumber);
        }

        [Fact]
        public void TryParse_ShouldThrowException_WhenValueCannotBeParsed()
        {
            var valueToParse = "value";

            var result = Assert.Throws<ArgumentException>(() => ParseExtensions.TryParse(valueToParse));

            Assert.Contains("The value must be a number", result.Message);
        }
    }
}
