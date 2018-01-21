using System;
using System.Collections.Generic;

namespace RaceDay.Models
{
    public class Race
    {
        public Race(int id, string name, DateTime start, string status, ICollection<Horse> horses)
        {
            Id = id;
            Name = name;
            Start = start;
            Status = status;
            Horses = horses;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Status { get; set; }
        public ICollection<Horse> Horses { get; set; }
    }
}