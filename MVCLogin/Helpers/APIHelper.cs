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
        private string url = "http://soelvkikkertproductsapi.azurewebsites.net/api/Products";

        public APIHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetObjectsFromAPI<T>()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            T objects = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return objects;
        }
    }
}
