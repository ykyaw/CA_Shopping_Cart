using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountAPI.Models;
using Microsoft.AspNetCore.Http;

namespace AccountAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

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

        public IActionResult Login(string username,string password)
        {
            //code wanted here-------
            //condition:1.is the username null?-->null, return to login page
            //condition:2. are the username and password able to be found in our database and correct?--> yes, proceed; -->no,return login
            //condition:3. is username and password matches?-->yes, SetString and send back to API gateway
            if(HttpContext.Session.GetString("username")!=null)
            {
                //string user = username;
                //string pwd = password;
                return RedirectToAction("index");
            }
            if(string.IsNullOrEmpty(username))
            {
                return RedirectToAction("index");

            }
            HttpContext.Session.SetString("username", username);
            //code here wanted------to send username from account API to APIgateway
            return RedirectToAction()
            

        }
    }
}
