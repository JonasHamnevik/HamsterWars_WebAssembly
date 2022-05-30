
using HamsterWars.Shared.DTOs;

namespace HamsterWars.Shared.Models
{
    public class Game
    {
        public Hamster First { get; set; }
        public Hamster Second { get; set; }

        public Game(Hamster first, Hamster second)
        {
            First = first;
            Second = second;
        }
    }
}
