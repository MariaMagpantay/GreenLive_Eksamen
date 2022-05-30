using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.Shared.Models
{
    public class RolleType
    {
        [Required]
        public int RolleID { get; set; }

        [Required]
        public string Rolle { get; set; }




    }
}
