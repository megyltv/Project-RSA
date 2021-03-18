using ProjectRSA.Extensions;
using System.Collections.Generic;
using Xunit;

namespace ProjectRSA.UnitTests.Extensions
{
    public class MessageExtensionsTests
    {
        [Fact]
        public void ConvertToInt_ShouldConvertStringToChunkOfIntegers()
        {
            var message = "Hello World";

            var chunks = MessageExtensions.ConvertToInt(message);

            var expectedChunks = new List<int> { 4744556, 7106336, 5730162, 27748 };
            Assert.Equal(expectedChunks.Count, chunks.Count);
            for(var i=0; i<expectedChunks.Count; i++)
            {
                Assert.Equal(expectedChunks[i], chunks[i]);
            }
        }
    }
}