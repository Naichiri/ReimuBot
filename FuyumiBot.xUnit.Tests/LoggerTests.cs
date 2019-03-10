using Xunit;

namespace FuyumiBot.xUnit.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void LogTest()
        {
            var expected = "log";

            var logger = Unity.Resolve<ILogger>();

            logger.Log(expected);
        }
    }
}
