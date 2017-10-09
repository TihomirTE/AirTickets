using AirTickets.Web.Models.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models
{
    public class FlightSearchViewModel
    {
        public decimal Price { get; set; }

        public IEnumerable<FlightViewModel> FoundFlights { get; set; }
    }
}