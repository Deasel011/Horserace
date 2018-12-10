using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceApi.Models
{
    public class Race
    {
        public List<Horse> horses { get; set; }
        private long RaceId { get; set; }
        public RaceResults results { get; set; }
    }
}