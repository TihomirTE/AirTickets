using AirTickets.DataServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirTickets.Web.Models
{
    public class AirlineViewModel
    {
        public AirlineViewModel()
        {
        }

        public AirlineViewModel(AirlineModel airline)
        {
            this.Name = airline.Name;
            this.Flights = airline.Flights.Select(b => new FlightViewModel(b)).ToList();
        }

        public string Name { get; set; }

        public IEnumerable<FlightViewModel> Flights { get; set; }
    }
}