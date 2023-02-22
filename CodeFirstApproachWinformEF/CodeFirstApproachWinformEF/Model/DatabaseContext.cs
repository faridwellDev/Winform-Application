using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproachWinformEF.Model
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Employee>Employees { get; set; } //Here DbSet is Object and Employee as datatype 
        //Data stored in database as in Employees property
    }
}
