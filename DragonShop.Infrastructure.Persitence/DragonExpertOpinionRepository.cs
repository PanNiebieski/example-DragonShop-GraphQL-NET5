using DragonShop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonShop.Infrastructure.Persitence
{
    public class DragonExpertOpinionRepository
    {
        private readonly DragonShopDbContext _dbContext;

        public DragonExpertOpinionRepository(DragonShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ILookup<int, DragonExpertOpinion>> GetForDragons(IEnumerable<int> dragonIds)
        {
            var reviews = await _dbContext.DragonExpertOpinion.
                Where(pr => dragonIds.Contains(pr.DragonId)).ToListAsync();

            return reviews.ToLookup(r => r.DragonId);
        }

        public Task<List<DragonExpertOpinion>> GetForDragonId(int id)
        {
            var res = _dbContext.DragonExpertOpinion.Where(k => k.DragonId == id);


            return Task.FromResult(res.ToList());
        }
    }
}
