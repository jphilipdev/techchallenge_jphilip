using RaceDay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceDay.DomainServices.Interfaces
{
    public interface IRaceDomainService
    {
        Task<IEnumerable<RaceDetails>> GetRaceDetails();
    }
}