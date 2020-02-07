using System.Threading.Tasks;
using ReimuBot.Core;
using ReimuBot.Core.Entities;
using ReimuBot.Core.Handlers;
using ReimuBot.Storage;

namespace ReimuBot
{
    public class Reimu
    {
        private readonly IDataStorage _storage;
        private readonly BotConfig _config;
        private readonly Connection _connection;
        private readonly ICommandHandler _commandHandler;

        public Reimu(IDataStorage storage, Connection connection, ICommandHandler commandHandler)
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
