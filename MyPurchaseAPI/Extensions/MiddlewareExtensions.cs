
using Microsoft.AspNetCore.Builder;
using MyPurchaseAPI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExampleMiddleware>();

            return app;
        }
    }
}
