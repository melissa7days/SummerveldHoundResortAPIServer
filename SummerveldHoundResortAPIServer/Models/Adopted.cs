using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class Adopted
    {
        [Key]
        public int AdoptedId { get; set; }
        [ForeignKey("VirtualAdoption")]
        public int VirtualAdoptionId { get; set; }
        public DateTime AdoptedDate { get; set; }
        public string Pawrents { get; set; }
        public DateTime AdoptedDateCreated { get; set; }
        public virtual VirtualAdoption VirtualAdoption { get; set; }
    }
}
