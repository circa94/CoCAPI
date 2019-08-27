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

        public async Task<Player> PlayerWithTag(string playerTag)
        {
            HttpResponseMessage response = await httpClient.GetAsync("players/" + playerTag);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Player player = JsonConvert.DeserializeObject<Player>(json);
                return player;
            }
            return null;
        }


        public IClanSearchBuilder Clans()
        {
            return new ClanSearchBuilder(httpClient);
        }
    }
}
