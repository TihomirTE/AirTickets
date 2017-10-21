using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Models
{
    public class Airport
    {
        private ICollection<Flight> departureFlights;
        private ICollection<Flight> arrivalFlights;

        public Airport()
        {
            this.departureFlights = new HashSet<Flight>();
            this.arrivalFlights = new HashSet<Flight>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public virtual ICollection<Flight> DepartureFlights
        {
            get
            {
                return this.departureFlights;
            }
            set
            {
                this.departureFlights = value;
            }
        }

        public virtual ICollection<Flight> ArrivalFlights
        {
            get
            {
                return this.arrivalFlights;
            }
            set
            {
                this.arrivalFlights = value;
            }
        }
    }
}
