using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebShoppingCart_1A.Models;

namespace WebShoppingCart_1A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login(string username) // link to our AccountAPI. to be completed
        {
            return View();
        }

        public IActionResult StartSession()
        {
            string sessionId = System.Guid.NewGuid().ToString();
            //CookieOption options = new CookieOptions();// this code not yet needed for our project
            Response.Cookies.Append("SessionId", sessionId);
            //return RedirectToAction("Index","Product");
            return RedirectToAction("Index","Product");
        }

        public IActionResult EndSession() //end session added by TK. Check if this goes into loop
        {
            Response.Cookies.Delete("SessionId");
            return RedirectToAction("Index"); 
        }



        public IActionResult Index()
        {
            string sessionId = Request.Cookies["SessionId"];
            ViewData["Session"] = sessionId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    internal class CookieOption
    {
    }
}
