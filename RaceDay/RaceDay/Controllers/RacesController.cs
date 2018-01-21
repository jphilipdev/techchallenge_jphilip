using Microsoft.AspNetCore.Mvc;
using RaceDay.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace RaceDay.Controllers
{
    [Route("api/[controller]")]
    public class RacesController : Controller
    {
        private readonly IRacesDomainService _racesDomainService;

        public RacesController(IRacesDomainService racesDomainService)
        {
            _racesDomainService = racesDomainService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var races = await _racesDomainService.GetRaceDetails();
            return Ok(races);
        }
    }
}