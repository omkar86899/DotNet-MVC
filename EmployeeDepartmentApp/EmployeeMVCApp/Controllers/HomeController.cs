using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVCApp.Models.ViewModels;
using Employees.Model;
using Employees.Services;

namespace EmployeeMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;
        public HomeController()
        {
            _employeeService = new EmployeeService();
        }

        public ActionResult Index()
        {
            DisplayViewModel vm = new DisplayViewModel();
            vm.DeptNames = new List<Department>();
            vm.DeptNames.Add(new Department { DeptName="Acounting", DeptNo = 10 });
            vm.DeptNames.Add(new Department { DeptName = "Research", DeptNo = 20 });
            vm.DeptNames.Add(new Department { DeptName = "Sales", DeptNo = 30 });
            vm.DeptNames.Add(new Department { DeptName = "Operations", DeptNo = 40 });
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(DisplayViewModel vm)
        {
            List<SelectListItem> deptNames = ViewBag.DeptNames;
            vm.Employees = _employeeService.GetEmployees(vm.DeptId);
            return View(vm);
        }
    }
}