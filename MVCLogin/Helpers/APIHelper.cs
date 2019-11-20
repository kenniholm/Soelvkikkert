using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVCLogin.Models;
using Newtonsoft.Json;

namespace MVCLogin.Helpers
{
    public class APIHelper
    {

        private IHttpClientFactory _clientFactory;

        public APIHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetObjectsFromAPI<T>(string connectionString)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, connectionString);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            T objects = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return objects;
        }
    }
}
