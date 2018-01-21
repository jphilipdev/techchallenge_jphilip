using Microsoft.Extensions.Configuration;
using RaceDay.ApiProxies.Interfaces;
using RaceDay.DomainServices.Interfaces;
using RaceDay.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDay.DomainServices
{
    public class CustomersDomainService : ICustomersDomainService
    {
        private readonly ICustomersApiProxy _customersApiProxy;
        private readonly IBetsApiProxy _betsApiProxy;
        private readonly decimal _atRiskCustomerTotalAmountPlacedValue;

        public CustomersDomainService(ICustomersApiProxy customersApiProxy, IBetsApiProxy betsApiProxy, IConfiguration configuration)
        {
            _customersApiProxy = customersApiProxy;
            _betsApiProxy = betsApiProxy;
            _atRiskCustomerTotalAmountPlacedValue = configuration.GetValue<decimal>("AtRiskCustomerTotalAmountPlacedValue");
        }

        public async Task<AllCustomers> GetCustomerDetails()
        {
            var customers = _customersApiProxy.GetCustomers();
            var bets = _betsApiProxy.GetBets();

            await Task.WhenAll(customers, bets);

            var customerDetailsList = (from customer in customers.Result
                                       join bet in bets.Result on customer.Id equals bet.CustomerId
                                       group new { customer, bet } by customer into customerDetails
                                       select new CustomerDetails(
                                           customer: customerDetails.Key,
                                           bets: customerDetails.Select(p => p.bet).ToList(),
                                           betsPlaced: customerDetails.Count(),
                                           totalAmountPlaced: customerDetails.Sum(p => p.bet.Stake)
                                       )).ToList();

            var allCustomers = new AllCustomers(customerDetailsList, _atRiskCustomerTotalAmountPlacedValue);
            return allCustomers;
        }
    }
}
