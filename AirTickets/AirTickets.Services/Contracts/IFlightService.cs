using System.Linq;
using AirTickets.Data.Model;
using System.Collections.Generic;
using AirTickets.Services.Models;

namespace AirTickets.Services.Contracts
{
    public interface IFlightService
    {
        IEnumerable<FlightModel> GetAllFlights();
    }
}