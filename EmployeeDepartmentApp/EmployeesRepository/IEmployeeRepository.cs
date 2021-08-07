using Employees.Model;
using System.Collections.Generic;

namespace EmployeesRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees(int deptId);
    }
}