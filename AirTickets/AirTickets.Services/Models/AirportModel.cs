using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services.Models
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
                this.Flights = airport.Flights.Select(x => new FlightModel(x)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<FlightModel> Flights { get; set; }

        public static Expression<Func<Airport, AirportModel>> Create
        {
            get
            {
                return airport => new AirportModel()
                {
                    Id = airport.Id,
                    Name = airport.Name,
                    AirportCode = airport.AirportCode,
                    Flights = airport.Flights.AsQueryable().Select(FlightModel.Create).ToList()
                };
            }
        }
    }
}
