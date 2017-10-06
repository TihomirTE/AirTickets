using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Services.Contracts;
using AirTickets.Services.Models;
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

        public FlightService(IEfRepository<Flight> flightRepo)
        {
            this.flightRepo = flightRepo;
        }

        public IEnumerable<FlightModel> GetAll()
        {
            return this.flightRepo.All.ToList().OrderBy(x => x.Price).AsQueryable()
                .Select(FlightModel.Create).ToList();
        }
    }
}
