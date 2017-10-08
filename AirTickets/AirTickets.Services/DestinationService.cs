using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Data.SaveContext;
using AirTickets.Services.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services
{
    public class DestinationService
    {
        private readonly IEfRepository<Airport> destinationRepo;
        private readonly ISaveContext saveContext;

        public DestinationService(IEfRepository<Airport> destinationRepo, ISaveContext saveContext)
        {
            Guard.WhenArgument(destinationRepo, "destinationRepo").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.destinationRepo = destinationRepo;
            this.saveContext = saveContext;
        }

        public AirportModel GetById(Guid id)
        {
            return new AirportModel(this.destinationRepo.GetById(id));
        }

        public IEnumerable<AirportModel> GetAllAirportSortedAlphabetically()
        {
            return this.destinationRepo.All.ToList()
                .OrderBy(x => x.Name)
                .AsQueryable()
                .Select(AirportModel.Create)
                .ToList();
        }

        public IEnumerable<AirportModel> GetAllAirportsWithFlightsIncluded()
        {
            return this.destinationRepo.AllWithInclude(x => x.Flights)
                .Select(AirportModel.Create)
                .ToList();
        }
    }
}
