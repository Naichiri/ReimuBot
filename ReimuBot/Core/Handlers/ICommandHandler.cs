using System.Threading.Tasks;

namespace ReimuBot.Core.Handlers
{
    public interface ICommandHandler
    {
        Task SetPrefixAsync(string prefix);
        Task InitialiseAsync();
    }
}
