using AirTickets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models.Flight
{
    public class DepartureAirportViewModel
    {
        public DepartureAirportViewModel()
        {

        }

        public DepartureAirportViewModel(DepartureAirportModel airport)
        {
            if (airport != null)
            {
                //this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.ArrivalAirports = airport.ArrivalAirports.Select(x => new ArrivalAirportViewModel(x)).ToList();
            }
        }

        //public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<ArrivalAirportViewModel> ArrivalAirports { get; set; }
    }
}