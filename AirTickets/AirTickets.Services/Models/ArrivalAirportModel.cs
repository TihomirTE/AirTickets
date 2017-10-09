using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services.Models
{
    public class ArrivalAirportModel
    {
        public ArrivalAirportModel()
        {

        }

        public ArrivalAirportModel(ArrivalAirport airport)
        {
            if (airport != null)
            {
                //this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.Airlines = airport.Airlines.Select(x => new AirlineModel(x)).ToList();
                if (airport.DepartureAirport != null)
                {
                    this.DepartureAirportId = airport.DepartureAirport.Id;
                }
            }
        }

        //public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<AirlineModel> Airlines { get; set; }

        public Guid DepartureAirportId { get; set; }

        public DepartureAirportModel DeaprtureAirport { get; set; }

        public static Expression<Func<ArrivalAirport, ArrivalAirportModel>> Create
        {
            get
            {
                return airport => new ArrivalAirportModel()
                {
                    //Id = airport.Id,
                    Name = airport.Name,
                    AirportCode = airport.AirportCode,
                    Airlines = airport.Airlines.AsQueryable().Select(AirlineModel.Create).ToList()
                };
            }
        }
    }
}
