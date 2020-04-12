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
            product1.Id = "MS Office Pro 2019";
            product1.productName = "Microsoft Office Professional 2019";
            product1.productDescription = "Get one of the most complete editions of the Microsoft Office package";
            product1.unitPrice = 40;
            product1.productRating = 5;
            product1.imageURL = "../images/Office.jpg";
            dbcontext.Add(product1);


            Product product2 = new Product();
            product2.Id = "Kasp AV2019";
            product2.productName = "Kaspersky Anti-Virus 2019";
            product2.productDescription = "Get one of the most complete editions of the anti-virus package";
            product2.unitPrice = 151;
            product2.productRating = 5;
            product2.imageURL = "../images/Kaspersky.png";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = "NortonUtil";
            product3.productName = "Norton Utilities";
            product3.productDescription = "Get one of the most complete editions of the PC booter package";
            product3.unitPrice = 79.9;
            product3.productRating = 3;
            product3.imageURL = "../images/Norton.png";
            dbcontext.Add(product3);


            Product product4 = new Product();
            product4.Id = "MovaviVid";
            product4.productName = "Movavi Video Editor";
            product4.productDescription = "With Movavi Video Editor you can create your own movies perfectly";
            product4.unitPrice = 49.9;
            product4.productRating = 3;
            product4.imageURL = "../images/Movavi.png";
            dbcontext.Add(product4);

            Product product5 = new Product();
            product5.Id = "3DS_Max";
            product5.productName = "3DS Max";
            product5.productDescription = "3DS Max is software for 3D modeling, animation, rendering, and visualization";
            product5.unitPrice = 272.8;
            product5.productRating = 4;
            product5.imageURL = "../images/3DSMAX.png";
            dbcontext.Add(product5);

            Product product6 = new Product();
            product6.Id = "McFreeAV";
            product6.productName = "McAfee";
            product6.productDescription = "Trusted Anti-virus and Anti-Phishing with identity and privacy protection";
            product6.unitPrice = 272.8;
            product6.productRating = 4;
            product6.imageURL = "../images/McAfee.png";
            dbcontext.Add(product6);



            dbcontext.SaveChanges();
        }
    }
}
