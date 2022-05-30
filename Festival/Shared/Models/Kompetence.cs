using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Festival.Shared.Models
{
    public class Kompetence
    {
        [Required]
        public int KompetenceID { get; set; }

        [Required]
        public string Type { get; set; }

    }
}