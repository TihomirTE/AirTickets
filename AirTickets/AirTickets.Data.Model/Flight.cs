using AirTickets.Data.Model.Abstracts;
using AirTickets.Data.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Model
{
    public class Flight : DataModel
    {
        public decimal Price { get; set; }

        public TravelClass TravelClass { get; set; }

        public virtual User User { get; set; }

        public virtual Airport DepartureAirport { get; set; }

        public virtual Airport ArrivalAirport { get; set; }


        public virtual Airline Airline { get; set; }


    }
}
