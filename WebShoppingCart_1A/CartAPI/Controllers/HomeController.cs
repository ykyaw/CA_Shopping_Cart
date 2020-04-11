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


        public string receivecartfromapi([FromBody]Result result)
        {
            //result.Value = JsonSerializer.Deserialize<Result>(result.Value.ToString());
            Cart usercart = new Cart();
            //string sessionID = Request.Cookies["SessionId"];
            string ItemId = result.Value.ToString();
            //usercart.userId = sessionID;
            usercart.Id = Guid.NewGuid().ToString();
            usercart.productId = ItemId;
            dbcontext.Add(usercart);
            dbcontext.SaveChanges();
            return JsonSerializer.Serialize(result);

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
