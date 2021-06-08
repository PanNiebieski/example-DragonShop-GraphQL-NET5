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
                    var id = context.GetArgument<int>("id");
                    if (id >= 3)
                        context.Errors.Add(new ExecutionError("Id is wrong"));

                    //var user = (GraphQLUserContext)context.UserContext;
                    //if (user.User.Identity.Name == "Cez") { }


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
