using DragonShop.Infrastructure.Persitence;
using GraphQL.Types;
using System;

namespace DragonShop.Api.GraphQL
{

    public class DragonSchema : Schema
    {
        private readonly DragonShopDbContext _dbContext;

        public DragonSchema(DragonShopDbContext dbContext, IServiceProvider sp) : base(sp)
        {
            _dbContext = dbContext;

            Query = new DragonQuery
               (new DragonRepository(_dbContext));
        }
    }
}
