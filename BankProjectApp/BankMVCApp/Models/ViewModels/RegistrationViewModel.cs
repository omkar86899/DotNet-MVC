using System;
using System.ComponentModel.DataAnnotations;

namespace BankMVCApp.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [NoSpace(ErrorMessage = "Don't use space in Name")]
        [Required(ErrorMessage = "Please Enter the UserName")]
        public String UserName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter the Balance")]
        [Range(500,double.MaxValue, ErrorMessage ="Balance Should Be Greater Than 500")]
        public double Balance
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter the Password")]
        [MinLength(8, ErrorMessage ="Password Should Be Atleast 8 Characters Long")]
        public String Password
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please Enter the Confirm Password")]
        public String ConfirmPassword
        {
            get;
            set;
        }


        public String PasswordNotMatchedError
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