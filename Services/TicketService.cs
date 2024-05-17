using BioKudi.dto;
using BioKudi.Repository;
using BioKudi.Utilities;
using System.Security.Claims;

namespace BioKudi.Services
{
    public class TicketService
    {
        private readonly TicketRepository ticketRepo;
        private readonly UserRepository userRepo;
        private readonly EmailUtility emailUtility;
        private readonly IHttpContextAccessor httpContextAccessor;

        public TicketService(TicketRepository ticketRepo, IHttpContextAccessor httpContextAccessor, EmailUtility emailUtility, UserRepository userRepo)
        {
            this.ticketRepo = ticketRepo;
            this.userRepo = userRepo;
            this.emailUtility = emailUtility;
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
            var email = userRepo.GetUser(result.UserId).Email;
            emailUtility.SendEmail(email, "Ticket generado", emailUtility.ticketEmail(result.IdTicket));
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

        public TicketDto UpdateTicket(TicketDto ticket, HttpContext httpContext)
        {
            var userClaim = httpContext.User.FindFirst(ClaimTypes.Name).Value;
            var email = userRepo.GetUser(ticket.UserId).Email;
            ticket.State = 7;
            var result = ticketRepo.Update(ticket);
            if (result == null)
            {
                return null;
            }
            emailUtility.SendEmail(email, "Respuesta a ticket #"+result.IdTicket, emailUtility.answerEmail(userClaim, ticket.Answer, result.IdTicket));
            return ticket;
        }

        public bool DeleteTicket(int id)
        {
            return ticketRepo.Delete(id);
        }

    }
}
