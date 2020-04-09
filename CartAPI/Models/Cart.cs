using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Models
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

        

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MaxLength(36)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(36)]
        public string ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

    
}
