﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using APIGateway.Models;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using APIGateway.Utils;

namespace APIGateway.Services
{
    /**
     * this method transit the http request to according api
     */
    public class DataFetcher
    {
        public Operand GetData(string url, Operand operand,HttpRequest request)
        {
            var handler = new HttpClientHandler() { UseCookies = true };
            var httpClient = new HttpClient(handler);// { BaseAddress = baseAddress };
            //httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0");
            //httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            //httpClient.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token="+request.Cookies["token"]);
            //string token = request.Cookies["token"];
            //User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            //operand.User = user;
            Task.Run(async () =>
            {
                HttpContent data = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(operand),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await httpClient.PostAsync(
                    url, data
                );
                if (response.StatusCode.GetHashCode() == 200)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    operand = System.Text.Json.JsonSerializer.Deserialize<Operand>(content);
                }
            }).Wait();

            return operand;
        }
    }
}
