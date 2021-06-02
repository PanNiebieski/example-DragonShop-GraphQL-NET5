using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DragonShop.Infrastructure.Persitence
{
    public static class DragonShopInstaller
    {
        public static IServiceCollection AddDragonPersitence(this IServiceCollection services,
            IConfiguration _config)
        {
            services.AddDbContext<DragonShopDbContext>(options =>
    options.UseSqlite(_config["ConnectionStrings:DragonDB"]));
            services.AddScoped<DragonRepository>();
            services.AddScoped<DragonExpertOpinionRepository>();

            return services;
        }
    }
}
