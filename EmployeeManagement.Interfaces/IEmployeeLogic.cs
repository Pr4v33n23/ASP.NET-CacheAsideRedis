using EmployeeManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL
{
    public interface IEmployeeLogic
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}