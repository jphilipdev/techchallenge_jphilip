using System.Collections.Generic;

namespace RaceDay.Models
{
    public class RaceDetails
    {
        public Race Race { get; set; }
        public string Status { get; set; }
        public decimal TotalPlaced { get; set; }
        public ICollection<HorseDetails> Horses { get; set; }
    }
}