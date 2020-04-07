using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class ExampleBooking
    {
        // By convention, the Id property of a model is the Primary Key 
        [MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        //By convention, the <Model-Name>Id property of denotes a Foreign Key 
        [Required] // means the column cannot be NULL 
        [MaxLength(36)] //mean max length is K characters long
        public string MovieId { get; set; }

        public DateTime UtcTimestamp { get; set; }

        //Navigational Properties
        //it will be automatically retrieved while booking data retrieve
        public virtual ExampleMovie Movie { get; set; }

    }
}
