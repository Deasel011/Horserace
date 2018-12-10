using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceApi.Models
{
    public class Horse: IComparable
    {
        public string Name { get; set; }
        public HorseColor Color { get; set; }
        public int CompareTo(object obj)
        {
            Horse other = (Horse) obj;
            return Name.Equals(other.Name) && (Color.Equals(other.Color))?0:-1;
        }
    }

    public enum HorseColor
    {
        Brown=1,
        White=2,
        Palomino=3,
        Black=4,
        Gold=5,
        Rainbow=69
    }
}
