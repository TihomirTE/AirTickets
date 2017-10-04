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
        private ICollection<Flight> tickets;

        public Airline()
        {
            this.tickets = new HashSet<Flight>();
        }

        public string Name { get; set; }

        public virtual ICollection<Flight> Tickets
        {
            get
            {
                return this.tickets;
            }
            set
            {
                this.tickets = value;
            }
        }
    }
}
