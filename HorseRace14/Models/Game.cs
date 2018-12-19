using System.Collections.Generic;
using System.Linq;

namespace HorseRace14.Models
{
    public class Game
    {
        /// <summary>
        /// Game id
        /// </summary>
        public int GameId { get; set; }


        private List<Horse> _horses;

        /// <summary>
        /// Game horses
        /// </summary>
        public List<Horse> Horses
        {
            get => _horses.OrderByDescending(h => h.Position.Steps).ThenBy(h => h.Position.TimeInMillis).Select(
                (r, i) => new Horse
                {
                    HorseId = r.HorseId,
                    Name = r.Name,
                    Position = new Position
                    {
                        Finished = r.Position.Finished,
                        Steps = r.Position.Steps,
                        TimeInMillis = r.Position.TimeInMillis,
                        Rank = i + 1
                    }
                }).ToList();
            set => _horses = value;
        }
    }
}
