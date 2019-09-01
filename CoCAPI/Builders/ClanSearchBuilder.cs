using CoCAPI.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoCAPI.Builders
{
    public class ClanSearchBuilder : SearchBuilder, IClanSearchBuilder
    {
        public ClanSearchBuilder(HttpClient httpClient) : base(httpClient) { }

        /// <summary>
        /// Search clans by name. If name is used as part of search query, it needs to be at least three characters long. 
        /// Name search parameter is interpreted as wild card search, so it may appear anywhere in the clan name.
        /// </summary>
        /// <param name="clanName"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithName(string clanName)
        {
            AppendSearchParameter("clanName", clanName);
            return this;
        }

        /// <summary>
        /// Filter by clan war frequency. See <see cref="WarFrequency"/> constants for available options.
        /// </summary>
        /// <param name="warFrequency"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithWarFrequency(string warFrequency)
        {
            AppendSearchParameter("warFrequency", warFrequency);
            return this;
        }

        /// <summary>
        /// Filter by clan location identifier.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithLocationId(int locationId)
        {
            AppendSearchParameter("locationId", locationId);
            return this;
        }

        /// <summary>
        /// Filter by minimum number of clan members
        /// </summary>
        /// <param name="minMembers"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinMembers(int minMembers)
        {
            AppendSearchParameter("minMembers", minMembers);
            return this;
        }

        /// <summary>
        /// Filter by maximum number of clan members
        /// </summary>
        /// <param name="maxMembers"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMaxMembers(int maxMembers)
        {
            AppendSearchParameter("maxMembers", maxMembers);
            return this;
        }

        /// <summary>
        /// Filter by minimum amount of clan points.
        /// </summary>
        /// <param name="minClanPoints"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinClanPoints(int minClanPoints)
        {
            AppendSearchParameter("minClanPoints", minClanPoints);
            return this;
        }

        /// <summary>
        /// Filter by minimum clan level.
        /// </summary>
        /// <param name="minClanLevel"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithMinClanLevel(int minClanLevel)
        {
            AppendSearchParameter("minClanLevel", minClanLevel);
            return this;
        }

        /// <summary>
        /// Limit the number of items returned in the response.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IClanSearchBuilder WithLimt(int limit)
        {
            AppendSearchParameter("limit", limit);
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
