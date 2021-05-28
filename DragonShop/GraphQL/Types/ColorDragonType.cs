using DragonShop.Domain;
using GraphQL.Types;

namespace DragonShop.Api.GraphQL.Types
{
    public class ColorDragonType : EnumerationGraphType<ColorDragon>
    {
        public ColorDragonType()
        {
            Name = "ColorDragonType";

            Description = "The type of ColorDragon";
        }
    }

}
