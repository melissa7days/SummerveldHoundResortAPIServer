using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class Doggo
    {
        [Key]
        public int DoggoId { get; set; }
        public string DoggoName { get; set; }
        public string DoggoProfilePic { get; set; }
        public string DoggoDescription { get; set; }
        public string DoggoNickname { get; set; }
        public DateTime DoggoDateCreated { get; set; }
    }
}
