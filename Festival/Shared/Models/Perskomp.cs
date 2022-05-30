using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Festival.Shared.Models
{
    public class Perskomp
    {
        [Required]
        public int PersKompID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        public int KompetenceID { get; set; }

    }
}
