using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.Models
{
    public class Cart
    {

        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public  Product Product { set; get; }
    }

    
}
