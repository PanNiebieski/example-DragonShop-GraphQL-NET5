using DragonShop.Website.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DragonShop.Website.Clients
{
    public class DragonHttpClient
    {
        private readonly HttpClient _httpClient;

        public DragonHttpClient(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("DragonHttpClient");
        }

        public async Task<Response<DragonsInList>> GetDragons()
        {
            var response = await _httpClient.GetAsync(@"?query= 
            { dragons 
                {     id,name,description,introducedAt,rating,color,breath,price  } 
            }");
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<DragonsInList>>(stringResult);
        }

        public async Task<Response<DragonContainer>> GetDragon(int id)
        {
            dynamic request = new JObject();

            request.query = @"
                query dragonQuery($dragonId: ID!)
                {
                    dragon(id: $dragonId)
                        {
                        id name description introducedAt rating color breath price
                          opinions { title review }
                    }
            }";
            dynamic variables = new JObject();
            variables.dragonId = 1;
            request.variables = variables;

            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", content);
            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<DragonContainer>>(stringResult);
        }
    }
}
