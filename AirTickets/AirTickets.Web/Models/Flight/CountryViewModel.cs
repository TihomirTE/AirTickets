using AirTickets.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirTickets.Data.Model;

namespace AirTickets.Web.Models.Flight
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {

        }

        public CountryViewModel(CountryModel country)
        {
            if (country != null)
            {
                this.Id = country.Id;
                this.Name = country.Name;
                this.Airports = country.Airports.Select(x => new AirportViewModel(x)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<AirportViewModel> Airports { get; set; }
    }
}