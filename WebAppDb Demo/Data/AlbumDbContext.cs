using Microsoft.EntityFrameworkCore;
using WebAppDb_Demo.Models;

namespace WebAppDb_Demo.Data
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext(DbContextOptions<AlbumDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
        @"Server = (localdb)\MSSQLLocalDB; " +
        "Database = AlbumDb; " +
        "Trusted_Connection = True;");
        }
        public DbSet<Album> Album => Set<Album>();
    }
}
