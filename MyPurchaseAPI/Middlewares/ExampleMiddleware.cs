
using Microsoft.AspNetCore.Http;
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
            string controller = (string)context.Request.RouteValues["controller"];
            string action = (string)context.Request.RouteValues["action"];
            //get sessionId from cookie
            if (controller == "Login")
            {

            }
            else
            {
                string sessionId = context.Request.Cookies["sessionId"];
                //judge the session id
                //if (sessionId == null)
                //{
                //    context.Response.Redirect("https://" +
                //        context.Request.Host + "/Login/Index");
                //    return;
                //}
                string userId = context.Session.GetString(sessionId);
                //judge the userId is correct
            }


            await next(context);
        }
    }
}
