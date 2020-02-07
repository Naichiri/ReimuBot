using System.Threading.Tasks;
using Discord.Net;
using ReimuBot.Core;
using ReimuBot.Core.Entities;
using Xunit;

namespace ReimuBot.xUnit.Tests
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
