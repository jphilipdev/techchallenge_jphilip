using Microsoft.AspNetCore.Mvc;
using RaceDay.DomainServices.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RaceDay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRaceDomainService _racesDomainService;

        public HomeController(IRaceDomainService racesDomainService)
        {
            _racesDomainService = racesDomainService;
        }

        public async Task<IActionResult> Index()
        {
            var races = await _racesDomainService.GetRaceDetails();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}