using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext() : base("SqlConnStr")
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
