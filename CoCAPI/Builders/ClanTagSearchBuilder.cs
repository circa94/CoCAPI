using System.Net.Http;
using System.Threading.Tasks;
using CoCAPI.Responses;
using Newtonsoft.Json;

namespace CoCAPI.Builders
{
    public class ClanTagSearchBuilder : SearchBuilder, IClanTagSearchBuilder
    {
        private readonly string clanTag;

        public ClanTagSearchBuilder(HttpClient httpClient, string clanTag) : base(httpClient)
        {
            this.clanTag = clanTag;
        }

        public IClanMembersSearchBuilder Members()
        {
            return new ClanMembersSearchBuilder(httpClient, clanTag);
        }

        public IClanWarLogSearchBuilder WarLog()
        {
            return new ClanWarLogSearchBuilder(httpClient, clanTag);
        }

        public async Task<Clan> Search()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"clans/{clanTag}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Clan clan = JsonConvert.DeserializeObject<Clan>(json);
                return clan;
            }
            return null;
        }
    }
}
