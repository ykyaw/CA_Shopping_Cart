using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class PurchaseHistory
    {
      
       
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public List<PurchaseActivationCode> ActivationCodes { set; get; }
    }
}
