using Discord;

namespace dbotLH.Core.Entities
{
    public class BotActivity : IActivity
    {
        private string _name;
        private ActivityType _type;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ActivityType Type 
        {
            get => _type;
            set => _type = value;
        }
    }
}
