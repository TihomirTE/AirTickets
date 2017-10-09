using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services.Models
{
    public class DepartureAirportModel
    {
        public DepartureAirportModel()
        {

        }

        public DepartureAirportModel(DepartureAirport airport)
        {
            if (airport != null)
            {
                //this.Id = airport.Id;
                this.Name = airport.Name;
                this.AirportCode = airport.AirportCode;
                this.ArrivalAirports = airport.ArrivalAirports.Select(x => new ArrivalAirportModel(x)).ToList();
            }
        }

        //public Guid Id { get; set; }

        public string Name { get; set; }

        public string AirportCode { get; set; }

        public IEnumerable<ArrivalAirportModel> ArrivalAirports { get; set; }

        public static Expression<Func<DepartureAirport, DepartureAirportModel>> Create
        {
            get
            {
                return airport => new DepartureAirportModel()
                {
                    //Id = airport.Id,
                    Name = airport.Name,
                    AirportCode = airport.AirportCode,
                    ArrivalAirports = airport.ArrivalAirports.AsQueryable().Select(ArrivalAirportModel.Create).ToList()
                };
            }
        }
    }
}
