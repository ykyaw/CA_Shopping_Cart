using MyPurchaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.DB
{
    public class Seeder
    {
        public Seeder(PurchaseHistoryContext dbcontext)
        {
            // Create movies
            PurchaseHistory p1 = new PurchaseHistory();
            p1.Id = Guid.NewGuid().ToString();
            p1.UserId = Guid.NewGuid().ToString();
            p1.ProductId = Guid.NewGuid().ToString();
            p1.PurchaseDate= new DateTime(2020, 5, 28, 22, 30, 00).ToUniversalTime();
            p1.Quantity = 2;
            //PurchaseActivationCode p1code = new PurchaseActivationCode();
            //p1code.Id = Guid.NewGuid().ToString();
            //p1code.PurchaseHistoryId = p1.Id;
            //p1code.ActivationCode = Guid.NewGuid().ToString();
            //PurchaseActivationCode ppcode = new PurchaseActivationCode();
            //ppcode.Id = Guid.NewGuid().ToString();
            //ppcode.PurchaseHistoryId = p1.Id;
            //p1code.ActivationCode = Guid.NewGuid().ToString();
            dbcontext.Add(p1);
            //dbcontext.Add(ppcode);
            //dbcontext.Add(p1code);

            PurchaseHistory p = new PurchaseHistory();
            p.Id = Guid.NewGuid().ToString();
            p.UserId = Guid.NewGuid().ToString();
            p.ProductId = Guid.NewGuid().ToString();
            p.PurchaseDate = new DateTime(2020, 5, 28, 22, 30, 00).ToUniversalTime();
            //PurchaseActivationCode pcode = new PurchaseActivationCode();
            //pcode.Id = Guid.NewGuid().ToString();
            //pcode.PurchaseHistoryId = p.Id;
            //pcode.ActivationCode = Guid.NewGuid().ToString();
            p.Quantity = 2;
            dbcontext.Add(p);
            //dbcontext.Add(pcode);


            PurchaseHistory p2 = new PurchaseHistory();
            p2.Id = Guid.NewGuid().ToString();
            p2.UserId = Guid.NewGuid().ToString();
            p2.ProductId = Guid.NewGuid().ToString();
            p2.PurchaseDate = new DateTime(2020, 5, 28, 22, 30, 00).ToUniversalTime();
            //PurchaseActivationCode p3code = new PurchaseActivationCode();
            //p3code.Id = Guid.NewGuid().ToString();
            //p3code.PurchaseHistoryId = p2.Id;
            //p3code.ActivationCode = Guid.NewGuid().ToString();
            p2.Quantity = 3;
            dbcontext.Add(p2);
            //dbcontext.Add(p3code);

            PurchaseHistory p3 = new PurchaseHistory();
            p3.Id = Guid.NewGuid().ToString();
            p3.UserId = Guid.NewGuid().ToString();
            p3.ProductId = Guid.NewGuid().ToString();
            p3.PurchaseDate = new DateTime(2020, 5, 28, 22, 30, 00).ToUniversalTime();
            //PurchaseActivationCode p4code = new PurchaseActivationCode();
            //p4code.Id = Guid.NewGuid().ToString();
            //p4code.PurchaseHistoryId = p3.Id;
            //p4code.ActivationCode = Guid.NewGuid().ToString();
            p3.Quantity = 4;
            dbcontext.Add(p3);
            //dbcontext.Add(p4code);

            PurchaseHistory p4 = new PurchaseHistory();
            p4.Id = Guid.NewGuid().ToString();
            p4.UserId = Guid.NewGuid().ToString();
            p4.ProductId = Guid.NewGuid().ToString();
            p4.PurchaseDate = new DateTime(2020, 5, 28, 22, 30, 00).ToUniversalTime();
            //PurchaseActivationCode p5code = new PurchaseActivationCode();
            //p5code.Id = Guid.NewGuid().ToString();
            //p5code.PurchaseHistoryId = p4.Id;
            //p5code.ActivationCode = Guid.NewGuid().ToString();
            p4.Quantity = 2;
            dbcontext.Add(p4);
            //dbcontext.Add(p5code);

            dbcontext.SaveChanges();
        }
    }
}
