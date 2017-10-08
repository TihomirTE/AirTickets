using AirTickets.Services.Contracts;
using AirTickets.Web.Models;
using AirTickets.Services.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;

namespace AirTickets.Web.Controllers.Flight
{
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;
        private readonly IDestinationService destinationService;
        //private readonly IMapper mapper;

        public FlightController(IFlightService flightService, IDestinationService destinationService)
        {
            Guard.WhenArgument(flightService, "flightService").IsNull().Throw();
            Guard.WhenArgument(destinationService, "destinationService").IsNull().Throw();

            this.flightService = flightService;
            this.destinationService = destinationService;
            //this.mapper = mapper;
        }

        public ActionResult Details(Guid? id)
        {
            FlightModel flight = this.flightService.GetById(id);

            FlightViewModel viewModel = new FlightViewModel(flight);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult All()
        {
            //var allFlight = this.flightService.GetAll();

            return this.View();
        }

        [HttpGet]
        public ActionResult AllFlights()
        {
            var allFlight = this.flightService.GetAllFlights()
                .Select(x => new FlightViewModel(x)).ToList();

            return this.PartialView("_AllFlights", allFlight);
        }

        [HttpGet]
        public ActionResult GetFlight()
        {
            return this.View(new List<FlightViewModel>());

        }

        [HttpPost]
        public ActionResult Price(decimal price)
        {
            // extract these things in Service


            //model.FoundFlights = flights;

            return this.View();
        }

        public ActionResult Airline(string airline)
        {


            return this.View();
        }

        public ActionResult Destination(string departureCity, string arrivalCity)
        {


            return this.View();
        }

        public ActionResult DestinationAndPrice(string departureCity, string arrivalCity, decimal price)
        {


            return this.View();
        }
    }
}