using APIGateway.Models;
using APIGateway.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DB
{
    public class DBSeeder
    {
        public DBSeeder(UserContext dbcontext)
        {

            User user1 = new User();
            user1.Id = Guid.NewGuid().ToString();
            user1.Username = "admin";
            user1.Password = Crypto.Sha256("admin");
            user1.FirstName = "admin";
            user1.LastName = "admin";
            user1.Email = "admin@sa50.edu";
            dbcontext.Add(user1);

            User user2 = new User();
            user2.Id = Guid.NewGuid().ToString();
            user2.Username = "jade";
            user2.Password = Crypto.Sha256("jade");
            user2.FirstName = "Jade";
            user2.LastName = "Lim";
            user2.Email = "jade@sa50.edu";
            dbcontext.Add(user2);

            User user3 = new User();
            user3.Id = Guid.NewGuid().ToString();
            user3.Username = "sein";
            user3.Password = Crypto.Sha256("sein");
            user3.FirstName = "Sein";
            user3.LastName = "Hnin";
            user3.Email = "sein@sa50.edu";
            dbcontext.Add(user3);

            User user4 = new User();
            user4.Id = Guid.NewGuid().ToString();
            user4.Username = "yuanchang";
            user4.Password = Crypto.Sha256("yuanchang");
            user4.FirstName = "Yuanchang";
            user4.LastName = "Zhang";
            user4.Email = "yuanchang@sa50.edu";
            dbcontext.Add(user4);

            User user5 = new User();
            user5.Id = Guid.NewGuid().ToString();
            user5.Username = "yuding";
            user5.Password = Crypto.Sha256("yuding");
            user5.FirstName = "Yuding";
            user5.LastName = "Wu";
            user5.Email = "yuding@sa50.edu";
            dbcontext.Add(user5);

            dbcontext.SaveChanges();
        
        }
      }
   }