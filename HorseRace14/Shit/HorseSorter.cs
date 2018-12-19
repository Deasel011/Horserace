using System.Collections.Generic;
using System.Linq;
using HorseRace14.Models;

namespace HorseRace14.Shit
{
    public static class HorseSorter
    {

        public static List<Horse> Sort(List<Horse> horses)
        {
            var sortedList = horses.OrderByDescending(h => h.Position.Steps).ThenBy(h => h.Position.TimeInMillis).Select(
                (r, i) => new Horse
                {
                    HorseId = r.HorseId,
                    Name = r.Name,
                    StartTimeInMillis = r.StartTimeInMillis,
                    EndTimeInMillis = r.EndTimeInMillis,
                    TotalTimeInMillis = r.TotalTimeInMillis,
                    Position = new Position
                    {
                        Finished = r.Position.Finished,
                        Steps = r.Position.Steps,
                        TimeInMillis = r.Position.TimeInMillis,
                        Rank = i + 1
                    }
                }).ToList();

            return sortedList;
        }
    }
}
