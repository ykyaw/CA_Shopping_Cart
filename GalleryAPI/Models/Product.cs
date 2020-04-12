using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.Models
{
    public class Product
    {
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        
        [MaxLength(128)]
        public string Photo{ get; set; }

    }
}
