using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoContent
    {
        [Key]
        public int DoggoContentId { get; set; }
        [ForeignKey("DoggoAlbum")]
        public int DoggoAlbumId { get; set; }
        public DateTime DoggoContentDateCreated { get; set; }
        public virtual DoggoAlbum DoggoAlbum { get; set; }
    }
}
