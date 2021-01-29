using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Models
{
    public class Details
    {
        [Key]
        public Guid UUID { get; set; }
        public Guid MOTHER_UUID { get; set; }
        public string TODO { get; set; }
    }
}
