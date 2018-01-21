using Microsoft.Extensions.Configuration;
using RaceDay.ApiProxies.Interfaces;
using RaceDay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceDay.ApiProxies
{
    public class CustomersApiProxy : ICustomersApiProxy
    {
        private readonly IApiAgent _apiAgent;
        private readonly string _apiUrl;

        public CustomersApiProxy(IConfiguration configuration, IApiAgent apiAgent)
        {
            _apiAgent = apiAgent;
            _apiUrl = configuration.GetValue<string>("EndPoints:Customers");
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _apiAgent.Get<IEnumerable<Customer>>(_apiUrl);
            return customers;
        }
    }
}