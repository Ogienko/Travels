using Microsoft.EntityFrameworkCore;
using Travels.Common.DAL;

namespace Travels.Common
{
    public class TravelsContext : DbContext {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=travels;Username=postgres;Password=qYoE2hw3HyMBFEbs");
        }
    }
}