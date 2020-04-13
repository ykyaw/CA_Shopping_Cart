using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoppingCart_1A.Models
{
    public class Orders
    {
        public string Id { get; set; }

        public string productId { get; set; }
        //activation code

        public double unitPrice { get; set; }

        public string userId { get; set; }

        public DateTime timestamp { get; set; }

        public string imageURL { get; set; }

    }
}
