using System.Threading.Tasks;

namespace RaceDay.ApiProxies.Interfaces
{
    public interface IApiAgent
    {
        Task<TResponse> Get<TResponse>(string url);

        TResponse Get<TRequest, TResponse>(TRequest request) where TResponse : new();
    }
}