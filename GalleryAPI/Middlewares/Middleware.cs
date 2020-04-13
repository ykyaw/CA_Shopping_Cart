using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GalleryAPI.Models;
using GalleryAPI.Utils;

namespace GalleryAPI.Middlewares
{
    public class Middleware
    {
        private readonly RequestDelegate next;

        public Middleware(RequestDelegate next)
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
