namespace RaceDay.Models
{
    public class CustomerDetails
    {
        public CustomerDetails(Customer customer, int betsPlaced, decimal totalAmountPlace)
        {
            Customer = customer;
            BetsPlaced = betsPlaced;
            TotalAmountPlace = totalAmountPlace;
        }

        public Customer Customer { get; }
        public int BetsPlaced { get; }
        public decimal TotalAmountPlace { get; }
    }
}