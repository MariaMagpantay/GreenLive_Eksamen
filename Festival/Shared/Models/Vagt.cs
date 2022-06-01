using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Festival.Shared.Models
{
    public class Vagt
    {
        [Required]
        public int VagtID { get; set; }

        [Required]
        public int OpgaveID { get; set; }

        [Required]
        public DateTime StartTid { get; set; }
        [Required]
        public DateTime SlutTid { get; set; }

        [Required]
        public DateTime Dato { get; set; } = DateTime.Now;

        public int? PersonID { get; set; }

        [Required]
        public string VagtType { get; set; }

        public string? Status { get; set; }

        public DateTime? Changed { get; set; }
    }

}