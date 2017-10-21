using AirTickets.Data.Models;
using AirTickets.Data.Models.Enums;
using System;
using System.Linq.Expressions;

namespace AirTickets.DataServices.Models
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
                this.Title = flight.Title;
                this.Price = flight.Price;
                this.Duration = flight.Duration;
                this.TravelClass = flight.TravelClass;
                if (flight.Airline != null)
                {
                    this.AirlineId = flight.Airline.Id;
                }

                if (flight.DepartureAirport != null)
                {
                    this.DepartureAirportId = flight.DepartureAirport.Id;
                }

                if (flight.ArrivalAirport != null)
                {
                    this.ArrivalAirportId = flight.ArrivalAirport.Id;
                }
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        public Airline Airline { get; set; }

        public Guid AirlineId { get; set; }

        public Airport DepartureAirport { get; set; }

        public Guid DepartureAirportId { get; set; }

        public Airport ArrivalAirport { get; set; }

        public Guid ArrivalAirportId { get; set; }

        public static Expression<Func<Flight, FlightModel>> Create
        {
            get
            {
                return flight => new FlightModel()
                {
                    Id = flight.Id,
                    Title = flight.Title,
                    Price = flight.Price,
                    Duration = flight.Duration,
                    TravelClass = flight.TravelClass,
                    Airline = flight.Airline,
                    DepartureAirport = flight.DepartureAirport,
                    ArrivalAirport = flight.ArrivalAirport
                };
            }
        }
    }
}
