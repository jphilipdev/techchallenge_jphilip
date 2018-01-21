using System.Collections.Generic;
using System.Linq;

namespace RaceDay.Models
{
    public class AllCustomers
    {
        public AllCustomers(ICollection<CustomerDetails> customerDetails, decimal atRiskCustomerTotalAmountPlacedValue)
        {
            CustomerDetails = customerDetails;

            TotalBetsPlaced = customerDetails.Sum(p => p.BetsPlaced);

            AtRiskCustomers = customerDetails.Where(p => p.BetsPlaced > atRiskCustomerTotalAmountPlacedValue).ToList();
        }

        public ICollection<CustomerDetails> CustomerDetails { get; }

        public decimal TotalBetsPlaced { get; }

        public ICollection<CustomerDetails> AtRiskCustomers { get; }
    }
}