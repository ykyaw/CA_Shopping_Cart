using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CartAPI.Models;
using CartAPI.Services;
using System.Text.Json;
using CartAPI.Utils;
using Newtonsoft.Json;

namespace CartAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Carts carts;

        public HomeController(ILogger<HomeController> logger,Carts carts)
        {
            _logger = logger;
            this.carts = carts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string CartList([FromBody] Operand operand)
        {
            User user = (User)operand.Value;
            operand.Value=carts.GetCartList(user);   
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }
        // Added by Yuanchang for add to cart post
        public string Addtocart([FromBody] Operand operand)
        {
            Cart cart = System.Text.Json.JsonSerializer.Deserialize<Cart>(operand.Value.ToString());
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());

            carts.AddToCart(cart, user);

            int cartQty = carts.GetCount(user);

            operand.Value = cartQty;

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
