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

        public string Checkout([FromBody] Operand operand)
        {
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            operand.Value = carts.Checkout(user);
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

        public string CartList([FromBody] Operand operand)
        {
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            operand.Value=carts.GetCartList(user);   
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }
        // Added by Yuanchang for add to cart post
        public string Addtocart([FromBody] Operand operand)
        {
            List<Cart> cartList = System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(operand.Value.ToString());
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());

            carts.AddToCart(cartList, user);

            int cartQty = carts.GetCount(user);

            operand.Value = cartQty;

            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

        public string GetCount([FromBody] Operand operand)
        {
            string token = Request.Cookies["token"];
            User user = JsonConvert.DeserializeObject<User>(RSA.RSADecrypt(token).ToString());
            int badges=carts.GetCount(user);
            operand.Value = badges;
            return System.Text.Json.JsonSerializer.Serialize(operand);
        }

        public string ChangeQuantity([FromBody] Operand operand)
        {
            Cart cart= System.Text.Json.JsonSerializer.Deserialize<Cart>(operand.Value.ToString());
            if (carts.ChangeQuantity(cart))
            {
                operand.Value = true;
            }
            else
            {
                operand.Value = false;
            }
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
