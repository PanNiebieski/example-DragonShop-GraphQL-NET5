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
                    Name = "John",
                    Description = "Stron.",
                    Price = 219.5m,
                    Rating = 4,
                    Color = WhatColors.Green,
                    Age = 30,
                    OrbitDurationYears = 20,
                    DryMassKg = 4330,
                    DiameterMeters = 100,
                    Active = true,
                    Breath = WhatBreath.None,
                    CrewCapacity = 20,
                    DoneFirstFlight = true,
                    HeightInMeters = 30,
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                });



                dbContext.SaveChanges();
            }
        }
    }
}
