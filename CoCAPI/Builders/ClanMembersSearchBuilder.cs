using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoCAPI.Responses;
using Newtonsoft.Json;

namespace CoCAPI.Builders
{
    public class ClanMembersSearchBuilder : SearchBuilder, IClanMembersSearchBuilder
    {
        private readonly string clanTag;

        public ClanMembersSearchBuilder(HttpClient httpClient, string clanTag) : base(httpClient)
        {
            this.clanTag = clanTag;
        }

        public IClanMembersSearchBuilder WithLimit(int limit)
        {
            AppendSearchParameter("limit", limit);
            return this;
        }

        public async Task<ICollection<ClanMember>> Search()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"clans/{clanTag}/members?{searchString}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ClanMemberListResponse clanMembers = JsonConvert.DeserializeObject<ClanMemberListResponse>(json);
                return clanMembers.Items;
            }
            return null;
        }
    }
}
