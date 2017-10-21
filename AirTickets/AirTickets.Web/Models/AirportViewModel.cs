using AirTickets.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models
{
    public class AirportViewModel
    {
        public AirportViewModel()
        {

        }

        public AirportViewModel(AirportModel airport)
        {
            if (airport != null)
            {
                this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.DepartureFlights = airport.DepartureFlights.Select(b => new FlightViewModel(b)).ToList();
                this.ArrivalFlights = airport.ArrivalFlights.Select(b => new FlightViewModel(b)).ToList();
            }
        }

       public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<FlightViewModel> DepartureFlights { get; set; }

        public IEnumerable<FlightViewModel> ArrivalFlights { get; set; }
    }
}