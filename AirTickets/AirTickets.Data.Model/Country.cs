using AirTickets.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class Country : DataModel
    {
        //private ICollection<DepartureAirport> airports;

        public Country()
        {
            //this.airports = new HashSet<DepartureAirport>();
        }

        public string Name { get; set; }


        //public virtual ICollection<DepartureAirport> Airports
        //{
        //    get
        //    {
        //        return this.airports;
        //    }
        //    set
        //    {
        //        this.airports = value;
        //    }
        //}
    }
}
