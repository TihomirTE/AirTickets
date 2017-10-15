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
using AirTickets.Web.Models.Flight;

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
            //var allFlight = this.flightService.GetAllFlights()
            //    .Select(x => new FlightViewModel(x)).ToList();

            var allFlight = this.flightService.GetAllFlights()
                        .Select(x => new FlightViewModel(x))
                        .ToList();

            return this.PartialView("_AllFlights", allFlight);
        }

        public ActionResult FilterFlights(int searchTerm)
        {
            if (searchTerm <= 0)
            {
                return this.AllFlights();
            }
            else
            {
                var filterFlights = this.flightService.GetFlightsByPrice(searchTerm)
                    .Select(b => new FlightViewModel(b))
                    .ToList();

                return this.PartialView("_FilterFlightsPartial", filterFlights);
            }
        }

        public ActionResult FilterFlightByDepartureAndArrivalAirport(string departure, string arrival)
        {
            var flights = this.destinationService.ASearchllFlightsWithDepartureAndDestination(departure, arrival)
                .Where(x => x.Name == departure)
                .Select(y => new DepartureAirportViewModel(y))
                .ToList();

            return this.PartialView("_FilterFlightsPartial", flights);
        }

        public ActionResult DestinationAndPrice(string departureCity, string arrivalCity, decimal price)
        {


            return this.View();
        }
    }
}