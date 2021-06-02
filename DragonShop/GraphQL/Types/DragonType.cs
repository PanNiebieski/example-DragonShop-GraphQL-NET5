using DragonShop.Domain;
using DragonShop.Infrastructure.Persitence;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL.Types
{
    public class DragonType : ObjectGraphType<Dragon>
    {
        public DragonType(DragonExpertOpinionRepository rep, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field<ListGraphType<DragonOpinionType>>("opinions",
                resolve: context =>
                {
                    var user = (GraphQLUserContext)context.UserContext;

                    if (user.User.Identity.Name == "Cez") { }


                    var loader =
                       dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, DragonExpertOpinion>(
                           "GetReviewsByProductId", rep.GetForDragons);
                    return loader.LoadAsync(context.Source.Id);

                });

            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the draon");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the dragon was first introduced in the catalog");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field<ColorDragonType>("Color", "The color of dragon");
            Field<BreathDragonType>("Breath", "The breath of dragon");

            //Field(t => t.Active);
            //Field(t => t.Age);
            //Field(t => t.CrewCapacity);
            //Field(t => t.DiameterMeters);
            //Field(t => t.DoneFirstFlight);
            //Field(t => t.DryMassKg);
            //Field(t => t.OrbitDurationYears);
            //Field(t => t.HeightInMeters);
        }
    }

    //public class DragonType : ObjectGraphType<Dragon>
    //{
    //    public DragonType(IServiceProvider serviceProvider)
    //    {

    //        var rep = (DragonExpertOpinionRepository)serviceProvider
    //            .GetService(Type.GetType("DragonExpertOpinionRepository"));

    //        Field(t => t.Id);
    //        Field(t => t.Name).Description("The name of the draon");
    //        Field(t => t.Description);
    //        Field(t => t.IntroducedAt).Description("When the dragon was first introduced in the catalog");
    //        Field(t => t.Price);
    //        Field(t => t.Rating).Description("The (max 5) star customer rating");
    //        Field<ColorDragonType>("Color", "The color of dragon");
    //        Field<BreathDragonType>("Breath", "The breath of dragon");

    //        Field<ListGraphType<DragonOpinionType>>("opinions",
    // resolve: context => rep.GetForDragonId(context.Source.Id));

    //        //Field(t => t.Active);
    //        //Field(t => t.Age);
    //        //Field(t => t.CrewCapacity);
    //        //Field(t => t.DiameterMeters);
    //        //Field(t => t.DoneFirstFlight);
    //        //Field(t => t.DryMassKg);
    //        //Field(t => t.OrbitDurationYears);
    //        //Field(t => t.HeightInMeters);
    //    }
    //}
}
