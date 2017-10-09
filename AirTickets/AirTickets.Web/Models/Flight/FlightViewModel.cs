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
            //    this.Id = flight.Id;
            //    this.DepartureCity = flight.DepartureAirport;
            //    this.ArrivalCity = flight.ArrivalAirport;
                this.Price = flight.Price;
                this.Airline = flight.Airline;
                this.TravelClass = flight.TravelClass;
            }
        }

        //public Guid Id { get; private set; }

        //public DepartureAirport DepartureCity { get; private set; }

        //public DepartureAirport ArrivalCity { get; private set; }

        public decimal Price { get; private set; }

        public AirlineModel Airline { get; private set; }

        public TravelClass TravelClass { get; private set; }

        //[Display(Name ="Total sum = ")]
        //public decimal Price { get; set; }

        ////public void CreateMappings(IMapperConfigurationExpression configuration)
        ////{
            
        ////}

        //public TravelClass TravelClass { get; set; }

    }
}