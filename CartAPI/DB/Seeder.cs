using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartAPI.Models;

namespace CartAPI.DB
{
    public class Seeder
    {
        public Seeder(CartContext db)
        {
            Cart cart1 = new Cart();
            cart1.Id = System.Guid.NewGuid().ToString();
            cart1.UserId = "1";
            cart1.ProductId = "1";
            cart1.Quantity = 2;
            db.Add(cart1);

            Cart cart2 = new Cart();
            cart2.Id = System.Guid.NewGuid().ToString();
            cart2.UserId = "1";
            cart2.ProductId = "2";
            cart2.Quantity = 3;
            db.Add(cart2);

            Cart cart3 = new Cart();
            cart3.Id = System.Guid.NewGuid().ToString();
            cart3.UserId = "2";
            cart3.ProductId = "2";
            cart3.Quantity = 4;
            db.Add(cart3);

            Cart cart4 = new Cart();
            cart4.Id = System.Guid.NewGuid().ToString();
            cart4.UserId = "2";
            cart4.ProductId = "3";
            cart4.Quantity = 4;
            db.Add(cart4);

            Cart cart5 = new Cart();
            cart5.Id = System.Guid.NewGuid().ToString();
            cart5.UserId = "2";
            cart5.ProductId = "4";
            cart5.Quantity = 6;
            db.Add(cart5);

            db.SaveChanges();
        }
    }
}
