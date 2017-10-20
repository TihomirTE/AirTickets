using AirTickets.DataServices.Contracts;
using AirTickets.DataServices.Models;
using AirTickets.Web.Infrastructure;
using AirTickets.Web.Models;
using Bytes2you.Validation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    [Authorize]
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;
        private readonly IAirlineService airlineService;

        public FlightController(IFlightService flightService, IAirlineService airlineService)
        {
            Guard.WhenArgument(flightService, "bookService").IsNull().Throw();
            Guard.WhenArgument(airlineService, "categoryService").IsNull().Throw();

            this.flightService = flightService;
            this.airlineService = airlineService;
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
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AllFlights()
        {
            //var allAirlineViewModels = this.airlineService.GetAllAirlinesWithFlightsIncluded()
            //                                .Select(c => new AirlineViewModel(c)).ToList();

            var allFlights = this.flightService.GetAllFlights()
                .Select(x => new FlightViewModel(x)).ToList();

            return this.PartialView("_AllFlightsPartial", allFlights);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult FilteredFlights(int price)
        {
            if (price < 0)
            {
                return this.AllFlights();
            }
            else
            {
                var filteredFlights = this.flightService.GetFlightByPrice(price)
                                            .Select(b => new FlightViewModel(b)).ToList();

                return this.PartialView("_FilteredFlightsPartial", filteredFlights);
            }
        }
    }
}