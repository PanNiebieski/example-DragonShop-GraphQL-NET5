using DragonShop.Website.Models;
using GraphQL;
using GraphQL.Client.Abstractions;
using System.Threading.Tasks;

namespace DragonShop.Website.Clients
{
    public class DragonGraphClientFromNuget
    {
        private readonly IGraphQLClient _client;

        public DragonGraphClientFromNuget(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<DragonModel> GetDragon(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @" 
                query dragonQuery ($dragonId: ID!)
                { dragon(id: $dragonId) 
                    { id name description introducedAt rating color breath price
                      opinions { title review }
                    }
                }",
                Variables = new { dragonId = id }
            };
            var response = await _client.SendQueryAsync<DragonContainer>(query);
            return response.Data.Dragon;
        }

        public async Task<Response<DragonsInList>> GetDragons()
        {
            var query = new GraphQLRequest
            {
                Query = @" 
                { dragons 
                    {     id,name,description,introducedAt,rating,color,breath,price  } 
                }"
            };
            var response = await _client.SendQueryAsync<Response<DragonsInList>>(query);
            return response.Data;

        }
    }
}
