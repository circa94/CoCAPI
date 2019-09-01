using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoCAPI.Builders;
using CoCAPI.Responses;
using Newtonsoft.Json;

namespace CoCAPI
{
    public class CoCApiClient
    {
        private readonly string baseUrl = "https://api.clashofclans.com/v1/";
        private readonly HttpClient httpClient;

        public CoCApiClient(string apiToken)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            httpClient.BaseAddress = new Uri(baseUrl);
        }

        public CoCApiClient(string apiToken, string baseUrl) : this(apiToken)
        {
            this.baseUrl = baseUrl;
        }

        public IPlayerSearchBuilder Players()
        {
            return new PlayerSearchBuilder(httpClient);
        }

        public IClanSearchBuilder Clans()
        {
            return new ClanSearchBuilder(httpClient);
        }

        public IClanTagSearchBuilder Clans(string clanTag)
        {
            return new ClanTagSearchBuilder(httpClient, clanTag);
        }
    }
}
