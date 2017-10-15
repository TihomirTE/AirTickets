using AirTickets.Data.Contracts;
using AirTickets.Data.Model;
using AirTickets.Services.Models;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services
{
    public class AirlineService
    {
        private readonly IEfRepository<Airline> airlineRepo;
        private readonly ISaveContext saveContext;

        public AirlineService(IEfRepository<Airline> airlineRepo, ISaveContext saveContext)
        {
            Guard.WhenArgument(airlineRepo, "flightRepo").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.airlineRepo = airlineRepo;
            this.saveContext = saveContext;
        }


        public IEnumerable<AirlineModel> GetAllAirlines()
        {
            return this.airlineRepo.All.ToList()
                .OrderBy(x => x.Flights)
                .AsQueryable()
                .Select(AirlineModel.Create)
                .ToList();
        }

        public IEnumerable<AirlineModel> GetAirlinesByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }

            return this.airlineRepo.All
                .OrderBy(x => x.Name)
                .Where(x => x.Name == name)
                .AsQueryable()
                .Select(AirlineModel.Create)
                .ToList();
        }
    }
}
