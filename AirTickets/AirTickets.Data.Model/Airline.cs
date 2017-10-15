using AirTickets.Data.Model.Abstracts;
using AirTickets.Data.Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class Airline : DataModel
    {
        private IEnumerable<Flight> flights;

        public Airline()
        {
            this.flights = new HashSet<Flight>();
        }

        [MinLength(ModelConstants.MinNameLenght)]
        [MaxLength(ModelConstants.MaxNameLenght)]
        public string Name { get; set; }

        public Guid? ArrivalAirportId { get; set; }

        public virtual ArrivalAirport ArrivalAirport { get; set; }

        public virtual IEnumerable<Flight> Flights
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
