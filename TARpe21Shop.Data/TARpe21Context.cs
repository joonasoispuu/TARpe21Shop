using Microsoft.EntityFrameworkCore;
using TARpe21Shop.Core.Domain;


namespace TARpe21Shop.Data
{
    public class TARpe21ShopContext : DbContext
    {
        public TARpe21ShopContext(DbContextOptions<TARpe21ShopContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FilesToApi { get; set; }
    }
}
