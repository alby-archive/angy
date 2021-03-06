using System.Threading.Tasks;
using Angy.Client.Shared.Adapters;
using Angy.Model;

namespace Angy.Client.Shared.Abstract
{
    public interface IClientAdapter
    {
        Task<Result<TCast, Error.ExceptionalError>> SendQueryAsync<TResponse, TCast>(RequestAdapter<TResponse, TCast> adapter);
    }
}