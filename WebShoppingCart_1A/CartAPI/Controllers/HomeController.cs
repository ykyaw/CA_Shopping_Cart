using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CartAPI.Models;
using WebShoppingCart_1A.Models;
using System.Text.Json;
using CartAPI.CartDB;
using Newtonsoft.Json;

namespace CartAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public CartContext dbcontext;


        public HomeController(ILogger<HomeController> logger, CartContext dbcontext)
        {
            _logger = logger;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string receivecartfromlogout([FromBody]Result result)
        {
            dbcontext.Database.EnsureDeleted(); //clears old cart records
            dbcontext.Database.EnsureCreated();
            List<Cart> receivedcart = new List<Cart>();
            receivedcart = JsonConvert.DeserializeObject<List<Cart>>(result.Value.ToString());
            Cart newcart = new Cart();
            foreach (Cart cart in receivedcart) // this adds new data
            {
                newcart.Id= Guid.NewGuid().ToString();
                newcart.productId = cart.productId;
                newcart.userId = cart.userId;
                dbcontext.Add(newcart);
                dbcontext.SaveChanges();
            }

            
            return System.Text.Json.JsonSerializer.Serialize(result);
        }
        public string clearcart([FromBody]Result result)
        {
            int x = JsonConvert.DeserializeObject<int>(result.Value.ToString());
            if (x == 0)
            { dbcontext.Database.EnsureDeleted(); } //clears old cart records
            return System.Text.Json.JsonSerializer.Serialize(result);
        }
        public string getProducts(Result result)
        {
            result.Value = dbcontext.Cart_tbl.ToList();
            return System.Text.Json.JsonSerializer.Serialize(result);
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

//CartModel cart = new CartModel();

//public void AddToCart(string ItemId /*Product product*/)
//{

//    //HttpContext.Session.GetObjectFromJson<listofcartitem>("listofcartitem");
//    CartModel objcartmodel = new CartModel();

//    // listofcartitem=HttpContext.Session.GetString
//    if (listofcartitem.Any(x => x.Id.ToString() == ItemId))
//    {
//        objcartmodel = listofcartitem.Single(x => x.Id == ItemId);
//        objcartmodel.quantity = objcartmodel.quantity + 1;
//    }
//    else
//    {
//        objcartmodel.Id = ItemId;
//        objcartmodel.quantity = 1;
//        listofcartitem.Add(objcartmodel);
//    }
//    int x = listofcartitem.Count;
//    //return JsonSerializer.Serialize(Result);
//}
