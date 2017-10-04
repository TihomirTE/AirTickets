using System.Linq;
using AirTickets.Data.Model;

namespace AirTickets.Services.Contracts
{
    public interface IFlightService
    {
        IQueryable<Flight> GetAll();
    }
}