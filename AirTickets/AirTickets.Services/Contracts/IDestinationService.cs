using System;
using System.Collections.Generic;
using AirTickets.Services.Models;

namespace AirTickets.Services.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<AirportModel> GetAllAirportSortedAlphabetically();

        IEnumerable<AirportModel> GetAllAirportsWithFlightsIncluded();

        AirportModel GetById(Guid id);
    }
}