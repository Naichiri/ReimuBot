using Discord;
using ReimuBot.Core;
using Xunit;

namespace ReimuBot.xUnit.Tests
{
    public class SocketConfigTests
    {
        [Fact]
        public void DefaultConfigTest()
        {
            const LogSeverity expected = LogSeverity.Verbose;
            
            var actual = SocketConfig.GetDefault().LogLevel;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NewConfigTest()
        {
            var actual = SocketConfig.GetNew();

            Assert.NotNull(actual);
        }
    }
}
