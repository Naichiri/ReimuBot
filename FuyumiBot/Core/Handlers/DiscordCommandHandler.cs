using System;
using System.Reflection;
using System.Threading.Tasks;
using FuyumiBot.Core.Entities;
using Discord.Commands;
using Discord.WebSocket;

namespace FuyumiBot.Core.Handlers
{
    public class DiscordCommandHandler : ICommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private string _prefix;

        public DiscordCommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _client = client;
            _commands = commands;
        }

        public async Task SetPrefixAsync(string prefix)
        {
            _prefix = prefix;
            await Task.CompletedTask;
        }

        public async Task InitialiseAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            // if not a user-sent message
            if (!(s is SocketUserMessage message)) return;

            int argPos = 0;
            // if not a command; also argPos defines where does the prefix end
            if (!(message.HasStringPrefix(_prefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;

            var context = new SocketCommandContext(_client, message);

            var result = await _commands.ExecuteAsync(context, argPos);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }
    }
}
