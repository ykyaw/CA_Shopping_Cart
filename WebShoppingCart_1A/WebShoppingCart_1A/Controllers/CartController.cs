using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShoppingCart_1A.Models;
using WebShoppingCart_1A.Services;

namespace WebShoppingCart_1A.Controllers
{
    public class CartController : Controller
    {
        List<Cart> carts = new List<Cart>();
        List<Product> products = new List<Product>();
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

        public IActionResult Showcart()
        {
            //retrieve all product from productAPI
            string productAPIurl = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result p_result = new Result();
            p_result = dataFetcher.GetData(httpClient, productAPIurl, p_result);
            products = JsonConvert.DeserializeObject<List<Product>>(p_result.Value.ToString());

            //retrieve a list of productID and userId/sessionId from CartAPI
            string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/RetrieveCart";
            Result result = new Result();
            result = dataFetcher.GetData(httpClient, url, result);
            carts = JsonConvert.DeserializeObject<List<Cart>>(result.Value.ToString());
            ViewData["cartcounter"] = carts.Count; //To display under total quantity

            List<Product> currentcart = new List<Product>();

            foreach (Cart cart in carts)
            {
                foreach(Product product in products)
                {
                    if (cart.productId==product.Id)
                    {
                        currentcart.Add(product);
                    }
                }
            }

            ViewData["currentcart"] = currentcart;

            return View();
        }

        public void Cartcounter()
        {

        }


    }
}