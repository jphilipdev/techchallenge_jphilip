using Microsoft.Extensions.Configuration;
using RaceDay.ApiProxies.Interfaces;
using RaceDay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceDay.ApiProxies
{
    public class BetsApiProxy : IBetsApiProxy
    {
        private readonly IApiAgent _apiAgent;
        private readonly string _apiUrl;

        public BetsApiProxy(IConfiguration configuration, IApiAgent apiAgent)
        {
            _apiAgent = apiAgent;
            _apiUrl = configuration.GetValue<string>("EndPoints:Bets");
        }

        public async Task<ICollection<Bet>> GetBets()
        {
            var bets = await _apiAgent.Get<ICollection<Bet>>(_apiUrl);
            return bets;
        }
    }
}