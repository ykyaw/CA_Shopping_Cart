
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
            string token=context.Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            await next(context);
        }
    }
}
