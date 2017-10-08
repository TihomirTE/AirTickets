using AirTickets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models.Flight
{
    public class AirportViewModel
    {
        public AirportViewModel()
        {

        }

        public AirportViewModel(AirportModel airport)
        {
            this.Id = airport.Id;
            this.Name = airport.Name;
            this.AirportCode = airport.AirportCode;
            this.Flights = airport.Flights.Select(x => new FlightViewModel(x)).ToList();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<FlightViewModel> Flights { get; set; }
    }
}