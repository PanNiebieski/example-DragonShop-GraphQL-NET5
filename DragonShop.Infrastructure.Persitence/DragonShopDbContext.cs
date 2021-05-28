using DragonShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace DragonShop.Infrastructure.Persitence
{
    public class DragonShopDbContext : DbContext
    {
        public DragonShopDbContext(DbContextOptions<DragonShopDbContext> options)
            : base(options)
        {

        }
        public DbSet<Dragon> Dragons { get; set; }
    }
}
