using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.DB
{
    public class CartContext : DbContext
    {
        public CartContext()
        {
        }

        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Cart> Carts { get; set; }
        public IEnumerable<object> Cart { get; internal set; }
    }
}
