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
            Guard.WhenArgument(flightRepo, "bookSetWrapper").IsNull().Throw();
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
            //return string.IsNullOrEmpty(searchTerm) ? this.flightSetWrapper.All.Select(FlightModel.Create).ToList()
            //    : this.flightSetWrapper.All.Where(b =>
            //    (string.IsNullOrEmpty(b..Title) ? false : b.Title.Contains(searchTerm))
            //    ||
            //    (string.IsNullOrEmpty(b.Author) ? false : b.Author.Contains(searchTerm)))
            //    .Select(FlightModel.Create).ToList();

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