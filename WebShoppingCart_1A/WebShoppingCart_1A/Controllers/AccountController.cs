using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShoppingCart_1A.Services;
using Microsoft.Extensions.Configuration;
using WebShoppingCart_1A.Models;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;



namespace WebShoppingCart_1A.Controllers
{
    public class AccountController : Controller
    {
        List<Account> accounts = new List<Account>();
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;
        public AccountController(HttpClient httpClient, IConfiguration cfg,
          DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }
        public IActionResult Index()
        {
            string url;
            url = cfg.GetValue<string>("Hosts:AccountAPI") + "/Home/getAccounts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            accounts = JsonConvert.DeserializeObject<List<Account>>(result.Value.ToString());
            ViewData["accounts"] = accounts;
            return View();
        }
        public IActionResult Logout()
        {
            //List<string> currentcartid = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            //result.Value = currentcartid;
            //string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/XXXX";
            //result = dataFetcher.GetData(httpClient, url, result);
            Response.Cookies.Delete("UserId");
            return RedirectToAction("Index", "Product");
        }
    }
}