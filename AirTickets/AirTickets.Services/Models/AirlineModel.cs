using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services.Models
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
                //this.Id = airline.Id;
                this.Name = airline.Name;
                this.Flights = airline.Flights.Select(x => new FlightModel(x)).ToList();
                if (airline.ArrivalAirport != null)
                {
                    this.ArrivalAirportsId = airline.ArrivalAirport.Id;
                }
            }
        }

        //public Guid Id { get; private set; }

        public string Name { get; set; }

        public IEnumerable<FlightModel> Flights { get; set; }

        public Guid ArrivalAirportsId { get; set; }

        public ArrivalAirportModel ArrivalAirports { get; set; }

        public static Expression<Func<Airline, AirlineModel>> Create
        {
            get
            {
                return c => new AirlineModel()
                {
                    //Id = c.Id,
                    Name = c.Name,
                    Flights = c.Flights.AsQueryable().Select(FlightModel.Create).ToList()
                };
            }
        }
    }
}
