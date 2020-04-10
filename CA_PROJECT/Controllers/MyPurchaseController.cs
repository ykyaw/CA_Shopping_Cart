using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

/**
* MyPurchase Controller
* @author WUYUDING
*/
namespace APIGateway.Controllers
{
    public class MyPurchaseController : Controller
    {
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public MyPurchaseController(HttpClient httpClient, IConfiguration cfg,
            DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }

        public IActionResult Index()
        {
            string url;
            Operand operand = new Operand();
            string sessionId = Request.Cookies["sessionId"];
            string userId = HttpContext.Session.GetString(sessionId);
            url = cfg.GetValue<string>("Hosts:MyPurchaseAPI") + "/Home/Purchases";
            operand = dataFetcher.GetData(httpClient, url, operand);
            var list = JsonConvert.DeserializeObject<List<PurchaseHistory>>(operand.Value.ToString());
            //return View(operand);
            ViewData["purchases"] = list;
            return View();
        }

        //get purchase list
        //[Route("/Purchases")]
        //public string Purchases()
        //{
        //    string url;
        //    Operand operand = new Operand();

        //    url = cfg.GetValue<string>("Hosts:MyPurchaseAPI") + "/Home/Purchases";
        //    operand = dataFetcher.GetData(httpClient, url, operand);
        //    return System.Text.Json.JsonSerializer.Serialize(operand);
        //}
    }
}