using FuyumiBot.Storage;
using Xunit;

namespace FuyumiBot.xUnit.Tests
{
    public class UnityTests
    {
        [Fact]
        public void SingletonHasOneInstanceTest()
        {
            var obj1 = Unity.Resolve<IDataStorage>();
            var obj2 = Unity.Resolve<IDataStorage>();

            Assert.Same(obj1, obj2);
            Assert.NotNull(obj1);
        }
    }
}
