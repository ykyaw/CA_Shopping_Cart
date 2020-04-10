using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Models
{
    public class Cart
    {

        public string Id { get; set; }

        public string userId { get; set; }


        public string productId { get; set; }

        public string productName { get; set; }


        public string productDescription { get; set; }


        public double unitPrice { get; set; }


        public double productRating { get; set; }

        public int productQuantity { get; set; }




    }
}
