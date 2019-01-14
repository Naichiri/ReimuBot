using FuyumiBot.Core;
using FuyumiBot.Core.Entities;
using FuyumiBot.Storage;
using System;
using System.Threading.Tasks;

namespace FuyumiBot
{
    internal class Program
    {
        private static async Task Main()
        {
            Unity.RegisterTypes();

            var storage = Unity.Resolve<IDataStorage>();

            Connection connection = Unity.Resolve<Connection>();
            await connection.ConnectAsync(new BotConfig
            {
                Token = storage.RestoreObject<string>("Config/BotToken"),
                Activity = storage.RestoreObject<BotActivity>("Config/BotActivity"),
                Prefix = storage.RestoreObject<string>("Config/BotPrefix")
            });
        }
    }
}
