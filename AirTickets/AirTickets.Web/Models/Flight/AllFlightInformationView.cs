using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirTickets.Data.Model.Enum;

namespace AirTickets.Web.Models.Flight
{
    public class AllFlightInformationView
    {
        public AllFlightInformationView()
        {

        }

        public AllFlightInformationView(DepartureAirportViewModel departureAirport, ArrivalAirportViewModel arrivalAirport,
            AirlineViewModel airline, FlightViewModel flight)
        {
            if (departureAirport != null)
            {
                this.DepartureName = departureAirport.Name;
                this.DepartureAirportCode = departureAirport.AirportCode;
            }

            if (arrivalAirport != null)
            {
                this.ArrivalAirport = arrivalAirport.Name;
                this.ArrivalAirportCode = arrivalAirport.AirportCode;
            }

            if (airline != null)
            {
                this.AirlineName = airline.Name;
            }

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

        public string AirlineName { get; set; }

        public string DepartureAirportCode { get; set; }

        public string DepartureName { get; set; }

        public string ArrivalAirportCode { get; set; }

        public string ArrivalAirport { get; set; }
    }
}