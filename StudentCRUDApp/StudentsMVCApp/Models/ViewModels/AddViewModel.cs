using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentsMVCApp.Models.ViewModels
{
    public class AddViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public String Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter Your Roll Number")]
        [Range(1,int.MaxValue, ErrorMessage = "Roll Number Should be greater 0")]
        public int RollNo
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter Your Cgpa")]
        [Range(1, 10, ErrorMessage = "CGPA Should between 1 to 10")]
        public double Cgpa
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