using System.Web.Mvc;

namespace LogInViewModelApp.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("<h1>UserName: " + Session["userName"] + "</h1>");
        }
    }
}