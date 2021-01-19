using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class LifeEvent
    {
        [Key]
        public int LifeEventId { get; set; }
        [ForeignKey("Doggo")]
        public int DoggoId { get; set; }
        [ForeignKey("Icon")]
        public int IconId { get; set; }
        public string LifeEventName { get; set; }
        public string LifeEventDate { get; set; }
        public DateTime LifeEventDateCreated { get; set; }
        public virtual Doggo Doggo { get; set; }
        public virtual Icon Icon { get; set; }
    }
}
