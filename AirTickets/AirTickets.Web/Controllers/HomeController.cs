using AirTickets.Web.App_GlobalResources;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = GlobalResources.ViewAboutMessage;

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble ? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // TODO: send message to adminastrator
            if (message == string.Empty)
            {
                ViewBag.TheMessage = "Message can not be empty! Try again!";

                return PartialView("_MessageContact");
            }

            ViewBag.TheMessage = "Message sent";

            return PartialView("_MessageContact");
        }
    }
}