using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.BOL;
using EmployeeManagement.DAL;
using EmployeeManagement.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL
{
    public class EmployeeModel : IEmployeeModel
    {

        public IEnumerable<EmployeeBOL> GetMapEmployees(IEnumerable<Employee> employees)
        {
            try
            {
                List<EmployeeBOL> employeesBOL = new List<EmployeeBOL>();

                foreach (var employee in employees)
                {
                    EmployeeBOL employeeBOL = new EmployeeBOL
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Salary = employee.Salary,
                        Department = employee.Department
                    };

                    employeesBOL.Add(employeeBOL);
                }

                return employeesBOL;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeBOL GetMapEmployee(Employee employee)
        {
            try
            {
                EmployeeBOL employeeBOL = new EmployeeBOL
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Salary = employee.Salary,
                    Department = employee.Department
                };
                return employeeBOL;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public Employee GetMapEmployeeBOL(EmployeeBOL employeeBOL)
        {
            try
            {
                Employee employee = new Employee
                {
                    EmployeeId = employeeBOL.EmployeeId,
                    FirstName = employeeBOL.FirstName,
                    LastName = employeeBOL.LastName,
                    Salary = employeeBOL.Salary,
                    Department = employeeBOL.Department
                };

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
