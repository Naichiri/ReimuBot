using System.Threading.Tasks;

namespace FuyumiBot.Core.Handlers
{
    public interface ICommandHandler
    {
        Task SetPrefixAsync(string prefix);
        Task InitialiseAsync();
    }
}
