using Discord;

namespace ReimuBot.Core.Entities
{
    public class BotActivity : IActivity
    {
        public string Name { get; set; }

        public ActivityType Type { get; set; }
    }
}
