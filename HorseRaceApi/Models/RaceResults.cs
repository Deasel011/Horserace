using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace HorseRaceApi.Models
{
    public class RaceResults
    {
        public long RaceId { get; set; }
        public Dictionary<Horse, TimeSpan> times { get; set; }

        public OrderedDictionary GetResults()
        {
            return new OrderedDictionary();
        }
    }
}