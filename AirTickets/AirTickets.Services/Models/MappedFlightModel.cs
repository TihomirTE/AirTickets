using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTickets.Data.Model.Enum;
using System.Linq.Expressions;

namespace AirTickets.Services.Models
{
    public class MappedFlightModel
    {
        public MappedFlightModel()
        {

        }

        public MappedFlightModel(AirlineModel airline, FlightModel flight)
        {
            this.AirlineName = airline.Name;
            this.Price = flight.Price;
            this.Duration = flight.Duration;
            this.TravelClass = flight.TravelClass;
        }

        public string AirlineName { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public TravelClass TravelClass { get; set; }

        public static Expression<Func<MappedFlightModel, MappedFlightModel>> Create
        {
            get
            {
                return x => new MappedFlightModel()
                {
                    AirlineName = x.AirlineName,
                    Price = x.Price,
                    Duration = x.Duration,
                    TravelClass = x.TravelClass
                };
            }
        }
    }
}
