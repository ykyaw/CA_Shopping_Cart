using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using APIGateway.Utils;
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
            operand = dataFetcher.GetData(url, operand,Request);
            List<Cart> list = JsonConvert.DeserializeObject<List<Cart>>(operand.Value.ToString()); 
            url = cfg.GetValue<string>("Hosts:GalleryAPI") + "/Home/CartProduct";
            operand.Value = list;
            operand = dataFetcher.GetData(url, operand, Request);
            list = JsonConvert.DeserializeObject<List<Cart>>(operand.Value.ToString()); 
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            ViewData["user"] = user;
            ViewData["cartList"] = list;
            return View();
        }

        public bool Checkout()
        {
            string url;
            Operand operand = new Operand();
            url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/CartList";
            operand = dataFetcher.GetData(url, operand, Request);
            url = cfg.GetValue<string>("Hosts:MyPurchaseAPI") + "/Home/Checkout";
            operand = dataFetcher.GetData(url, operand, Request);
            IsDone done = JsonConvert.DeserializeObject<IsDone>(operand.Value.ToString());
            if (done.Done)
            {
                url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/Checkout";
                operand = dataFetcher.GetData(url, operand, Request);
                done = JsonConvert.DeserializeObject<IsDone>(operand.Value.ToString());
                if (done.Done)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("/changeQty")]
        public string ChangeQuantity([FromBody] Cart cart)
        {
            string url;
            Operand operand = new Operand() { Value=cart};
            url = cfg.GetValue<string>("Hosts:CartAPI") + "/Home/ChangeQuantity";
            operand = dataFetcher.GetData(url, operand, Request);
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

    }

  }