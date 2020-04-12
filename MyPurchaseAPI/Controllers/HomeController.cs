using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPurchaseAPI.Models;
using MyPurchaseAPI.Services;
using MyPurchaseAPI.Utils;
using Newtonsoft.Json;

namespace MyPurchaseAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Purchase purchase;

        public HomeController(ILogger<HomeController> logger,Purchase purchase)
        {
            _logger = logger;
            this.purchase = purchase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Checkout([FromBody] Operand operand)
        {
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            List<Cart> cartList= System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(operand.Value.ToString());
            operand.Value=purchase.Checkout(cartList,user);
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

        //get purchase list
        public string Purchases([FromBody] Operand operand)
        {
            string token=Request.Cookies["token"]; 
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            List<PurchaseHistory> purchaseHistories = purchase.GetPurchaseHistories(user);
            operand.Value = purchaseHistories;
            return System.Text.Json.JsonSerializer.Serialize(operand);
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
