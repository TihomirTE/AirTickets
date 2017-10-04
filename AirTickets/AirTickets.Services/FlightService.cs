using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services
{
    public class FlightService : IFlightService
    {
        private readonly IEfRepository<Flight> flightRepo;

        public FlightService(IEfRepository<Flight> ticketRepo)
        {
            this.flightRepo = ticketRepo;
        }

        public IQueryable<Flight> GetAll()
        {
            return this.flightRepo.All;
        }
    }
}
