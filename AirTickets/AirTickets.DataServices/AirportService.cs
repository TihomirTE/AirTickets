using AirTickets.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTickets.DataServices.Models;
using AirTickets.Data.Models;
using AirTickets.Data.Contracts;
using Bytes2you.Validation;

namespace AirTickets.DataServices
{
    public class AirportService : IAirportService
    {
        private readonly IEfDbSetWrapper<Airport> airportRepo;
        private readonly IAirTicketDbContextSaveChanges dbContext;

        public AirportService(IEfDbSetWrapper<Airport> airportRepo, IAirTicketDbContextSaveChanges dbContext)
        {
            Guard.WhenArgument(airportRepo, "airportRepo").IsNull().Throw();
            Guard.WhenArgument(dbContext, "dbContext").IsNull().Throw();

            this.airportRepo = airportRepo;
            this.dbContext = dbContext;
        }

        public IEnumerable<AirportModel> GetAllAirportsSortedByName()
        {
            return this.airportRepo.All
                .OrderBy(x => x.Name)
                .AsQueryable()
                .Select(AirportModel.Create)
                .ToList();
        }

        public AirportModel GetById(Guid? id)
        {
            AirportModel result = null;

            if (id.HasValue)
            {
                Airport airport = this.airportRepo.GetById(id.Value);
                if (airport != null)
                {
                    result = new AirportModel(airport);
                }
            }

            return result;
        }
    }
}
