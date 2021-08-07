using System;
using System.Web.Mvc;

namespace LogInViewModelApp.Controllers
{
    public class Login1Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(String username, String userpassword)
        {
            return Content("<h1>Username: " + username + "</h1>" + "<h1>Password: " + userpassword + "</h1>");
        }
    }
}