using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSPORTATION_COST_APPLICATION.Model
{
    internal class Accountant
    {
        [Required]
        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string LicenseState { get; set; }


    }
}
