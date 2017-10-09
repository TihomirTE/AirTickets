using System;
using System.Collections.Generic;
using AirTickets.Services.Models;

namespace AirTickets.Services.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<DepartureAirportModel> GetAllAirportSortedAlphabetically();

        IEnumerable<DepartureAirportModel> GetAllAirportsWithFlightsIncluded();

        //ArrivalAirportModel GetById(Guid id);
    }
}