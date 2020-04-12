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
            product1.Name = ".NET Charts";
            product1.UnitPrice = 99;
            product1.Description = "Brings powerful charting capabilities to your .NET applications.";
            product1.Photo = "photo1";
            dbcontext.Add(product1);

            Product product2 = new Product();
            product2.Id = Guid.NewGuid().ToString();
            product2.Name = ".NET PayPal";
            product2.UnitPrice = 69;
            product2.Description = "Integrate your .NET apps with PayPal the easy way!";
            product2.Photo = "photo2";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = Guid.NewGuid().ToString();
            product3.Name = ".NET ML";
            product3.UnitPrice = 254;
            product3.Description = "Supercharged .NET machine learning libraies.";
            product3.Photo = "photo3";
            dbcontext.Add(product3);

            Product product4 = new Product();
            product4.Id = Guid.NewGuid().ToString();
            product4.Name = ".NET Analytics";
            product4.UnitPrice = 134;
            product4.Description = "Performs data mining and analytics easily in .NET.";
            product4.Photo = "photo";
            dbcontext.Add(product4);

            Product product5 = new Product();
            product5.Id = Guid.NewGuid().ToString();
            product5.Name = ".NET Logger ";
            product5.UnitPrice = 75;
            product5.Description = "Logs and aggregates events easily in your .NET apps.";
            product5.Photo = "photo";
            dbcontext.Add(product5);

            Product product6 = new Product();
            product6.Id = Guid.NewGuid().ToString();
            product6.Name = ".NET Numerics";
            product6.UnitPrice =177;
            product6.Description = "Powerful numerical methods for your .NET simulations.";
            product6.Photo = "photo";
            dbcontext.Add(product6);


            dbcontext.SaveChanges();
        }
    }
}
