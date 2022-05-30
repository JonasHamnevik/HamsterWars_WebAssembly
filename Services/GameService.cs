using Core;
using HamsterWars.Shared.DTOs;
using HamsterWars.Shared.Models;

namespace Services;

public class GameService
{
    private readonly HamsterWarsDbContext _context;

    public GameService(HamsterWarsDbContext context)
    {
        _context = context;
    }

    public static HamsterDTO HamsterToDTO(Hamster hamster)
    {
        return new HamsterDTO()
        {
            Id = hamster.Id,
            Name = hamster.Name,
            Age = hamster.Age,
            FavouriteFood = hamster.FavouriteFood,
            Loves = hamster.Loves,
            ImageName = hamster.ImageName
        };
    }

    public IEnumerable<HamsterDTO> CreateHamsterDTOs()
    {
        return _context.Hamsters
            .Select(h => HamsterToDTO(h))
            .ToList();
    }

    public int GetHamster()
    {
        List<int> hamsterId = _context.Hamsters.Select(h => h.Id).ToList();
        Random random = new Random();

        var hamster = random.Next(0, hamsterId.Count);
        return hamster;
    }
    public Game CreateGame()
    {
        var firstId = GetHamster();
        var secondId = GetHamster();

        if (secondId == firstId)
            secondId = GetHamster();

        Hamster first;
        Hamster second;

        var game = new Game(firstId, secondId);
        return game;
    }
}
