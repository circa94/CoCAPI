using CoCAPI.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public class ClanWarLogSearchBuilder : SearchBuilder, IClanWarLogSearchBuilder
    {
        private readonly string clanTag;

        public ClanWarLogSearchBuilder(HttpClient httpClient, string clanTag) : base(httpClient)
        {
            this.clanTag = clanTag;
        }


        public IClanWarLogSearchBuilder WithLimit(int limit)
        {
            AppendSearchParameter("limit", limit);
            return this;
        }

        public async Task<ICollection<War>> Search()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"clans/{clanTag}/warlog?{searchString}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WarLogResponse wars = JsonConvert.DeserializeObject<WarLogResponse>(json);
                return wars.Items;
            }
            return null;
        }
    }
}
