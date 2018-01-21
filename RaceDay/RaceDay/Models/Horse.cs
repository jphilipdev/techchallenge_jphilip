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

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Odds { get; set; }
    }
}