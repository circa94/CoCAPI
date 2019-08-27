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
            return AppendSearchParameter("clanName", clanName);
        }

        /// <summary>
        /// Filter by clan war frequency. See <see cref="WarFrequency"/> constants for available options.
        /// </summary>
        /// <param name="warFrequency"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithWarFrequency(string warFrequency)
        {
            return AppendSearchParameter("warFrequency", warFrequency);
        }

        /// <summary>
        /// Filter by clan location identifier.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithLocationId(int locationId)
        {
            return AppendSearchParameter("locationId", locationId);
        }

        /// <summary>
        /// Filter by minimum number of clan members
        /// </summary>
        /// <param name="minMembers"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinMembers(int minMembers)
        {
            return AppendSearchParameter("minMembers", minMembers);
        }

        /// <summary>
        /// Filter by maximum number of clan members
        /// </summary>
        /// <param name="maxMembers"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMaxMembers(int maxMembers)
        {
            return AppendSearchParameter("maxMembers", maxMembers);
        }

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        /// <param name="minClanPoints"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinClanPoints(int minClanPoints)
        {
            return AppendSearchParameter("minClanPoints", minClanPoints);
        }

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        /// <param name="minClanLevel"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinClanLevel(int minClanLevel)
        {
            return AppendSearchParameter("minClanLevel", minClanLevel);
        }

        /// <summary>
        /// Limit the number of items returned in the response.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithLimt(int limit)
        {
            return AppendSearchParameter("limit", limit);
        }

        /// <summary>
        /// Adds a new parameter to the search.
        /// </summary>
        /// <param name="paramName">Name of the paramter.</param>
        /// <param name="paramValue">Value of the paramter.</param>
        /// <returns></returns>
        private IClanSearchBuilder AppendSearchParameter(string paramName, object paramValue)
        {
            searchString += $"{paramName}={paramValue}&";
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
