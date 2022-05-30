
using HamsterWars.Shared.DTOs;

namespace HamsterWars.Shared.Models
{
    public class Game
    {
        public Hamster First { get; set; }
        public Hamster Second { get; set; }

        public Game(int first, int second)
        {
            First.Id = first;
            Second.Id = second;
        }
    }
}
