using AirTickets.DataServices.Contracts;
using AirTickets.Web.App_GlobalResources;
using AirTickets.Web.Models;
using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirportService airportService;

        public HomeController(IAirportService airportService)
        {
            Guard.WhenArgument(airportService, "airportService").IsNull().Throw();

            this.airportService = airportService;

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AllAirports()
        {
            var allAirports = this.airportService.GetAllAirportsSortedByName()
                .Select(x => new AirportViewModel(x)).ToList();

            return this.PartialView("_AllAirports", allAirports);
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