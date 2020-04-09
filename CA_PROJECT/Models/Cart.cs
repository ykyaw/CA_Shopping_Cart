using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class Cart
    {
        private string userId;

        public Cart()
        {
        }

        public Cart(string userId)
        {
            this.UserId = userId;           
        }

        
        public string Id { get; set; }

        public string UserId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }

    
}
