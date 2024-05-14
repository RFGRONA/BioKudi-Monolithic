using BioKudi.dto;
using BioKudi.Repository;
using System.Security.Claims;

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

        public TicketDto CreateTicket(TicketDto ticket, HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
                if (int.TryParse(userIdClaim.Value, out int userId))
                    ticket.UserId = userId;
            ticket.State = 6;
            var result = ticketRepo.Create(ticket);
            if (result == null)
            {
                return null;
            }
            return ticket;
        }

        public IEnumerable<TicketDto> GetAllTickets()
        {
            return ticketRepo.GetListTicket() ?? new List<TicketDto>();
        }

        public TicketDto GetTicket(int id)
        {
            return ticketRepo.GetTicket(id);
        }

        public TicketDto UpdateTicket(TicketDto ticket)
        {
            ticket.State = 7;
            var result = ticketRepo.Update(ticket);
            if (result == null)
            {
                return null;
            }
            return ticket;
        }

        public bool DeleteTicket(int id)
        {
            return ticketRepo.Delete(id);
        }

    }
}
