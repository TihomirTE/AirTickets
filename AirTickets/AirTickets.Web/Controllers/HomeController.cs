using AirTickets.Services.Contracts;
using AirTickets.Web.Models;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlightService flightService;

        public HomeController(IFlightService ticketService)
        {
            this.flightService = ticketService;
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

                return PartialView("_MessageContact");
            }

            ViewBag.TheMessage = "Message sent";

            return PartialView("_MessageContact");
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
        [HttpGet]
        public ActionResult GetFlight()
        {
            return this.View(new List<FlightViewModel>());
            
        }

        [HttpPost]
        public ActionResult GetFlight(decimal price)
        {
            // extract these things in Service

            var flights = this.flightService
                .GetAll()
                .ProjectTo<FlightViewModel>()
                .Where(x => x.Price > price)
                .ToList();

            //model.FoundFlights = flights;

            return this.View(flights);
        }
    }
}