using System.Collections.Generic;

namespace HorseRace14.Models
{
    /// <summary>
    /// Game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game id
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Game horses
        /// </summary>
        public List<Horse> Horses { get; set; }
    }
}
