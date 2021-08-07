using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationDataAnnotationApp.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="Please Enter Name")]
        public String Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please enter correct email")]
        public String Email
        {
            get;
            set;
        }

        [Range(18,25,ErrorMessage = "Enter Valid Age")]
        public int Age
        {
            get;
            set;
        }

        [Range(15001, 100000000,ErrorMessage ="Enter Valid Salary")]
        public double Salary
        {
            get;
            set;
        }
    }
}