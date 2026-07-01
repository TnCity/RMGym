using Microsoft.EntityFrameworkCore;
using RMGym.Models;
namespace RMGym.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }

    }
}
