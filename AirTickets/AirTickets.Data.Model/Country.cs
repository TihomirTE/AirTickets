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
    public class Country : DataModel
    {
        private ICollection<DepartureAirport> airports;

        public Country()
        {
            //this.airports = new HashSet<DepartureAirport>();
        }

        [MinLength(ModelConstants.MinNameLenght)]
        [MaxLength(ModelConstants.MaxNameLenght)]
        public string Name { get; set; }


        public virtual ICollection<DepartureAirport> Airports
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
    }
}
