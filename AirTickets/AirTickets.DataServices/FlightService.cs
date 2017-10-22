using Bytes2you.Validation;
using System;
using System.Linq;
using System.Collections.Generic;
using AirTickets.DataServices.Contracts;
using AirTickets.Data.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices.Models;

namespace AirTickets.DataServices
{
    public class FlightService : IFlightService
    {
        private readonly IEfDbSetWrapper<Flight> flightRepo;

        private readonly IAirTicketDbContextSaveChanges dbContext;

        public FlightService(IEfDbSetWrapper<Flight> flightRepo, IAirTicketDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(flightRepo, "flightRepo").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.flightRepo = flightRepo;
            this.dbContext = dbContext;
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
            return this.flightRepo.AllWithInclude(x => x.Airline)
                .Select(FlightModel.Create)
                .ToList();
        }

        public IEnumerable<FlightModel> GetFlightByPrice(int searchTerm)
        {
            if (searchTerm > 0)
            {
                return this.flightRepo.All
                    .OrderBy(x => x.Price)
                    .Where(x => x.Price <= searchTerm)
                    .AsQueryable()
                    .Select(FlightModel.Create).ToList();
            }
            else
            {
                return new List<FlightModel>();
            }
        }
    }
}