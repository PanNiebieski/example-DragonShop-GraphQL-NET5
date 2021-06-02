using DragonShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace DragonShop.Infrastructure.Persitence
{
    public class DragonShopDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine);
        //}

        public DragonShopDbContext(DbContextOptions<DragonShopDbContext> options)
            : base(options)
        {

        }
        public DbSet<Dragon> Dragons { get; set; }

        public DbSet<DragonExpertOpinion> DragonExpertOpinion { get; set; }
    }
}
