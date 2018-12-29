using dbotLH.Core;
using dbotLH.Core.Entities;
using dbotLH.Storage;
using System;
using System.Threading.Tasks;

namespace dbotLH
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
                Token = storage.RestoreObject<string>("Config/BotToken")
            });

            Console.ReadKey();
        }
    }
}
