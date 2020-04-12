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
    public class OrdersController : Controller
    {
        List<Product> products = new List<Product>();
        List<Cart> carts = new List<Cart>();
        //FOLLOW UP
        //List<Order> orders = new List<Order>(); // get orders model
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public OrdersController(HttpClient httpClient, IConfiguration cfg,
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

        public void SuccessPayment(Result result)
        {

            //retrieve all product from productAPI
            string productAPIurl = cfg.GetValue<string>("Hosts:ProductsAPI") + "/Home/getProducts";
            Result p_result = new Result();
            p_result = dataFetcher.GetData(httpClient, productAPIurl, p_result);
            products = JsonConvert.DeserializeObject<List<Product>>(p_result.Value.ToString());

            //retrieve productId from CartState in cookie
            List<string> checkoutcart = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["CartState"]);
            List<Product> finalizedcart = new List<Product>();
            foreach (string ItemId in checkoutcart)
            {
                foreach (Product product in products)
                {
                    if (ItemId == product.Id)
                    {
                        finalizedcart.Add(product);
                    }
                }
            }

            result.Value = finalizedcart;
            string url = cfg.GetValue<string>("Hosts:OrderAPI") + "/Home/XXXX";
            result = dataFetcher.GetData(httpClient, url, result);
            Response.Cookies.Delete("CartState");
        }

        public IActionResult ViewPastPurchases(Result result)
        {

            //retrieve all product from OrderAPI
            string orderAPIurl = cfg.GetValue<string>("Hosts:OrderAPI") + "/Home/getProducts";
            Result o_result = new Result();
            o_result = dataFetcher.GetData(httpClient, orderAPIurl, o_result);
            //orders = JsonConvert.DeserializeObject<List<Product>>(o_result.Value.ToString());// get orders model from XJ
            //FOLLOW UP
            //ViewData["pastorders"] = orders;
            return View();
        }




    }
}