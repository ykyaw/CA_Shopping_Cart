using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.Models
{
    public class PurchaseActivationCode
    {
        public string Id { set; get; }
        public string PurchaseHistoryId { set; get; }
        public string ActivationCode { get; set; }
    }
}
