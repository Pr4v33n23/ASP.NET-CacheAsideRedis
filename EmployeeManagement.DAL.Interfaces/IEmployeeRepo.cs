using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> ReadAllAsync();
        Task<Employee> ReadOneAsync(string employeeId);
        Task<Employee> DeleteAsync(string employeeId);
        Task AddAsync(Employee employee);
        Task<Employee> UpdateAsync(string employeeId, Employee employee);

    }
}
