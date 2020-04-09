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
    }
}
