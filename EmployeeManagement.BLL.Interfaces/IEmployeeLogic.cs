using EmployeeManagement.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL.Interfaces
{
    public interface IEmployeeLogic
    {
        Task<IEnumerable<EmployeeBOL>> GetEmployeesAsync();
        Task<EmployeeBOL> GetEmployeeByIdAsync(string employeeId);
        Task<EmployeeBOL> DeleteEmployeeByIdAsync(string employeeId);
        Task AddEmployeeAsync(EmployeeBOL employeeBOL);
        Task<EmployeeBOL> UpdateEmployeeAsync(string employeeId, EmployeeBOL employeeBOL);

    }
}
