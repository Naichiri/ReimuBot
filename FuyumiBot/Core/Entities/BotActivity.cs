using Discord;

namespace FuyumiBot.Core.Entities
{
    public class BotActivity : IActivity
    {
        public string Name { get; set; }

        public ActivityType Type { get; set; }
    }
}
