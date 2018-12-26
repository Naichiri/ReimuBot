using dbotLH.Core;
using dbotLH.Core.Entities;

namespace dbotLH
{
    internal class Program
    {
        private static void Main()
        {
            Unity.RegisterTypes();

            BotConfig discordBotConfig = new BotConfig
            {
                Token = "TOKEN",
                SocketConfig = SocketConfig.GetDefault()
            };

            Connection connection = Unity.Resolve<Connection>();
        }
    }
}
