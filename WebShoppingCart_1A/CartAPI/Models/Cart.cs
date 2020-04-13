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

        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MaxLength(36)]
        public string userId { get; set; }

        [Required]
        [MaxLength(36)]
        public string productId { get; set; }


        //// we may not need this column in table, since every column would be quantity=1 
        //// NotMapped= it is an attribute of this model, but  it wont show up in SQL table
        //[NotMapped]
        //public int productQuantity { get; set; }





    }
}
