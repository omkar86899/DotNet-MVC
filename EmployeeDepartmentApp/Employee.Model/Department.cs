using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class Department
    {
        public List<Employee> Employees
        {
            get;
            set;
        }

        public int DeptNo
        {
            get;
            set;
        }

        public String DeptName
        {
            get;
            set;
        }

        public String Location
        {
            get;
            set;
        }
    }
}
