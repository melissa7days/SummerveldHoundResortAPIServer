using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoAlbum
    {
        [Key]
        public int DoggoAlbumId { get; set; }
        [ForeignKey("Doggo")]
        public int DoggoId { get; set; }
        public string DoggoAlbumName { get; set; }
        public DateTime DoggoAlbumDateCreated { get; set; }
        public virtual Doggo Doggo { get; set; }
    }
}