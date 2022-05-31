using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Shared.Views
{
    public class PersonKompetence
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
        public int? KompetenceID { get; set; }

        [Required]
        public string? Type { get; set; }
    }
}
