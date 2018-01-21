using Microsoft.AspNetCore.Mvc;
using RaceDay.DomainServices.Interfaces;
using System.Threading.Tasks;

namespace RaceDay.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerDomainService _customerDomainService;

        public CustomerController(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerDomainService.GetCustomerDetails();
            return Ok(customers);
        }
    }
}