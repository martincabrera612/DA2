using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess

{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

    }
}
