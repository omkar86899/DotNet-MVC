using System;

namespace LogInViewModelApp.Models
{
    public class LoginViewModel
    {
        public String UserName
        {
            get;
            set;
        }
        public String UserPassword
        {
            get;
            set;
        }

        public String ErrorMsg
        {
            get;
            set;
        }
    }
}