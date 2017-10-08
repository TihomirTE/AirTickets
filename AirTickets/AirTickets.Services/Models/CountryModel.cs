using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services.Models
{
    public class CountryModel
    {
        public CountryModel()
        {

        }

        public CountryModel(Country country)
        {
            if (country != null)
            {
                this.Id = country.Id;
                this.Name = country.Name;
                this.Airports = country.Airports;
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Airport> Airports { get; set; }
    }
}
