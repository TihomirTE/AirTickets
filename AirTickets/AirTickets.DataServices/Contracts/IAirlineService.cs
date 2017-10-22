using AirTickets.DataServices.Models;
using System;
using System.Collections.Generic;

namespace AirTickets.DataServices.Contracts
{
    public interface IAirlineService
    {
        IEnumerable<AirlineModel> GetAllAirlinesWithFlightsIncluded();
    }
}