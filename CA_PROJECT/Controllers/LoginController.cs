using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIGateway.Models;
using Microsoft.Data.SqlClient;
using APIGateway.DB;
using APIGateway.Services;
using Microsoft.AspNetCore.Http;
using APIGateway.Utils;
using Newtonsoft.Json;

namespace APIGateway.Controllers
{
    public class LoginController : Controller
    {
        protected UserContext usercontext;

        public LoginController(UserContext userContext)

        {
            this.usercontext = userContext;
        }

        public IActionResult Index()
        {
            User user = new User() { Id = "123123" };
            string token = RSA.RSAEncryption(user);//get token
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);//set cookie expires day 
            Response.Cookies.Append("token", token, options);
            return View();
        }

        public IActionResult Login (string username, string hashPwd)
        {
            return View("Index, Gallery");
        }

        public string Verify([FromBody]User user)
        {
            var userDetails = usercontext.User.Where(
            x => x.Username == user.Username && x.Password == user.Password)
            .FirstOrDefault();
            if (userDetails == null)
            {
                user.ErrMsg = "Wrong Username or Password entered.";
                return System.Text.Json.JsonSerializer.Serialize(user);
            }
            return System.Text.Json.JsonSerializer.Serialize(new Operand() { Value= "https://" +
                        Request.Host + "/Home/Index"
            });
        }


        //public IActionResult Login([FromBody]User user)
        //{
        //    var userDetails = usercontext.User.Where(
        //    x => x.Username == user.Username && x.Password == user.Password)
        //    .FirstOrDefault();
        //    if (userDetails == null)
        //    {
        //        user.ErrMsg = "Wrong Username or Password entered.";
        //        return View("Index", user);
        //    }
        //    userDetails.Password = null;
        //    string token = RSA.RSAEncryption(userDetails);//get token
        //    CookieOptions options = new CookieOptions();
        //    options.Expires=DateTime.Now.AddDays(1);//set cookie expires day 
        //    Response.Cookies.Append("token", token, options);
        //    //HttpContext.Session.SetString(sessionId, userDetails.Id);
        //    return View(user);

        //}
    }
}

/* else
{
    Session["userId"] = userDetails.userId;
    Session["username"] = userDetails.userFirstName;
    return RedirectToAction("Index", "Gallery");
}*/


/* public IActionResult Logout()
 {
     int UserId = (int)Session["userId"];
     Session.Abandon();
     return RedirectToAction("Index", "Login");
 }*/


