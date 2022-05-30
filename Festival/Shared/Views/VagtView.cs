using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Festival.Shared.Views

{
    public class VagtView

    {
        [Required]
        public int VagtID { get; set; }

        [Required]
        public DateTime StartTid { get; set; } = DateTime.Now;

        [Required]
        public DateTime SlutTid { get; set; } = DateTime.Now;

        [Required]
        public DateTime Dato { get; set; } = DateTime.Now;

        [Required]
        public string Type { get; set; }

        [Required]
        public int OpgaveID { get; set; }

        [Required]
        public string OpgaveNavn { get; set; }

        [Required]
        public string Beskrivelse { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        public string? Status { get; set; }
    }

}
