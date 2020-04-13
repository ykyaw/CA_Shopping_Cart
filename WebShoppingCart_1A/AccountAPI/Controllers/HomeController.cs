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
using Newtonsoft.Json;
using System.Text.Json;

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
            Useraccount LoginUser = dbcontext.UserAccount_tbl.Where(x => x.Email == Email).FirstOrDefault();


            if (LoginUser != null)
            {
                if (LoginUser.password == Password)
                {
                    //List<string> loggedin = new List<string>();
                    //loggedin.Add(LoginUser.Id);
                    string userid = JsonConvert.SerializeObject(LoginUser.Id);
                    Response.Cookies.Append("UserId", userid);
                    //Response.Cookies.Append("UserId", JsonConvert.SerializeObject(userid));
                    return Redirect("https://localhost:44361/Account/Index");
                }
                else
                    return Redirect("https://localhost:44334/Home/Index");

            }
            return Redirect("https://localhost:44334/Home/Index");
        }
        public string getAccounts(Result result)
        {
            result.Value = dbcontext.UserAccount_tbl.ToList();
            return System.Text.Json.JsonSerializer.Serialize(result);
        }
    }
}
