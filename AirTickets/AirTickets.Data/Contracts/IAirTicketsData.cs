using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Data.Contracts
{
    public interface IAirTicketsData
    {
        IEfRepository<Airline> Airlines { get; }

        IEfRepository<ArrivalAirport> ArrivalAirports { get; }

        IEfRepository<DepartureAirport> DepartureAirports { get; }

        IEfRepository<Country> Countries { get; }

        IEfRepository<Flight> Flights { get; }

        IEfRepository<User> Users { get; }

        void SaveChanges();
    }
}
