using System;
using System.Web.Mvc;

namespace SessionApp.Controllers
{
    public class ApplicationController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Application["count"] == null)
            {
                HttpContext.Application["count"] = 0;
                ViewBag.oldValue = 0;
                HttpContext.Application["count"] = Convert.ToInt32(Session["count"]) + 1;
                return View();
            }
            ViewBag.oldValue = HttpContext.Application["count"];
            HttpContext.Application["count"] = Convert.ToInt32(HttpContext.Application["count"]) + 1;
            return View();
        }
    }
}