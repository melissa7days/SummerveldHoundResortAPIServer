using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class VirtualAdoption
    {
        [Key]
        public int VirtualAdoptionId { get; set; }
        [ForeignKey("Doggo")]
        public int DoggoId { get; set; }
        public bool IsAdopted { get; set; }
        public virtual Doggo Doggo { get; set; }
    }
}
