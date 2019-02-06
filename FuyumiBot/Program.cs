using System.Threading.Tasks;

namespace FuyumiBot
{
    internal class Program
    {
        private static async Task Main()
        {
            Fuyumi bot = Unity.Resolve<Fuyumi>();
            
            await bot.Start();
            await Task.Delay(-1).ConfigureAwait(false);
        }
    }
}
