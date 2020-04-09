using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartAPI.Models;

namespace CartAPI.DB
{
    public class DBTesting
    {
        protected CartContext dbcontext;

        public List<Cart> ListCart()
        {
            List<Cart> carts = dbcontext.Carts
                .ToList();
            return carts;
         }
    }
}
