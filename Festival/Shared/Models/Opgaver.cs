using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Shared.Models
{
    public class Opgaver
    {
        [Required]
        public int OpgaveID { get; set; }

        [Required]
        public string OpgaveNavn { get; set; }

        [Required]
        public string? Beskrivelse { get; set; }

        public int? KategoriID { get; set; }

    }
}