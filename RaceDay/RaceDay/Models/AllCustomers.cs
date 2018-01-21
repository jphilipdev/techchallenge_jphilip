using System.Collections.Generic;
using System.Linq;

namespace RaceDay.Models
{
    public class AllCustomers
    {
        public AllCustomers(IEnumerable<CustomerDetails> customerDetails, decimal atRiskCustomerTotalAmountPlacedValue)
        {
            CustomerDetails = customerDetails;
            TotalBetsPlaced = customerDetails.Sum(customer => customer.BetsPlaced);
            AtRiskCustomers = customerDetails.Where(customer => customer.Bets.Any(bet => bet.Stake > atRiskCustomerTotalAmountPlacedValue)).ToList();
        }

        public IEnumerable<CustomerDetails> CustomerDetails { get; }
        public decimal TotalBetsPlaced { get; }
        public IEnumerable<CustomerDetails> AtRiskCustomers { get; }
    }
}