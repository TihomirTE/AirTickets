using AirTickets.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketService ticketService;

        public HomeController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";

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
                return View();
            }

            ViewBag.TheMessage = "Message sent";

            return View();
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "MVC 5 project";

            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return RedirectToAction("Index");
        }
    }
}