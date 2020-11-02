using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoVideo
    {
        [Key]
        public int DoggoVideoId { get; set; }
        [ForeignKey("DoggoContent")]
        public int DoggoContentId { get; set; }
        public string DoggoVideoUrl { get; set; }
        public string DoggoVideoDescription { get; set; }
        public virtual DoggoContent DoggoContent { get; set; }
    }
}
