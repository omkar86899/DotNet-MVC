using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionApp.Controllers
{
    public class SessionController: Controller
    {
        public ActionResult Index()
        {
            if(Session["count"] == null)
            {
                Session["count"] = 0;
                ViewBag.oldValue = 0;
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                return View();
            }
            ViewBag.oldValue = Session["count"];
            Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            return View();
        }
    }
}