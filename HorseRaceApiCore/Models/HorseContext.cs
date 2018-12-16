using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HorseRaceApiCore.Models
{
    public class HorseContext : DbContext
    {
        public HorseContext(DbContextOptions<HorseContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Horse> Horses { get; set; }
    }

    public class Game
    {
        public Game()
        {
            Horses = new List<Horse>();
        }

        public int GameId { get; set; }

        public List<Horse> Horses {get; set; }
    }

    public class Horse
    {
        public int HorseId { get; set; }
        public string Name { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
