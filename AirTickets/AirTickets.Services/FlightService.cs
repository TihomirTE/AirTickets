using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Data.SaveContext;
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
        private readonly ISaveContext saveContext;

        public FlightService(IEfRepository<Flight> flightRepo, ISaveContext saveContext)
        {
            this.flightRepo = flightRepo;
            this.saveContext = saveContext;
        }

        public FlightModel GetById(Guid? id)
        {
            FlightModel result = null;

            if (id.HasValue)
            {
                Flight flight = this.flightRepo.GetById(id.Value);

                if (flight != null)
                {
                    result = new FlightModel(flight);
                }
            }

            return result;
        }

        public IEnumerable<FlightModel> GetAll()
        {
            return this.flightRepo.All.ToList().OrderBy(x => x.Price).AsQueryable()
                .Select(FlightModel.Create).ToList();
        }
    }
}
