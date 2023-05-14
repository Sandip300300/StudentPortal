namespace JwtAuth.WebApi.Models
{
    public interface IEmployees
    {
        public List<Employee> GetEmployeeDeatils();
        public Employee GetEmployeeDetails(int id);
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);
        public bool CheckEmployee(int id);
    }
}
