using DragonShop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DragonShop.Infrastructure.Persitence
{
    public class DragonRepository
    {
        private readonly DragonShopDbContext _dbContext;

        public DragonRepository(DragonShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Dragon> GetOne(int id)
        {
            return _dbContext.Dragons.SingleAsync(p => p.Id == id);
        }

        public Task<List<Dragon>> GetAll()
        {
            return _dbContext.Dragons.ToListAsync();
        }
    }
}
