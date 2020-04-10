using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.ProductDB
{
    public class ProductSeeder
    {
        public ProductSeeder(ProductContext dbcontext)
        {
            Product product1 = new Product();
            product1.Id = Guid.NewGuid().ToString();
            product1.productName = "Microsoft Office Professional 2019";
            product1.productDescription = "Get one of the most complete editions of the Microsoft Office package";
            product1.unitPrice = 40;
            product1.productRating = 4.5;
            product1.imageURL = "../images/Office.jpg";
            dbcontext.Add(product1);


            Product product2 = new Product();
            product2.Id = Guid.NewGuid().ToString();
            product2.productName = "Kaspersky Anti-Virus 2019";
            product2.productDescription = "Get one of the most complete editions of the anti-virus package";
            product2.unitPrice = 151;
            product2.productRating = 4.0;
            product2.imageURL = "../images/Kaspersky.png";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = Guid.NewGuid().ToString();
            product3.productName = "Norton Utilities";
            product3.productDescription = "Get one of the most complete editions of the PC booter package";
            product3.unitPrice = 79.9;
            product3.productRating = 3.5;
            product3.imageURL = "../images/Norton.png";
            dbcontext.Add(product3);
            dbcontext.SaveChanges();
        }
    }
}
