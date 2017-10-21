using AirTickets.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AirTickets.DataServices.Models
{
    public class AirlineModel
    {
        public AirlineModel()
        {
        }

        public AirlineModel(Airline airline)
        {
            if (airline != null)
            {
                this.Id = airline.Id;
                this.Name = airline.Name;
                this.Flights = airline.Flights.Select(b => new FlightModel(b)).ToList();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<FlightModel> Flights { get; set; }

        public static Expression<Func<Airline, AirlineModel>> Create
        {
            get
            {
                return c => new AirlineModel()
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Flights = c.Flights.AsQueryable().Select(FlightModel.Create).ToList()
                            };
            }
        }
    }
}