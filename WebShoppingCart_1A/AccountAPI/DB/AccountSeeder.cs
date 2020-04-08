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
            user1.email = "team1a@u.nus.edu";
            user1.password = "123456";
            dbcontext.Add(user1);
            dbcontext.SaveChanges();

        }

    }
}
