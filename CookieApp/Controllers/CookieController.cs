using System;
using System.Web;
using System.Web.Mvc;

namespace CookieApp.Controllers
{
    public class CookieController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetCookie()
        {
            HttpCookie cookie = new HttpCookie("ColorCookie");
            cookie["favColor"] = "red";
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(cookie);
            return View();
        }

        public ActionResult GetCookie()
        {
            if (Request.Cookies["ColorCookie"]==null)
            {
                return Content("<h1>Cookie Not Found</h1>");
            }
            return View();
        }
    }
}