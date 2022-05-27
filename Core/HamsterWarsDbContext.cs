using HamsterWars.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class HamsterWarsDbContext : DbContext
{
    public HamsterWarsDbContext(DbContextOptions<HamsterWarsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Hamster> Hamsters => Set<Hamster>();

}
