using AirTickets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models.Flight
{
    public class AirlineViewModel
    {
        public AirlineViewModel()
        {

        }

        public AirlineViewModel(AirlineModel airline)
        {
            if (airline != null)
            {
                //this.Id = airline.Id;
                this.Name = airline.Name;
                this.Flights = airline.Flights.Select(x => new FlightViewModel(x)).ToList();
            }
        }

        //public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<FlightViewModel> Flights { get; set; }

    }
}