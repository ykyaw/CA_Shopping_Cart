using GalleryAPI.DB;
using GalleryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.Services
{
    public class Gallery
    {
        //private ProductDbContext dbcontext;

        private ProductDbContext dbcontext;

        public Gallery(ProductDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        //The entire content of a database table can be returned 
        //using the syntax dbcontext.tablename.ToList()

        public List<Product> GetAllProducts()
        {
            List<Product> products = dbcontext.Products.ToList<Product>(); //Select * from

            foreach (Product productclass in products)
            {
            }

            return products;
        }
    }
}
