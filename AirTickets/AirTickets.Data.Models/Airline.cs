using System;
using System.Collections.Generic;

namespace AirTickets.Data.Models
{
    public class Airline
    {
        private ICollection<Flight> flights;

        public Airline()
        {
            this.flights = new HashSet<Flight>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Flight> Flights
        {
            get
            {
                return this.flights;
            }
            set
            {
                this.flights = value;
            }
        }
    }
}