using EmployeeManagement.BOL;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL.Interfaces
{
     public interface IEmployeeModel
    {
        IEnumerable<EmployeeBOL> GetMapEmployees(IEnumerable<Employee> employee);

        EmployeeBOL GetMapEmployee(Employee employee);

        Employee GetMapEmployeeBOL(EmployeeBOL employeeBOL);
    }
}
