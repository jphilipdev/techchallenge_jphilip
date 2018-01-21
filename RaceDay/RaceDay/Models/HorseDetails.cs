namespace RaceDay.Models
{
    public class HorseDetails
    {
        public HorseDetails(Horse horse, int numberOfBets, decimal totalPotentialPayout)
        {
            Horse = horse;
            NumberOfBets = numberOfBets;
            TotalPotentialPayout = totalPotentialPayout;
        }

        public Horse Horse { get; }
        public int NumberOfBets { get; }
        public decimal TotalPotentialPayout { get; }
    }
}