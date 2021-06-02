using DragonShop.Domain;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL.Types
{
    public class DragonOpinionType :
        ObjectGraphType<DragonExpertOpinion>
    {
        public DragonOpinionType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
