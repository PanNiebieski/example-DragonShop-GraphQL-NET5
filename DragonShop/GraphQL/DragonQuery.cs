using DragonShop.Api.GraphQL.Types;
using DragonShop.Infrastructure.Persitence;
using GraphQL;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL
{
    public class DragonQuery : ObjectGraphType
    {
        public DragonQuery(DragonRepository dragonRepository)
        {

            Field<DragonType>(
                "dragon",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var user = (GraphQLUserContext)context.UserContext;

                    if (user.User.Identity.Name == "Cez") { }

                    var id = context.GetArgument<int>("id");
                    return dragonRepository.GetOne(id);
                }
            );

            Field<ListGraphType<DragonType>>(
                "dragons",
                resolve: context => dragonRepository.GetAll()

            );
        }
    }
}
