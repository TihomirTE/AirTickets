using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class DepartureAirport : DataModel
    {
        private IEnumerable<ArrivalAirport> arrivalAirport;

        public DepartureAirport()
        {
            this.arrivalAirport = new HashSet<ArrivalAirport>();
        }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public virtual IEnumerable<ArrivalAirport> ArrivalAirports
        {
            get
            {
                return this.arrivalAirport;
            }
            set
            {
                this.arrivalAirport = value;
            }
        }
    }
}
