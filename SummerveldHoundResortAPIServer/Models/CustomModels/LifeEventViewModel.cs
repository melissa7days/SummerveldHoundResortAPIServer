using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models.CustomModels
{
    public class LifeEventViewModel
    {
        [Key]
        public int LifeEventId { get; set; }
        public int DoggoId { get; set; }
        public int IconId { get; set; }
        public string LifeEventName { get; set; }
        public string LifeEventDate { get; set; }
        public DateTime LifeEventDateCreated { get; set; }
        public string DoggoName { get; set; }
        public string DoggoProfilePic { get; set; }
        public string DoggoDescription { get; set; }
        public string DoggoNickname { get; set; }
        public DateTime DoggoDateCreated { get; set; }
        public string IconSrcUrl { get; set; }



          
    }
}
