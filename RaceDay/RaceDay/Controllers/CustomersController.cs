using Microsoft.AspNetCore.Mvc;
using RaceDay.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace RaceDay.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersDomainService _customersDomainService;

        public CustomersController(ICustomersDomainService customersDomainService)
        {
            _customersDomainService = customersDomainService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customersDomainService.GetCustomerDetails();
            return Ok(customers);
        }
    }
}