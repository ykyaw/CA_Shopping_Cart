using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.ProductDB
{
    public class ProductContext:DbContext 
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //model.Entity<Useraccount>().HasIndex(model => model.email).IsUnique();

        }
        public DbSet<Product> Product_tbl { get; set; }

    }


}

