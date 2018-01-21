using RaceDay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceDay.ApiProxies.Interfaces
{
    public interface IBetsApiProxy
    {
        Task<IEnumerable<Bet>> GetBets();
    }
}