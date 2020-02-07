using System.Threading.Tasks;

namespace ReimuBot
{
    internal class Program
    {
        private static async Task Main()
        {
            Reimu bot = Unity.Resolve<Reimu>();
            
            await bot.Start();
            await Task.Delay(-1).ConfigureAwait(false);
        }
    }
}
