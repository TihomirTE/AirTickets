using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using AirTickets.Data.Contracts;
using AirTickets.DataServices.Contracts;
using AirTickets.Data.Models;
using AirTickets.DataServices.Models;

namespace AirTickets.DataServices
{
    public class AirlineService : IAirlineService
    {
        private readonly IEfDbSetWrapper<Airline> airlineRepo;

        private readonly IAirTicketDbContextSaveChanges dbContext;
        
        public AirlineService(IEfDbSetWrapper<Airline> airlineRepo, IAirTicketDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(airlineRepo, "airlineRepo").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.airlineRepo = airlineRepo;
            this.dbContext = dbContext;
        }
        
        public IEnumerable<AirlineModel> GetAllAirlinesWithFlightsIncluded()
        {
            return this.airlineRepo.AllWithInclude(x => x.Flights)
                .Select(AirlineModel.Create)
                .ToList();
        }
    }
}