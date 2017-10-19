using AirTickets.DataServices.Models;
using System;
using System.Collections.Generic;

namespace AirTickets.DataServices.Contracts
{
    public interface IFlightService
    {
        FlightModel GetById(Guid? id);

        IEnumerable<FlightModel> GetFlightByPrice(int searchTerm);
    }
}