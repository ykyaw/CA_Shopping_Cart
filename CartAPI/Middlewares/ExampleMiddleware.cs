
using Microsoft.AspNetCore.Http;
using CartAPI.Models;
using CartAPI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Middlewares
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
            await next(context);
        }
    }
}
