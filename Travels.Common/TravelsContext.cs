using Microsoft.EntityFrameworkCore;
using Travels.Common.DAL;

namespace Travels.Common {

    public class TravelsContext : DbContext {

        public TravelsContext(DbContextOptions<TravelsContext> options)
            : base(options) {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Visit> Visits { get; set; }
    }
}