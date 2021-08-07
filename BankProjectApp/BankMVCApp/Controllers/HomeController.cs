using System;
using System.Web.Mvc;
using BankMVCApp.Models.ViewModels;
using BankProjectAppLib.Service;
using BankProjectAppLib.Data;

namespace BankMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private IBankingService _bankingService;

        public HomeController(IBankingService bankingService)
        {
            _bankingService = bankingService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            Account account = _bankingService.GetAccountDetails(loginViewModel.UserName);
            if (!account.Password.Equals(loginViewModel.Password))
            {
                loginViewModel.Error = "Username or Password is Invalid";
                return View(loginViewModel);
            }
            Session["Name"] = loginViewModel.UserName;
            return RedirectToAction("index", "InternetBanking");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel();
            registrationViewModel.PasswordNotMatchedError = "";
            registrationViewModel.Error = "";
            return View(registrationViewModel);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel registrationViewModel)
        {
            registrationViewModel.Error = "";
            registrationViewModel.PasswordNotMatchedError = "";
            if (!this.ModelState.IsValid)
            {
                return View(registrationViewModel);
            }
            if (!registrationViewModel.ConfirmPassword.Equals(registrationViewModel.Password))
            {
                registrationViewModel.PasswordNotMatchedError = "Confim Password Should be Match to Password";
                return View(registrationViewModel);
            }

            try
            {
                Account account = new Account(registrationViewModel.UserName, registrationViewModel.Balance, registrationViewModel.Password);
                _bankingService.CreateAccount(account);
            }
            catch (Exception exception)
            {
                registrationViewModel.Error = exception.Message+" Please try login";
                return View(registrationViewModel);
            }
            return RedirectToAction("index", "Home");
        }
    }
}