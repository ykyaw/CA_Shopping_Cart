using AccountAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace AccountAPI.DB
{
    public class AccountSeeder
    {

        public AccountSeeder(MyDbContext dbcontext)
        {
            Useraccount user1 = new Useraccount();
            user1.Id = "1";
            user1.Name = "Tom Lee";
            user1.Email = "tomlee@gmail.com";
            user1.password = "123456";
            dbcontext.Add(user1);
            dbcontext.SaveChanges();

            Useraccount user2 = new Useraccount();
            user2.Id = "2";
            user2.Name = "Dick Tan";
            user2.Email = "dicktan@gmail.com";
            user2.password = "123456";
            dbcontext.Add(user2);
            dbcontext.SaveChanges();

            Useraccount user3 = new Useraccount();
            user3.Id = "3";
            user3.Name = "Harry Potter";
            user3.Email = "harrypotter@gmail.com";
            user3.password = "123456";
            dbcontext.Add(user3);
            dbcontext.SaveChanges();
        }

    }
}
