using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OrdersAPI.Models;

namespace WebShoppingCart_1A.Services
{
    public class DataFetcher
    {
        public Result GetData(HttpClient httpClient, string url, Result result)
        {
            Task.Run(async () =>
            {
                HttpContent data = new StringContent(
                    JsonSerializer.Serialize(result),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await httpClient.PostAsync(
                    url, data
                );
                if (response.StatusCode.GetHashCode() == 200)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Result>(content);
                }
            }).Wait();

            return result;
        }
    }
}
