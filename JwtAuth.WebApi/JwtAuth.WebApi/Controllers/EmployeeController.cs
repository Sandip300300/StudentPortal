using JwtAuth.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _IEmployee;

        private readonly ICompany _company;

        public EmployeeController(IEmployees IEmployee,ICompany company)
        {
            _IEmployee = IEmployee;
            _company = company;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await Task.FromResult(_IEmployee.GetEmployeeDeatils());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employees = await Task.FromResult(_IEmployee.GetEmployeeDetails(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            _IEmployee.AddEmployee(employee);
            return await Task.FromResult(employee);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            try
            {
                _IEmployee.UpdateEmployee(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(employee);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = _IEmployee.DeleteEmployee(id);
            return await Task.FromResult(employee);
            
        }

        private bool EmployeeExists(int id)
        {
            return _IEmployee.CheckEmployee(id);
        }
        [HttpGet("{id}")]
        public string GetName(int id)
        {
            return _company.GetCompanyById(id);
        }
    }
}
