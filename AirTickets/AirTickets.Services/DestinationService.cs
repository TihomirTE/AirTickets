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
    public class DestinationService : IDestinationService
    {
        private readonly IEfRepository<DepartureAirport> destinationRepo;
        private readonly ISaveContext saveContext;

        public DestinationService(IEfRepository<DepartureAirport> destinationRepo, ISaveContext saveContext)
        {
            Guard.WhenArgument(destinationRepo, "destinationRepo").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.destinationRepo = destinationRepo;
            this.saveContext = saveContext;
        }

        //public ArrivalAirportModel GetById(Guid id)
        //{
        //    return new ArrivalAirportModel(this.destinationRepo.GetById(id));
        //}

        public IEnumerable<DepartureAirportModel> GetAllAirportSortedAlphabetically()
        {
            return this.destinationRepo.All.ToList()
                .OrderBy(x => x.Name)
                .AsQueryable()
                .Select(DepartureAirportModel.Create)
                .ToList();
        }

        public IEnumerable<DepartureAirportModel> ASearchllFlightsWithDepartureAndDestination(string departure, string arrival)
        {
            return this.destinationRepo
                .AllWithInclude(x => x.ArrivalAirports)
                .Select(DepartureAirportModel.Create)
                .ToList();
        }
    }
}
