using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AccountAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AccountAPI.DB;

namespace AccountAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        protected MyDbContext dbcontext;


        public HomeController(ILogger<HomeController> logger, MyDbContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;

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

        public IActionResult Login(string Email, string Password)
        {
            //code wanted here-------
            //condition:2. are the username and password able to be found in our database--> yes,go to con 3; -->no,return login
            //condition:3. is username and password matches?-->yes, SetString and send back to API gateway
            Useraccount LoginUser = dbcontext.UserAccount_tbl.Where(x => x.email == Email).FirstOrDefault();


            if (LoginUser != null)
            {
                if (LoginUser.password == Password )
                {
                    return View("OkLogin");
                }

                else
                    return RedirectToAction("Index");
                
            }
            
                return View("Privacy");


            //HttpContext.Session.SetString("username", username);
            //code here wanted------to send username from account API to APIgateway
            //return RedirectToAction();


        }
    }
}
