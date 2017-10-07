using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class Airline : DataModel
    {
        private ICollection<Flight> flights;

        public Airline()
        {
            this.flights = new HashSet<Flight>();
        }

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
