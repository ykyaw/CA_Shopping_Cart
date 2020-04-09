using GalleryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.DB
{
    public class DBSeeder
    {
        public DBSeeder(ProductDbContext dbcontext)
        {
            // Create mock products
            Product product1 = new Product();
            product1.Id = Guid.NewGuid().ToString();
            product1.Name = "NETCORE";
            product1.UnitPrice = "11.1";
            product1.Description = "This the descripiton of product1";
            product1.Photo = "photo1";
            dbcontext.Add(product1);

            Product product2 = new Product();
            product2.Id = Guid.NewGuid().ToString();
            product2.Name = "NETCORE";
            product2.UnitPrice = "22.2";
            product2.Description = "This the descripiton of product2";
            product2.Photo = "photo2";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = Guid.NewGuid().ToString();
            product3.Name = "NETCORE";
            product3.UnitPrice = "33.3";
            product3.Description = "This the descripiton of product3";
            product3.Photo = "photo3";
            dbcontext.Add(product3);

            dbcontext.SaveChanges();
        }
    }
}
