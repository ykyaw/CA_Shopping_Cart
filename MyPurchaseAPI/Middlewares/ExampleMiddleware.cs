
using Microsoft.AspNetCore.Http;
using MyPurchaseAPI.Models;
using MyPurchaseAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.Middlewares
{
    public class ExampleMiddleware
    {
        private readonly RequestDelegate next;

        public ExampleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            User user = new User { Id = "123" };
            string encrypt = RSA.RSAEncryption(user);
            User decrypt = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(encrypt).ToString());
            await next(context);
        }
    }
}
