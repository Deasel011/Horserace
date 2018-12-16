using System.Collections.Generic;

namespace HorseRace14.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
