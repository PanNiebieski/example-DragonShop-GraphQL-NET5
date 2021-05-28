using DragonShop.Infrastructure.Persitence;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL
{

    public class DragonSchema : Schema
    {
        private readonly DragonShopDbContext _dbContext;

        public DragonSchema(DragonShopDbContext dbContext) : base()
        {
            _dbContext = dbContext;

            Query = new DragonQuery
               (new DragonRepository(_dbContext));
        }


    }
}
