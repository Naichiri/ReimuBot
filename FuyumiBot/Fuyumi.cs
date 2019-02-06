using System.Threading.Tasks;
using FuyumiBot.Core;
using FuyumiBot.Core.Entities;
using FuyumiBot.Storage;

namespace FuyumiBot
{
    public class Fuyumi
    {
        private readonly IDataStorage _storage;
        private readonly Connection _connection;
        
        public Fuyumi(IDataStorage storage, Connection connection)
        {
            _storage = storage;
            _connection = connection;
        }
        public async Task Start()
        {
            await _connection.ConnectAsync(new BotConfig
            {
                Token = _storage.RestoreObject<string>("Config/BotToken"),
                Activity = _storage.RestoreObject<BotActivity>("Config/BotActivity"),
                Prefix = _storage.RestoreObject<string>("Config/BotPrefix")
            });
        }
    }
}