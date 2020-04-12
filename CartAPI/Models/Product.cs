using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
        public string Photo{ get; set; }

    }
}
