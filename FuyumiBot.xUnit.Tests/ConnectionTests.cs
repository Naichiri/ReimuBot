using System.Threading.Tasks;
using Discord.Net;
using FuyumiBot.Core;
using FuyumiBot.Core.Entities;
using Xunit;

namespace FuyumiBot.xUnit.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public void ConnectWithBadTokenTest()
        {
            Assert.ThrowsAsync<HttpException>(AttemptConnectionWithBadToken);
        }

        private async Task AttemptConnectionWithBadToken()
        {
            var con = Unity.Resolve<Connection>();

            await con.ConnectAsync(new BotConfig{ Token = "BAD-TOKEN" });
        }
    }
}
