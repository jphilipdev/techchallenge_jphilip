using Microsoft.AspNetCore.Mvc;
using RaceDay.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace RaceDay.Controllers
{
    [Route("api/[controller]")]
    public class RaceController : Controller
    {
        private readonly IRaceDomainService _raceDomainService;

        public RaceController(IRaceDomainService raceDomainService)
        {
            _raceDomainService = raceDomainService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var races = await _raceDomainService.GetRaceDetails();
            return Ok(races);
        }
    }
}