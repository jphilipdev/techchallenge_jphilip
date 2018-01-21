namespace RaceDay.Models
{
    public class Bet
    {
        public Bet(int customerId, int raceId, int horseId, decimal stake)
        {
            CustomerId = customerId;
            RaceId = raceId;
            HorseId = horseId;
            Stake = stake;
        }

        public int CustomerId { get; }
        public int RaceId { get; }
        public int HorseId{ get; }
        public decimal Stake { get; }
    }
}