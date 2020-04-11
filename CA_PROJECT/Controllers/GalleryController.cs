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

        public GalleryController(HttpClient httpClient, IConfiguration cfg, DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }

        public string Addtocart([FromBody] Cart cart)
        {
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            if (user == null)
            {
                string carts = Request.Cookies["carts"];
                List<Cart> cartList = new List<Cart>();
                if (carts != null)
                {
                    cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(carts);
                }
                cartList.Add(cart);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(10);//set cookie expires day 
                string newCookieCarts = System.Text.Json.JsonSerializer.Serialize(cartList);
                Response.Cookies.Append("carts", newCookieCarts, options);
                return "success";
            }
            else
            {
                //
                Operand operand = new Operand();
                operand.Value = cart;
                string url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/Addtocart";
                //operand = dataFetcher.GetData(httpClient, url, operand);
                operand = dataFetcher.GetData(url, operand, Request);
                return "success";
            }

        }

        // Attribute redirect to Gallery page
        //[Route("/Gallery")]
        public IActionResult Index()
        {
            string url;
            Operand operand = new Operand();
            url = cfg.GetValue<string>("Hosts:GalleryAPI") + "/Home/Products";
            operand = dataFetcher.GetData(url, operand, Request);
            var list = JsonConvert.DeserializeObject<List<Product>>(operand.Value.ToString());
            //return View(operand);
            ViewData["gallery"] = list;

            //Create a list of user for user name display
            //Try to call a method "Users" which list down all of users
            /*            string url1;
                        Operand operand1 = new Operand();
                        url1 = cfg.GetValue<string>("Hosts:APIGateway") + "/Home/Products";
                        operand = dataFetcher.GetData(url, operand, Request);
                        var userList = JsonConvert.DeserializeObject<List<User>>(operand.Value.ToString());
                        ViewData["user"] = userList;*/
            return View();
        }
    }
}