using GalleryAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.Extensions
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseMiddlewareExtensions(this IApplicationBuilder app)
        {
            //app.UseMiddleware<Middleware>();

            return app;
        }
    }
}
