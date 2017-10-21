using AirTickets.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.DataServices.Models
{
    public class AirportModel
    {
        public AirportModel()
        {

        }

        public AirportModel(Airport airport)
        {
            if (airport != null)
            {
                this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.DepartureFlights = airport.DepartureFlights.Select(b => new FlightModel(b)).ToList();
                this.ArrivalFlights = airport.ArrivalFlights.Select(b => new FlightModel(b)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<FlightModel> DepartureFlights { get; set; }

        public IEnumerable<FlightModel> ArrivalFlights { get; set; }


        public static Expression<Func<Airport, AirportModel>> Create
        {
            get
            {
                return x => new AirportModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AirportCode = x.AirportCode,
                    DepartureFlights = x.DepartureFlights.AsQueryable().Select(FlightModel.Create).ToList(),
                    ArrivalFlights = x.ArrivalFlights.AsQueryable().Select(FlightModel.Create).ToList()
                };
            }
        }
    }
}
