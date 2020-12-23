using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace EmployeeManagement.DAL
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context) => _context = context;

        private static readonly Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = "";
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
        public async Task<IEnumerable<Employee>> ReadAllAsync()
        {
            try
            {
                IDatabase cache = Connection.GetDatabase();
                var cacheKey = "Employees";
                List<Employee> cacheEmployees = null;
                var serializedData = cache.StringGet(cacheKey);

                if(!string.IsNullOrEmpty(serializedData))
                {
                    cacheEmployees = JsonConvert.DeserializeObject<List<Employee>>(serializedData);
                    return cacheEmployees;

                }
                else
                {
                    var employees = await _context.Employees.ToListAsync();
                    cache.StringSet(cacheKey, JsonConvert.SerializeObject(employees));

                    return employees;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> ReadOneAsync(string employeeId)
        {
            try
            {

                IDatabase cache = Connection.GetDatabase();
                var cacheKey = $"Employee_{employeeId}";
                Employee cacheEmployee;
                var serializedData = cache.StringGet(cacheKey);

                if (!string.IsNullOrEmpty(serializedData))
                {
                    cacheEmployee = JsonConvert.DeserializeObject<Employee>(serializedData);
                    return cacheEmployee;

                }
                else
                {
                    var employee = await  _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                    cache.StringSet(cacheKey, JsonConvert.SerializeObject(employee));

                    return employee;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> DeleteAsync(string employeeId)
        {
            try
            {
                var entity = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                if(entity == null)
                {
                    return null;
                }
                else
                {
                    _context.Employees.Remove(entity);
                    IDatabase cache = Connection.GetDatabase();
                    cache.KeyDelete("Employees");
                    cache.KeyDelete($"Employee_{employeeId}"); 
                    await _context.SaveChangesAsync();
                    return entity;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public async Task AddAsync(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
            }

            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> UpdateAsync(string employeeId, Employee employee)
        {
            try
            {
                var entity = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

                if (entity == null)
                {
                    return null;
                }
                else
                {
                    entity.FirstName = employee.FirstName;
                    entity.LastName = employee.LastName;
                    entity.Salary = employee.Salary;
                    entity.Department = employee.Department;
                    await _context.SaveChangesAsync();

                    return entity;
                }
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
