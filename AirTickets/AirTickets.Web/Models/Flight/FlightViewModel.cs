using AirTickets.Data.Model;
using AirTickets.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirTickets.Data.Model.Enum;
using System.ComponentModel.DataAnnotations;
using AirTickets.Services.Models;

namespace AirTickets.Web.Models.Flight
{
    public class FlightViewModel //IMap<Flight> //ICustomMappings
    {
        public FlightViewModel()
        {

        }

        public FlightViewModel(FlightModel flight)
        {
            if (flight != null)
            {
                this.Price = flight.Price;
                this.Duration = flight.Duration;
                this.TravelClass = flight.TravelClass;
            }
        }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        //[Display(Name ="Total sum = ")]
        //public decimal Price { get; set; }

        ////public void CreateMappings(IMapperConfigurationExpression configuration)
        ////{

        ////}
    }
}