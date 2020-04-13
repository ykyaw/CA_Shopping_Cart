using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.Models
{
    public class Orders
    {
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } //activation code

        [Required]
        [MaxLength(36)]
        public string productId { get; set; }

        [Required]
        [MaxLength(36)]
        public string unitPrice { get; set; }

        [Required]
        [MaxLength(36)]
        public string userId { get; set; }

        [Required]
        [MaxLength(36)]
        public DateTime timestamp { get; set; }

        [Required]
        [MaxLength]
        public string imageURL { get; set; }
    }
}
