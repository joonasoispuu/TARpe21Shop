using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21Shop.Core.Domain;

namespace TARpe21Shop.Data
{
    public class TARpe21ShopContext : DbContext
    {
        public TARpe21ShopContext(DbContextOptions<TARpe21ShopContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
    }
}
