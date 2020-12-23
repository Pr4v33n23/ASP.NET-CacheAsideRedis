using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.BLL.Interfaces;
using EmployeeManagement.BOL;
using EmployeeManagement.DAL;
using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Entities;

namespace EmployeeManagement.BLL
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IEmployeeModel _employeeModel;

        public EmployeeLogic() { }
        public EmployeeLogic(IEmployeeRepo employeeRepo, IEmployeeModel employeeModel)
        {
            _employeeRepo = employeeRepo;
            _employeeModel = employeeModel;
        }

        //Get/id
        public async Task<EmployeeBOL> GetEmployeeByIdAsync(string employeeId)
        {
            try
            {
                var employee = await _employeeRepo.ReadOneAsync(employeeId);

                if(employee == null)
                {
                    return null;
                }
                else
                {
                    return _employeeModel.GetMapEmployee(employee);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<IEnumerable<EmployeeBOL>> GetEmployeesAsync()
        {
            try
            {
                var employees = await _employeeRepo.ReadAllAsync();

                return _employeeModel.GetMapEmployees(employees);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<EmployeeBOL> DeleteEmployeeByIdAsync(string employeeId)
        {
            try
            {
                var employee = await _employeeRepo.DeleteAsync(employeeId);

                if (employee == null)
                {
                    return null;
                }
                else
                {
                    return _employeeModel.GetMapEmployee(employee);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task AddEmployeeAsync(EmployeeBOL employeeBOL)
        {
            try
            {
                var employee = _employeeModel.GetMapEmployeeBOL(employeeBOL);
                await _employeeRepo.AddAsync(employee);
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeBOL> UpdateEmployeeAsync(string employeeId, EmployeeBOL employeeBOL)
        {

            try
            {
                var employee = await _employeeRepo.UpdateAsync(employeeId, _employeeModel.GetMapEmployeeBOL(employeeBOL));

                if (employee == null)
                {
                    return null;
                }
                else
                {
                    return _employeeModel.GetMapEmployee(employee);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
