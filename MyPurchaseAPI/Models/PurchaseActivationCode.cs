using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyPurchaseAPI.Models
{
    public class PurchaseActivationCode
    {
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { set; get; }

        [Required] // means the column cannot be NULL 
        [MaxLength(36)] //mean max length is K characters long
        public string PurchaseHistoryId { set; get; }

        [Required]
        [MaxLength(200)]
        public string ActivationCode { get; set; }
    }
}
