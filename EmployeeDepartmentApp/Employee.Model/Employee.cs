using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class Employee
    {
        public int EmpNo
        {
            get;
            set;
        }

        public String EmpName
        {
            get;
            set;
        }

        public String Job
        {
            get;
            set;
        }

        public int Mgr
        {
            get;
            set;
        }

        public DateTime HireDate
        {
            get;
            set;
        }

        public double Salary
        {
            get;
            set;
        }

        public double Comm
        {
            get;
            set;
        }

        public int DeptNo
        {
            get;
            set;
        }
    }
}
