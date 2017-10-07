using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTickets.Data.Model.Enum;
using System.Linq.Expressions;

namespace AirTickets.Services.Models
{
    public class FlightModel
    {
        public FlightModel()
        {
        }

        public FlightModel(Flight flight)
        {
            if (flight != null)
            {
                this.Id = flight.Id;
                this.DepartureAirport = flight.DepartureAirport;
                this.ArrivalAirport = flight.ArrivalAirport;
                this.Price = flight.Price;
                //this.Airline = flight.Airline;
                this.TravelClass = flight.TravelClass;
            }
        }

        public Guid Id { get; private set; }

        public Airport DepartureAirport { get; private set; }

        public Airport ArrivalAirport { get; private set; }

        public decimal Price { get; private set; }

        public AirlineModel Airline { get; private set; }

        public TravelClass TravelClass { get; private set; }

        public static Expression<Func<Flight, FlightModel>> Create
        {
            get
            {
                return flight => new FlightModel()
                {
                    Id = flight.Id,
                    DepartureAirport = flight.DepartureAirport,
                    ArrivalAirport = flight.ArrivalAirport,
                    Price = flight.Price,
                    //Airline = flight.Airline,
                    TravelClass = flight.TravelClass
                };
            }
        }
    }
}
