using System.Linq;
using AirTickets.Data.Model;
using System.Collections.Generic;
using AirTickets.Services.Models;
using System;

namespace AirTickets.Services.Contracts
{
    public interface IFlightService
    {
        FlightModel GetById(Guid? id);

        IEnumerable<FlightModel> GetAllFlights();

        IEnumerable<FlightModel> GetFlightsByPrice(int price);
    }
}