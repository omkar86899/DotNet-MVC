using Employees.Model;
using EmployeesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public List<Employee> GetEmployees(int deptId)
        {
            return _employeeRepository.GetEmployees(deptId);
        }
    }
}
