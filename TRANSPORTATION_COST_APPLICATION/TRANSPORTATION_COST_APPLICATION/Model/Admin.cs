using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRANSPORTATION_COST_APPLICATION.Model
{
    internal class Admin
    {

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

    }
}
