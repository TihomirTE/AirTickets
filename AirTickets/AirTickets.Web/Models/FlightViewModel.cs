using AirTickets.Data.Models.Enums;
using AirTickets.DataServices.Models;
using System;

namespace AirTickets.Web.Models
{
    public class FlightViewModel
    {
        public FlightViewModel()
        {
        }

        public FlightViewModel(FlightModel flight)
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
                    this.Airline = flight.Airline.Name;
                }

                if (flight.DepartureAirport != null)
                {
                    this.DepartureAirport = flight.DepartureAirport.Name;
                }

                if (flight.ArrivalAirport != null)
                {
                    this.ArrivalAirport = flight.ArrivalAirport.Name;
                }
            }
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        public string Airline { get; set; }

        public string DepartureAirport { get; set; }

        public string ArrivalAirport { get; set; }


        //public Guid AirlineId { get; set; }
    }
}