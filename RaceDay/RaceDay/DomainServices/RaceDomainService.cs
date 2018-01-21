using RaceDay.ApiProxies.Interfaces;
using RaceDay.DomainServices.Interfaces;
using RaceDay.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDay.DomainServices
{
    public class RaceDomainService : IRaceDomainService
    {
        private readonly IRacesApiProxy _racesApiProxy;
        private readonly IBetsApiProxy _betsApiProxy;

        public RaceDomainService(IRacesApiProxy racesApiProxy, IBetsApiProxy betsApiProxy)
        {
            _racesApiProxy = racesApiProxy;
            _betsApiProxy = betsApiProxy;
        }

        public async Task<IEnumerable<RaceDetails>> GetRaceDetails()
        {
            var races = _racesApiProxy.GetRaces();
            var bets = _betsApiProxy.GetBets();

            await Task.WhenAll(races, bets);

            var raceDetailsList = (from race in races.Result
                                   join bet in bets.Result on race.Id equals bet.RaceId
                                   group new { race, bet } by race into raceDetails
                                   select new RaceDetails()
                                   {
                                       Race = raceDetails.Key,
                                       Status = raceDetails.Key.Status,
                                       TotalPlaced = raceDetails.Sum(race => race.bet.Stake),
                                       Horses = raceDetails.Key.Horses.Select(horse => new HorseDetails(
                                           horse: horse,
                                           numberOfBets: raceDetails.Where(p => p.bet.HorseId == horse.Id).Count(),
                                           totalPotentialPayout: raceDetails.Where(p => p.bet.HorseId == horse.Id).Sum(p => p.bet.Stake) * horse.Odds)
                                      ).ToList()
                                   }).ToList();

            return raceDetailsList;
        }
    }
}