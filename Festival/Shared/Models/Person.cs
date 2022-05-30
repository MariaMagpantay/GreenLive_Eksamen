using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Shared.Models
{
    public class Person
    {
        [Required]
        public int PersonID { get; set; }

        [Required]
        public string PersonNavn { get; set; }

        [Required]
        public string PersonTlf { get; set; }

        [Required]
        public string PersonEmail { get; set; }

        [Required]
        public DateTime PersonFoedselsdato { get; set; } = DateTime.Now;

        [Required]
        public int RolleID { get; set; }

        [Required]
        public int TeamID { get; set; }
    }
}
