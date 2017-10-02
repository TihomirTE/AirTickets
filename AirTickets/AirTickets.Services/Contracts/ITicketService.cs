using System.Linq;
using AirTickets.Data.Model;

namespace AirTickets.Services.Contracts
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetAll();
    }
}