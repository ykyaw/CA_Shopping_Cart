using GalleryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.DB
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options1)
            : base(options1)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
