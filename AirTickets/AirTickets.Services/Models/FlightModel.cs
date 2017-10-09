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
                //this.Id = flight.Id;
                
                this.Price = flight.Price;
                this.Duration = flight.Duration;
                this.TravelClass = flight.TravelClass;
                if (flight.Airline != null)
                {
                    this.AirlineId = flight.Airline.Id;
                }

            }
        }

        //public Guid Id { get; private set; }

        //public DepartureAirport DepartureAirport { get; private set; }

        //public DepartureAirport ArrivalAirport { get; private set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        public Guid AirlineId { get; set; }

        public AirlineModel Airline { get; set; }


        public static Expression<Func<Flight, FlightModel>> Create
        {
            get
            {
                return flight => new FlightModel()
                {
                    //Id = flight.Id,
                    //DepartureAirport = flight.DepartureAirport,
                    //ArrivalAirport = flight.ArrivalAirport,
                    Price = flight.Price,
                    //Airline = flight.Airline,
                    TravelClass = flight.TravelClass,
                    Duration = flight.Duration,

                };
            }
        }
    }
}
