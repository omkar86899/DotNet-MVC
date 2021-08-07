using Employees.Model;
using System.Collections.Generic;

namespace Employees.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees(int deptId);
    }
}