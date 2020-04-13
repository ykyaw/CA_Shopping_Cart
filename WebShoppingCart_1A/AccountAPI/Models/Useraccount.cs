using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountAPI.Models
{
    public class Useraccount
    {
        public string Id { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
