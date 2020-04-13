
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
            string token = context.Request.Cookies["token"];
            //judge the token
            if (token != null)
            {
                User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
                if (user != null)
                {
                    context.Response.Redirect("https://" +
                       context.Request.Host + "/Login");
                    return;
                }
            }
            await next(context);
        }
    }
}
