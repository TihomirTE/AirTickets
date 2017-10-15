using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Contracts
{
    public interface ISqlDbContext
    {
       IDbSet<Flight> Flights { get; set; }

       IDbSet<Airline> Airlines { get; set; }

        IDbSet<DepartureAirport> DepartureAirports { get; set; }

        IDbSet<ArrivalAirport> ArrivalAirports { get; set; }

        IDbSet<Country> Countries { get; set; }

        //void ApplyAuditInfoRules();

        //void SaveChanges();

        //ISqlDbContext Create();
    }
}
