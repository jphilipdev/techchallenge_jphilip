using Microsoft.Extensions.Configuration;
using RaceDay.ApiProxies.Interfaces;
using RaceDay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceDay.ApiProxies
{
    public class RacesApiProxy : IRacesApiProxy
    {
        private readonly IApiAgent _apiAgent;
        private readonly string _apiUrl;

        public RacesApiProxy(IConfiguration configuration, IApiAgent apiAgent)
        {
            _apiAgent = apiAgent;
            _apiUrl = configuration.GetValue<string>("EndPoints:Races");
        }

        public async Task<ICollection<Race>> GetRaces()
        {
            var races = await _apiAgent.Get<ICollection<Race>>(_apiUrl);
            return races;
        }
    }
}