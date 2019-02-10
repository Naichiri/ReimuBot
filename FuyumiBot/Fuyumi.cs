using System.Threading.Tasks;
using FuyumiBot.Core;
using FuyumiBot.Core.Entities;
using FuyumiBot.Core.Handlers;
using FuyumiBot.Storage;

namespace FuyumiBot
{
    public class Fuyumi
    {
        private readonly IDataStorage _storage;
        private readonly BotConfig _config;
        private readonly Connection _connection;
        private readonly ICommandHandler _commandHandler;

        public Fuyumi(IDataStorage storage, Connection connection, ICommandHandler commandHandler)
        {
            _storage = storage;
            _config = _storage.RestoreObject<BotConfig>("Config/BotConfig");
            _connection = connection;
            _commandHandler = commandHandler;
        }
        public async Task Start()
        {
            await _connection.ConnectAsync(_config);
            await _commandHandler.SetPrefixAsync(_config.DefaultPrefix);
            await _commandHandler.InitialiseAsync();
        }
    }
}
