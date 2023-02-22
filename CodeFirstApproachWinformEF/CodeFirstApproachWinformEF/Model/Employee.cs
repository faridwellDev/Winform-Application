using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproachWinformEF.Model
{
    internal class Employee
    {
        [Key] //Key is an annotation here it makes Id as primary key
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Gender { get; set; }  
        public int Age { get; set; }
        public string Designation { get; set; }
    }
}
