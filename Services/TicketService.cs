using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class TicketService
    {
        private readonly TicketRepository ticketRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TicketService(TicketRepository ticketRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.ticketRepo = ticketRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public TicketDto CreateTicket(TicketDto ticket)
        {
            var result = ticketRepo.Create(ticket);
            if (result == null)
            {
                return null;
            }
            return ticket;
        }

        public IEnumerable<TicketDto> GetAllTickets()
        {
            return ticketRepo.GetListTicket();
        }
    }
}
