using AirTickets.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.DataServices.Contracts
{
   public interface IAirportService
    {
        IEnumerable<AirportModel> GetAllAirportsSortedByName();

        AirportModel GetById(Guid id);
    }
}
