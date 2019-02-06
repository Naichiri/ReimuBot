using Xunit;

namespace FuyumiBot.xUnit.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void WhenGivenNullThenThrowsExceptionTest()
        {
            var logger = Unity.Resolve<ILogger>();

            Assert.NotNull(logger);
            Assert.Throws<System.ArgumentException>(() => logger.Log(null));
        }
        [Fact]
        public void LogTest()
        {
            var expected = "log";

            var logger = Unity.Resolve<ILogger>();

            logger.Log(expected);
        }
    }
}
