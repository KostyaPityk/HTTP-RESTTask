using Microsoft.EntityFrameworkCore;

namespace BoardGames.Models
{
    public class GameContext : DbContext
    {
        public DbSet<BoardGame> Games { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
