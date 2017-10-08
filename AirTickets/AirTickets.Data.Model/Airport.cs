using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class Airport : DataModel
    {
        private ICollection<Flight> flights;

        public Airport()
        {
            this.flights = new HashSet<Flight>();
        }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public virtual Country Country { get; set; }

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
