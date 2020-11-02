using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResortAPIServer.Models
{
    public class Icon
    {
        [Key]
        public int IconId { get; set; }
        public string IconSrcUrl { get; set; }
    }
}
