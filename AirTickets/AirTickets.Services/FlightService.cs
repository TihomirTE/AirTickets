using AirTickets.Data.Contracts;
using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Data.SaveContext;
using AirTickets.Services.Contracts;
using AirTickets.Services.Models;
using Bytes2you.Validation;
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
        private readonly IEfRepository<Airline> airlineRepo;
        private readonly ISaveContext saveContext;

        public FlightService(IEfRepository<Flight> flightRepo, IEfRepository<Airline> airlineRepo, ISaveContext saveContext)
        {
            Guard.WhenArgument(flightRepo, "flightRepo").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.flightRepo = flightRepo;
            this.airlineRepo = airlineRepo;
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

        public IEnumerable<FlightModel> GetAllFlights()
        {
            return this.flightRepo.All.ToList()
                .OrderBy(x => x.Price)
                .AsQueryable()
                .Select(FlightModel.Create)
                .ToList();
        }

        public IEnumerable<FlightModel> GetFlightsByPrice(int price)
        {
            var flight = new Flight();
            IEnumerable<FlightModel> result = new List<FlightModel>();

            if (price > 0)
            {
                result = this.flightRepo.All
                    .OrderBy(x => x.Price)
                    .Where(x => x.Price <= price)
                    .AsQueryable()
                    .Select(FlightModel.Create).ToList();
            }

            return result;
        }
    }
}
