using Microsoft.EntityFrameworkCore;
using RiddleMe.Models.Domain;

namespace RiddleMe.Data
{
    public class RiddlemeDbContext : DbContext
    {
        public RiddlemeDbContext(DbContextOptions<RiddlemeDbContext> options) : base(options)
        {
        }

        public DbSet<Riddle> Riddles { get; set; }
    }
}
