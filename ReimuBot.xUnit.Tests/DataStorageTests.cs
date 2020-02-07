using System.IO;
using ReimuBot.Storage;
using ReimuBot.Storage.Implementations;
using Xunit;

namespace ReimuBot.xUnit.Tests
{
    public class DataStorageTests
    {
        [Fact]
        public void JsonStorageTest()
        {
            const string expected = "abc";
            const string expectedKey = "./temp/TEST-KEY";
            
            IDataStorage storage = new JsonStorage();
            
            storage.StoreObject("xyz", expectedKey);
            storage.StoreObject(expected, expectedKey);

            var actual = storage.RestoreObject<string>(expectedKey);

            Assert.Equal(expected, actual);
            Assert.Throws<FileNotFoundException>(() => storage.RestoreObject<string>("./temp/WRONG-KEY"));

            Directory.Delete("./temp", true);
        }
    }
}
