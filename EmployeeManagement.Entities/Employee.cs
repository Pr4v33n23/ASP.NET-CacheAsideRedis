using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "EmployeeID is required.")]
        public string EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

    }
}
