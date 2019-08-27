using CoCAPI.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public class ClanSearchBuilder : IClanSearchBuilder
    {
        private string searchString = "";
        private readonly HttpClient httpClient;

        public ClanSearchBuilder(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Search clans by name. If name is used as part of search query, it needs to be at least three characters long. 
        /// Name search parameter is interpreted as wild card search, so it may appear anywhere in the clan name.
        /// </summary>
        /// <param name="clanName"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithName(string clanName)
        {
            searchString += $"name={clanName}&";
            return this;
        }

        /// <summary>
        /// Filter by clan war frequency. See <see cref="WarFrequency"/> constants for available options.
        /// </summary>
        /// <param name="warFrequency"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithWarFrequency(string warFrequency)
        {
            searchString += $"warFrequency={warFrequency}&";
            return this;
        }

        /// <summary>
        /// Executes the clan search.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Clan>> Search()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"clans?{searchString}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ClanSearchResponse clans = JsonConvert.DeserializeObject<ClanSearchResponse>(json);
                return clans.Items;
            }
            return null;
        }
    }
}
