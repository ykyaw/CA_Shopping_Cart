using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Middlewares
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
            string controller = (string)context.Request.RouteValues["controller"];
            string action = (string)context.Request.RouteValues["action"];
            Debugger.Log(1,"info","controller in middleware "+ controller);
            //if (controller == "Home")
            //{
            //    string sessionId = context.Request.Cookies["sessionId"];
            //    if (sessionId == null)
            //    {
            //        context.Response.Redirect("https://" +
            //            context.Request.Host + "/Login/Index");
            //        return;
            //    }
            //}

            await next(context);
        }
    }
}
