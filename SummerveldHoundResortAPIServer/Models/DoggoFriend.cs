using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class DoggoFriend
    {
        [Key]
        public int DoggoFriendId { get; set; }
        [ForeignKey("DoggoType")]
        public int DoggoTypeId { get; set; }
        public virtual DoggoType DoggoType { get; set; }
    }
}
