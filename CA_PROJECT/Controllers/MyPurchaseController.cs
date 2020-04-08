using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            return View();
        }

        //get purchase list
        [Route("/Purchases")]
        public string Purchases()
        {
            string url;
            Operand operand = new Operand();

            url = cfg.GetValue<string>("Hosts:MyPurchaseAPI") + "/Home/Purchases";
            operand = dataFetcher.GetData(httpClient, url, operand);
            //return View(operand);
            return JsonSerializer.Serialize(operand);
        }
    }
}