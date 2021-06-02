using System.Collections.Generic;
using System.Security.Claims;

namespace DragonShop.Api
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
