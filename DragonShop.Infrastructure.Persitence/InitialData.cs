using DragonShop.Domain;
using System;
using System.Linq;

namespace DragonShop.Infrastructure.Persitence
{
    public static class InitialData
    {
        public static void Seed(this DragonShopDbContext dbContext)
        {
            if (!dbContext.Dragons.Any())
            {
                dbContext.Dragons.Add(new Dragon
                {
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                });



                dbContext.SaveChanges();
            }
        }
    }
}
