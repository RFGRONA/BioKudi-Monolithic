using BioKudi.dto;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class TicketRepository
    {
        private readonly BiokudiDbContext _context;
        public TicketRepository(BiokudiDbContext context)
        {
            _context = context;
        }

        public TicketDto Create(TicketDto ticket)
        {
            var ticketEntity = new Ticket
            {
                Type = ticket.Type,
                Affair = ticket.Affair,
                UserId = ticket.UserId,
                State = ticket.State
            };
            _context.Tickets.Add(ticketEntity);
            _context.SaveChanges();
            ticket.IdTicket = ticketEntity.IdTicket;
            return ticket;
        }

        public TicketDto GetTicket(int id)
        {
            var ticketEntity = _context.Tickets.Find(id);
            if (ticketEntity == null)
                return null;
            var ticket = new TicketDto
            {
                IdTicket = ticketEntity.IdTicket,
                Type = ticketEntity.Type,
                Affair = ticketEntity.Affair,
                UserId = ticketEntity.UserId,
                State = ticketEntity.State
            };
            return ticket;
        }

        public List<TicketDto> GetListTicket()
        {
            var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
            var ticketEntities = _context.Tickets;
            var tickets = new List<TicketDto>();
            foreach (var ticket in ticketEntities)
            {
                var ticketDto = new TicketDto
                {
                    IdTicket = ticket.IdTicket,
                    Type = ticket.Type,
                    Affair = ticket.Affair,
                    UserId = ticket.UserId,
                    StateName = states.ContainsKey((int)ticket.State) ? states[(int)ticket.State] : null
                };
                tickets.Add(ticketDto);
            }
            return tickets;
        }

        public TicketDto Update(TicketDto ticket)
        {
            var ticketEntity = _context.Tickets.Find(ticket.IdTicket);
            if (ticketEntity == null)
                return null;
            ticketEntity.Type = ticket.Type;
            ticketEntity.Affair = ticket.Affair;
            ticketEntity.UserId = ticket.UserId;
            ticketEntity.State = ticket.State;
            _context.SaveChanges();
            return ticket;
        }

        public void Delete(int id)
        {
            var ticketEntity = _context.Tickets.Find(id);
            if (ticketEntity == null)
                return;
            _context.Tickets.Remove(ticketEntity);
            _context.SaveChanges();
        }
    }
}
