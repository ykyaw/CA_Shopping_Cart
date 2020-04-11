using CartAPI.DB;
using CartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Services
{
    public class Carts
    {
        private CartContext db;

        public Carts(CartContext db)
        {
            this.db = db;
        }

        //this is to retrieve user shopping cart
        public List<Cart> GetCartList(User user)
        {
            string userId = user.Id;
            return db.Carts.Where(cart => cart.UserId == userId).ToList<Cart>();

        }
        // Added by Yuanchang for add to cart post
        public void AddToCart(Cart cart, User user)
        {
            //// Get the matching cart and user instances
            Cart cartRecord = db.Carts.Where(
                item => item.ProductId == cart.ProductId
                && item.UserId == user.Id).SingleOrDefault();
            if (cartRecord == null)
            {
                Cart newCart = new Cart
                {
                    // Create a new cart item if no cart item exists
                    Id = System.Guid.NewGuid().ToString(),
                    UserId = user.Id,
                    ProductId = cart.ProductId,
                    Quantity = 1
                };
                db.Add(newCart);
            }
            else
            {
                cartRecord.Quantity++;
            }
            db.SaveChanges();
        }
        // Added by Yuanchang to count items in cart
        public int GetCount(User user)
        {
            //Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Carts
                          where cartItems.UserId == user.Id
                          select (int?)cartItems.Quantity).Sum(); ;
            return count ?? 0;
        }
    }
    
}
