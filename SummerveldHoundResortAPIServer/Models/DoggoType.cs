using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoType
    {
        [Key]
        public int DoggoTypeId { get; set; }
        [ForeignKey("Doggo")]
        public int DoggoId { get; set; }
        public string DoggoTypeStatus { get; set; }
        public virtual Doggo Doggo { get; set; }
    }
}
