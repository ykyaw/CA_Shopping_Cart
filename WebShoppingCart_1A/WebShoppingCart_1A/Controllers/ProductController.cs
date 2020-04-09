using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShoppingCart_1A.Services;
//using System.Windows;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using WebShoppingCart_1A.Models;
using System.Text.Json;
//using System.Net;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using System.Text;
//using System.Web;


namespace WebShoppingCart_1A.Controllers
{
    public class ProductController : Controller
    {

        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public ProductController(HttpClient httpClient, IConfiguration cfg,
          DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }
        public IActionResult Index()
        {

            string url;
            url = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            string re=JsonSerializer.Serialize(result);
            //List<Product> products = (List<Product>)result.Value;
            ViewData["result"] = result;
            return View();
        }
    }
}