using dbotLH.Core.Entities;
using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace dbotLH.Core
{
    public class Connection
    {
        private DiscordSocketClient _client;

        private DiscordLogger _logger;

        public Connection(DiscordLogger logger)
        {
            _logger = logger;
        }

        internal async Task ConnectAsync(BotConfig config)
        {
            _client = new DiscordSocketClient(config.SocketConfig);

            _client.Log += _logger.Log;
        }
    }
}
