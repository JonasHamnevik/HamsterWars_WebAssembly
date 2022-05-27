using Core;
using HamsterWars.Shared.Models;
using Services.DTOs;

namespace Services;

public class HamsterService
{
    private readonly HamsterWarsDbContext _context;

    public HamsterService(HamsterWarsDbContext context)
    {
        _context = context;
    }

    public bool Exists(int id)
    {
        return _context.Hamsters.Any(h => h.Id == id);
    }

    public static HamsterDTO HamsterMatch (Hamster hamster)
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
}
