using Employees.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMVCApp.Models.ViewModels
{
    public class DisplayViewModel
    {
        public List<Employee> Employees
        {
            get;
            set;
        }

        public int DeptId
        {
            get;
            set;
        }

        public List<Department> DeptNames
        {
            get;
            set;
        }

        public String DeptName
        {
            get;
            set;
        }

        public String Error
        {
            get;
            set;
        }
    }
}