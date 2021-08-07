using System;
using System.Web.Mvc;

namespace WelcomeMvcCsApp.Controllers
{
    public class HomeController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Welcome1(String developer)
        {
            if (String.IsNullOrEmpty(developer))
            {
                ViewBag.developer = "omkar";
                return View();
            }
            ViewBag.developer = developer;
            return View();
        }

        public ActionResult Welcome2(String developerName)
        {
            if (String.IsNullOrEmpty(developerName))
            {
                return Content("<h1>Developer Name: Omkar</h1>");
            }
            return Content("<h1>Developer Name: " + developerName + "</h1>");
        }

        public ActionResult Welcome3(String developerName, String company)
        {
            var employee = new 
            {
                name = "",
                company = ""
            };
            if (String.IsNullOrEmpty(developerName) || String.IsNullOrEmpty(company))
            {
                employee = new
                {
                    name = "omkar",
                    company = "AurionPro"
                };
                return Json(employee, JsonRequestBehavior.AllowGet);
            }
            employee = new
            { 
                name = developerName,
                company = company
            };
            return Json(employee, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(String username, String password)
        {
            ViewBag.username = username;
            ViewBag.password = password;
            return View();
        }

    }
}