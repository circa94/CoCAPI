using CoCAPI.Responses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public class PlayerSearchBuilder : SearchBuilder, IPlayerSearchBuilder
    {
        public PlayerSearchBuilder(HttpClient httpClient) : base(httpClient)
        {
        }

        public IPlayerSearchBuilder WithPlayerTag(string playerTag)
        {
            searchString = $"players/{playerTag}";
            return this;
        }

        public async Task<Player> Search()
        {
            HttpResponseMessage response = await httpClient.GetAsync(searchString);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Player player = JsonConvert.DeserializeObject<Player>(json);
                return player;
            }
            return null;
        }
    }
}
