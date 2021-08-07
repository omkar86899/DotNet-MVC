using System;
using System.Web.Mvc;
using LogInViewModelApp.Models;

namespace LogInViewModelApp.Controllers
{
    public class Login2Controller : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if(String.IsNullOrEmpty(loginViewModel.UserName) || String.IsNullOrEmpty(loginViewModel.UserPassword))
            {
                loginViewModel.ErrorMsg = "All field should be filled";
                return View(loginViewModel);
            }
            Session["userName"] = loginViewModel.UserName;
            return RedirectToRoute("WelcomeRoute");
        }
    }
}