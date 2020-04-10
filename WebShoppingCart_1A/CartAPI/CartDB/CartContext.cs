using CartAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.CartDB
{
    public class CartContext:DbContext 
    {
        
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
           // model.Entity<Useraccount>().HasIndex(model => model.email).IsUnique();

        }
        public DbSet<Cart> Cart_tbl { get; set; }

    }

}
