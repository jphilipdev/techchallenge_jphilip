using System;
using System.Collections.Generic;

namespace RaceDay.Models
{
    public class Race
    {
        public Race(int id, string name, DateTime start, string status, IEnumerable<Horse> horses)
        {
            Id = id;
            Name = name;
            Start = start;
            Status = status;
            Horses = horses;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime Start { get; }
        public string Status { get; }
        public IEnumerable<Horse> Horses { get; }
    }
}