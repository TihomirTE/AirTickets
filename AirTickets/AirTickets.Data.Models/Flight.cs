using AirTickets.Data.Models.Enums;
using System;

namespace AirTickets.Data.Models
{
    public class Flight
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        
        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        public Guid AirlineId { get; set; }

        public virtual Airline Airline { get; set; }
    }
}