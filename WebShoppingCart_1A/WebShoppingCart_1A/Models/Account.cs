using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebShoppingCart_1A.Models
{
    public class Account
    {
        public class Useraccount
        {
            public string Id { get; set; }
            public string password { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }
    }
}
