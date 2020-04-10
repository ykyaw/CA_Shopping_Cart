using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class Product
    {

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string productName { get; set; }

        [Required]
        [MaxLengthAttribute]
        public string productDescription { get; set; }

        [Required]
        [MaxLength(128)]
        public double unitPrice { get; set; }

        [MaxLength(36)]
        public double productRating { get; set; }

        [MaxLengthAttribute]
        public string imageURL { get; set; }

    }
}
