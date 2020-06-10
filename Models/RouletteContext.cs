using Microsoft.EntityFrameworkCore;

namespace RouletteApi.Models
{
    public class RouletteContext : DbContext
    {
        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {
        }

        public DbSet<Roulette> Roulettes { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}