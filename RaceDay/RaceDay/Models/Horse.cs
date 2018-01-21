namespace RaceDay.Models
{
    public class Horse
    {
        public Horse(int id, string name, decimal odds)
        {
            Id = id;
            Name = name;
            Odds = odds;
        }

        public int Id { get; }
        public string Name { get; }
        public decimal Odds { get; }
    }
}