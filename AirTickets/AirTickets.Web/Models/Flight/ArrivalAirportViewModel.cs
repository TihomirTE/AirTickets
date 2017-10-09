using AirTickets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirTickets.Web.Models.Flight
{
    public class ArrivalAirportViewModel
    {
        public ArrivalAirportViewModel()
        {

        }

        public ArrivalAirportViewModel(ArrivalAirportModel airport)
        {
            if (airport != null)
            {
                //this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.Airlines = airport.Airlines.Select(x => new AirlineViewModel(x)).ToList();
            }
        }

        //public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<AirlineViewModel> Airlines { get; set; }
    }
}