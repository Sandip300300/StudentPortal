using JwtAuth.WebApi.Models;
using JWTAuth.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace JwtAuth.WebApi.Repository
{
    public class EmployeeRepository : IEmployees
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckEmployee(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _context.Employees.Find(id);

                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Employee> GetEmployeeDeatils()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                Employee? employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
