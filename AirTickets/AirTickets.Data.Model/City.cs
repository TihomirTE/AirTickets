using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class City :  DataModel
    {
        private ICollection<Airport> airports;

        public City()
        {
            this.airports = new HashSet<Airport>();
        }

        public string Name { get; set; }

        public virtual ICollection<Airport> Airports
        {
            get
            {
                return this.airports;
            }
            set
            {
                this.airports = value;
            }
        }

        public virtual Country Country { get; set; }
    }
}
