using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.Models
{
    public class PurchaseHistory
    {
      
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }


        [Required] // means the column cannot be NULL 
        [MaxLength(36)] //mean max length is K characters long
        public string UserId { get; set; }

        [Required] // means the column cannot be NULL 
        [MaxLength(36)] //mean max length is K characters long
        public string ProductId { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }


        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public  User User { get; set; }

        [NotMapped]
        public  Product Product { get; set; }

        [NotMapped]
        public  List<PurchaseActivationCode> ActivationCodes { set; get; }
    }
}
