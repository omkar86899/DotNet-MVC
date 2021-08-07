using Students.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsMVCApp.Models.ViewModels
{
    public class DisplayViewModel
    {
        public int Count
        {
            get;
            set;
        }

        public List<Student> Students
        {
            get;
            set;
        }
    }
}