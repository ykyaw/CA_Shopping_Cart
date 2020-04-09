using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIGateway.Models;
using Microsoft.Data.SqlClient;
using APIGateway.DB;
using APIGateway.Services;


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

            return View();
        }

        public IActionResult Verify(User user)
        {
            var userDetails = usercontext.User.Where(
            x => x.Username == user.Username && x.Password == user.Password)
            .FirstOrDefault();
            if (userDetails == null)
            {
                user.errmsg = "Wrong Username or Password entered.";
                return View("Index", user);
            }
            return View(user);

        }
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


