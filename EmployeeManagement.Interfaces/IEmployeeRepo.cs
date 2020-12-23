using EmployeeManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public interface IEmployeeRepo
    {
       Task<IEnumerable<Employee>> ReadAllAsync();
    }
}