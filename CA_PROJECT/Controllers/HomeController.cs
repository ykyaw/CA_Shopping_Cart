using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIGateway.Models;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using APIGateway.Services;

namespace APIGateway.Controllers
{
    //Hello world from TK
    public class HomeController : Controller
    {
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public HomeController(HttpClient httpClient, IConfiguration cfg,
             DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }

        [Route("/example")]
        public string Example([FromBody] Operand operand)
        {
            string url;

            url = cfg.GetValue<string>("Hosts:TokenAPI") + "/Home/Example";
            operand = dataFetcher.GetData(httpClient, url, operand);
            return JsonSerializer.Serialize(operand);
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
    }
}
