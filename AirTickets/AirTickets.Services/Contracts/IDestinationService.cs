using System;
using System.Collections.Generic;
using AirTickets.Services.Models;

namespace AirTickets.Services.Contracts
{
    public interface IDestinationService
    {
        IEnumerable<DepartureAirportModel> GetAllAirportSortedAlphabetically();

        IEnumerable<DepartureAirportModel> GetAllFlightsWithDestinationIncluded();

        //ArrivalAirportModel GetById(Guid id);
    }
}