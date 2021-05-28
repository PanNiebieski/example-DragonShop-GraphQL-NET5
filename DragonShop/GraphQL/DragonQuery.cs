using DragonShop.Api.GraphQL.Types;
using DragonShop.Infrastructure.Persitence;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL
{
    public class DragonQuery : ObjectGraphType
    {
        public DragonQuery(DragonRepository productRepository)
        {
            Field<ListGraphType<DragonType>>(
                "dragons",
                resolve: context => productRepository.GetAll()
            );
        }
    }
}
