using System;
using System.Web.Mvc;
using RegistrationDataAnnotationApp.Models.ViewModels;

namespace RegistrationDataAnnotationApp.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Index(RegistrationViewModel registrationViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(registrationViewModel);
            }
            String thankYouMsg = "Thank you " + registrationViewModel.Name + " for registration will get back to you on " + registrationViewModel.Email;
            return Content(thankYouMsg);
        }
    }
}