using System.Threading.Tasks;
using ReimuBot.Core.Properties;
using Discord;
using Discord.Commands;

namespace ReimuBot.Core.Modules.Utilities
{
    public class InfoCommands : ModuleBase
    {

        [Command("botinfo"), Summary("Displays basic information about Reimu.")]
        [Alias("about")]
        public async Task BotInfo() => await ReplyAsync("", false, BotEmbed);

        [Command("serverinfo"), Summary("Displays basic information about the server command was called in.")]
        public async Task ServerInfo() => await ReplyAsync("", false, ServerEmbed);

        [Command("userinfo"), Summary("Displays basic information about the chosen user, defaults to message sender.")]
        [Alias("whois")]
        public async Task UserInfo(IGuildUser u = null) => await ReplyAsync("", false, GetUserEmbed(u ?? (IGuildUser)Context.User));

        [Command("invite"), Summary("Sends the bot OAuth invite link. Invite Reimu to your server!")]
        [Alias("botinvite", "invitelink")]
        public async Task Invite() => await ReplyAsync(ReimuInfo.OAuthURL);

        [Command("github"), Summary("Sends the github link.")]
        [Alias("repo", "repository")]
        public async Task GitHub() => await ReplyAsync(ReimuInfo.GitHubURL);

        private Embed BotEmbed
        {
            get
            {
                var botEmbed = new EmbedBuilder();

                botEmbed.WithColor(Color.Red);
                botEmbed.WithTitle($"{ReimuInfo.Name} | {ReimuInfo.KanjiName}");
                botEmbed.WithDescription("A miko bot doing nothing at the moment save being cute");
                botEmbed.WithThumbnailUrl(Context.Client.CurrentUser.GetAvatarUrl());
                botEmbed.AddField("Version", ReimuInfo.Version, true);
                botEmbed.AddField("Birthdate", Context.Client.CurrentUser.CreatedAt.DateTime.ToShortDateString(), true);
                botEmbed.AddField("Servers", Context.Client.GetGuildsAsync().Result.Count, true);
                botEmbed.AddField("Developer", ReimuInfo.Developer, true);
                botEmbed.AddField("Main server", ReimuInfo.MainServerInviteURL);

                return botEmbed.Build();
            }
        }

        private Embed ServerEmbed
        {
            get
            {
                var serverEmbed = new EmbedBuilder();

                serverEmbed.WithColor(Color.DarkBlue);
                serverEmbed.WithTitle(Context.Guild.Name);
                serverEmbed.WithDescription("Server information");
                serverEmbed.WithThumbnailUrl(Context.Guild.IconUrl);
                serverEmbed.AddField("Region", Context.Guild.VoiceRegionId, true);
                serverEmbed.AddField("Creation date", Context.Guild.CreatedAt.DateTime.GetDateTimeFormats('g')[0], true);
                serverEmbed.AddField("Members", Context.Guild.GetUsersAsync().Result.Count, true);
                serverEmbed.AddField("Owner", Context.Guild.GetUserAsync(Context.Guild.OwnerId).Result.ToString(), true);

                return serverEmbed.Build();
            }
        }

        private Embed GetUserEmbed(IGuildUser u)
        {
            var userEmbed = new EmbedBuilder();

            userEmbed.WithColor(Color.DarkGreen);
            userEmbed.WithTitle(u.ToString());
            userEmbed.WithDescription(u.IsBot ? "Discord Bot" : "Discord User");
            userEmbed.WithThumbnailUrl(u.GetAvatarUrl());
            userEmbed.AddField("ID", u.Id, true);
            userEmbed.AddField("Account creation date", u.CreatedAt.DateTime.GetDateTimeFormats('g')[0], true);
            userEmbed.AddField("Server join date", u.JoinedAt.Value.DateTime.GetDateTimeFormats('g')[0], true);
            userEmbed.AddField("Account age", $"{(System.DateTime.Now - u.CreatedAt.DateTime).Days} days", true);
            userEmbed.AddField("Status", u.Status, true);

            return userEmbed.Build();
        }
    }
}
