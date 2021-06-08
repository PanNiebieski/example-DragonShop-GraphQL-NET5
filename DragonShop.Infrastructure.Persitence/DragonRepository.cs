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

        public async Task<Dragon> GetOne(int id)
        {
            var r = await _dbContext.Dragons.FirstOrDefaultAsync(p => p.Id == id);
            return r;
        }

        public async Task<List<Dragon>> GetAll()
        {
            var r = await _dbContext.Dragons.ToListAsync();
            return r;
        }
    }
}
