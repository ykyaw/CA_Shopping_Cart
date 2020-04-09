using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CartAPI.DB;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using CartAPI.Models;
using System.Text.Json;

namespace CartAPI.Controllers
{
    public class CartController : Controller
    {
        private string userId;

        private CartContext db;

        public CartController(CartContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
          return View();
        }


        
        [Route("/cartList")]
        public string ListCart()
        {
            List<Cart> carts = db.Carts
                .ToList();
            return JsonSerializer.Serialize(carts);
        }


        public double Total()
        {
            return 0;
        }

        public int updateQty()
        {
            return 0;
        }

        public void continueShopping()
        {
            
        }

        public void checkOut()
        {
            
        }



        //public ActionResult Cart()
        //{
        //    ViewBag.ItemCount = GetItemCount();
        //    ViewBag.CartItems = GetAllCartItems();
        //    return View();
        //}

        //private dynamic GetAllCartItems()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Cart> GetAllCartItems(string query)
        //{
        //    //int userId = (int)HttpContext.Current.Session["UserId"];
        //    using (var db = new CartContext())
        //    {
        //        var query = db.Carts.Where(cart => cart.UserId == "2" && cart
        //        .Quantity == 0)
        //            .Select(cart => cart.Id).FirstOrDefault();
        //        return GetAllCartItems(query);

        //    }




        //}

        //public int GetItemCount()
        //{
        //    //int userId = (int)HttpContext.Current.Session["UserId"];
        //    using (var db = new CartContext())
        //    {
        //        Cart cart = db.Carts.FirstOrDefault(x => x.UserId == "1" && 
        //        x.Quantity == 0);

        //        if (cart == null)
        //        {
        //            cart = new Cart(userId);
        //            db.Cart.Add(cart);
        //            db.SaveChanges();
        //            return 0;
        //        }

        //        return cart.Quantity;
        //    }
        //}
    }

  }