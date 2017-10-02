using AirTickets.Data.Model;
using AirTickets.Data.Repositories;
using AirTickets.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly IEfRepository<Ticket> ticketRepo;

        public TicketService(IEfRepository<Ticket> ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }

        public IQueryable<Ticket> GetAll()
        {
            return this.ticketRepo.All;
        }
    }
}
