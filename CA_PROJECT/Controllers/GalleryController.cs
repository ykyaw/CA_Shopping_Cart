using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using APIGateway.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace APIGateway.Controllers
{
    public class GalleryController : Controller
    {

        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;
        private static int badges = 0;
        private static User user = null;

        public GalleryController(HttpClient httpClient, IConfiguration cfg, DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }

        public IActionResult Search(string input)
        {
            string url;
            Operand operand = new Operand();
            url = cfg.GetValue<string>("Hosts:GalleryAPI") + "/Home/Products";
            operand = dataFetcher.GetData(url, operand, Request);
            List<Product> list = JsonConvert.DeserializeObject<List<Product>>(operand.Value.ToString());
            //return View(operand);
            if (input != null)
            {
                IEnumerable<Product> iter = from product in list
                                            where product.Description.ToLower().Contains(input) || product.Name.ToLower().Contains(input)
                                            select product;
                list = new List<Product>();
                foreach (Product product in iter)
                {
                    list.Add(product);
                }
            }
            ViewData["user"] = user;
            ViewData["gallery"] = list;
            ViewData["badges"] = badges;
            ViewData["search"] = input == null?"":input ;
            return View("Index");
        }

        public int Addtocart([FromBody] Cart cart)
        {
            string carts = Request.Cookies["cartList"];
            List<Cart> cartList = new List<Cart>();
            int badges = 0;
            if (carts != null)
            {
                cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(carts);
                bool hasProduct = false;
                foreach (Cart item in cartList)
                {
                    if (item.ProductId == cart.ProductId)
                    {
                        item.Quantity++;
                        hasProduct = true;
                    }
                    badges += item.Quantity;
                }
                if (!hasProduct)
                {
                    cart.Quantity = 1;
                    cartList.Add(cart);
                    badges++;
                }
            }
            else
            {
                cart.Quantity = 1;
                cartList.Add(cart);
                badges = 1;
            }
            string token = Request.Cookies["token"];
            if (token == null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);//set cookie expires day 
                string newCookieCarts = System.Text.Json.JsonSerializer.Serialize(cartList);
                Response.Cookies.Append("cartList", newCookieCarts, options);
            }
            else
            {
                Operand operand = new Operand();
                operand.Value = cartList;
                string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/Addtocart";
                //operand = dataFetcher.GetData(httpClient, url, operand);
                operand = dataFetcher.GetData(url, operand, Request);
                badges= JsonConvert.DeserializeObject<int>(operand.Value.ToString());
                Response.Cookies.Delete("cartList");
            }
            return badges;

        }

        public IActionResult Index()
        {
            string url;
            //int badges = 0;
            Operand operand = new Operand();
            url = cfg.GetValue<string>("Hosts:GalleryAPI") + "/Home/Products";
            operand = dataFetcher.GetData(url, operand, Request);
            var list = JsonConvert.DeserializeObject<List<Product>>(operand.Value.ToString());
            //return View(operand);
            ViewData["gallery"] = list;
            string token = Request.Cookies["token"];
            if (token != null)
            {
                string carts = Request.Cookies["cartList"];
                if (carts != null)
                {
                    List<Cart> cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(carts);
                    operand.Value = cartList;
                    url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/Addtocart";
                    operand = dataFetcher.GetData(url, operand, Request);
                    badges = JsonConvert.DeserializeObject<int>(operand.Value.ToString());
                    Response.Cookies.Delete("cartList");
                }
                else
                {
                    url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/GetCount";
                    operand = dataFetcher.GetData(url, operand, Request);
                    badges = JsonConvert.DeserializeObject<int>(operand.Value.ToString());
                }
                user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
                ViewData["user"] = user;
            }
            else
            {
                string carts = Request.Cookies["cartList"];
                List<Cart> cartList = new List<Cart>();
                if (carts != null)
                {
                    cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(carts);
                    foreach (Cart item in cartList)
                    {
                        badges += item.Quantity;
                    }
                }
            }
            ViewData["badges"] = badges;
            return View();
        }
    }
}