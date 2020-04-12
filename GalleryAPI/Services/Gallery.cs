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

        public List<PurchaseHistory> PurchasesProduct(List<PurchaseHistory> list)
        {
            foreach(PurchaseHistory item in list)
            {
                item.Product = dbcontext.Products.Where(product => product.Id == item.ProductId).FirstOrDefault();
            }
            return list;
        }

        //The entire content of a database table can be returned 
        //using the syntax dbcontext.tablename.ToList()

        public List<Product> GetAllProducts()
        {
            List<Product> products = dbcontext.Products.ToList<Product>(); //Select * from
            return products;
        }

        public List<Cart> CartProduct(List<Cart> cartList)
        {
            foreach(Cart cart in cartList)
            {
                cart.Product=dbcontext.Products.Where(product => product.Id == cart.ProductId).SingleOrDefault();
            }
            return cartList;
        }
    }
}
