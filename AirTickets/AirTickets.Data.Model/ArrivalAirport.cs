using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class ArrivalAirport : DataModel
    {
        private ICollection<Airline> airlines;

        public ArrivalAirport()
        {
            this.airlines = new HashSet<Airline>();
        }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public Guid DepartureAirportId { get; set; }

        public virtual DepartureAirport DepartureAirport { get; set; }

        public virtual ICollection<Airline> Airlines
        {
            get
            {
                return this.airlines;
            }
            set
            {
                this.airlines = value;
            }
        }
    }
}
