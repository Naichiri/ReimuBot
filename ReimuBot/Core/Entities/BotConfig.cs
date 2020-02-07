namespace ReimuBot.Core.Entities
{
    public class BotConfig
    {
        public string Token { get; set; }

        public BotActivity Activity { get; set; }

        public string DefaultPrefix { get; set; }
    }
}
