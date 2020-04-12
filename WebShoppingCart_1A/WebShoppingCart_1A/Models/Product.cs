using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoppingCart_1A.Models
{
    public class Product
    {
      
        public string Id { get; set; }

        public string productName { get; set; }

       
        public string productDescription { get; set; }

        
        public double unitPrice { get; set; }

       
        public double productRating { get; set; }

        public string imageURL { get; set; }

        public string userId { get; set; } //only for processing checkout in orders controller. Do not delete


    }
}
