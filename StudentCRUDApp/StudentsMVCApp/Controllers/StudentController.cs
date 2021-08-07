using Newtonsoft.Json;
using Students.Model;
using Students.Service;
using StudentsMVCApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentsMVCApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            DisplayViewModel vm = new DisplayViewModel();
            vm.Students = _studentService.Get();
            vm.Count = _studentService.Count();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddViewModel vm = new AddViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel vm)
        {
            Student student;
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                student = new Student(vm.RollNo, vm.Name, vm.Cgpa);
                _studentService.Add(student);
            }catch(Exception exception)
            {
                vm.Error = exception.Message;
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }
    }
}