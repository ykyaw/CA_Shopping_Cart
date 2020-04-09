using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CartAPI.Controllers
{
    public class CartController : Controller
    {

        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public CartController(HttpClient httpClient, IConfiguration cfg,
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

            url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/CartList";
            operand = dataFetcher.GetData(httpClient, url, operand);
            var list = JsonConvert.DeserializeObject<List<Cart>>(operand.Value.ToString());
            ViewData["cartList"] = list;
            return View();
        }
        public double Total()
        {
            return 0;
        }

        public int updateQty()
        {
            return 0;
        }

        public void continueShopping()
        {
            
        }

        public void checkOut()
        {
            
        }

    }

  }