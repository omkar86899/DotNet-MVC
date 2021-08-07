using System;
using System.ComponentModel.DataAnnotations;

namespace BankMVCApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter the UserName")]
        public String UserName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter the Password")]
        public String Password
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