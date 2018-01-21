using System.Collections.Generic;

namespace RaceDay.Models
{
    public class CustomerDetails
    {
        public CustomerDetails(Customer customer, IEnumerable<Bet> bets, int betsPlaced, decimal totalAmountPlaced)
        {
            Customer = customer;
            Bets = bets;
            BetsPlaced = betsPlaced;
            TotalAmountPlaced = totalAmountPlaced;
        }

        public Customer Customer { get; }
        public IEnumerable<Bet> Bets { get; }
        public int BetsPlaced { get; }
        public decimal TotalAmountPlaced { get; }
    }
}