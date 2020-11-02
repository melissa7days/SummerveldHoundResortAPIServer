using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoPhoto
    {
        [Key]
        public int DoggoPhotoId { get; set; }
        [ForeignKey("DoggoContent")]
        public int DoggoContentId { get; set; }
        public string DoggoPhotoUrl { get; set; }
        public string DoggoPhotoDescription { get; set; }
        public virtual DoggoContent DoggoContent { get; set; }
    }
}
