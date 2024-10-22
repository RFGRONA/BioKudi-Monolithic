﻿using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;

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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public TicketDto GetTicket(int id)
        {
            try
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
                    State = ticketEntity.State,
                    StateName = _context.States.Find(ticketEntity.State).NameState,
                    Answer = ticketEntity.Answer
                };
                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<TicketDto> GetListTicket()
        {
            try
            {
                var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
                var ticketEntities = _context.Tickets.OrderBy(t => t.State);
                var tickets = new List<TicketDto>();
                if(ticketEntities == null)
                    return null;
                foreach (var ticket in ticketEntities)
                {
                    var ticketDto = new TicketDto
                    {
                        IdTicket = ticket.IdTicket,
                        Type = ticket.Type,
                        Affair = ticket.Affair,
                        UserId = ticket.UserId,
                        StateName = states.ContainsKey((int)ticket.State) ? states[(int)ticket.State] : null,
                        Answer = ticket.Answer
                    };
                    tickets.Add(ticketDto);
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<TicketDto> GetTicketsAnswer()
        {
            try
            {
                var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
                var ticketEntities = _context.Tickets.Where(t => t.State == 7);
                var tickets = new List<TicketDto>();
                if (ticketEntities == null)
                    return null;
                foreach (var ticket in ticketEntities)
                {
                    var ticketDto = new TicketDto
                    {
                        IdTicket = ticket.IdTicket,
                        Type = ticket.Type,
                        Affair = ticket.Affair,
                        UserId = ticket.UserId,
                        StateName = states.ContainsKey((int)ticket.State) ? states[(int)ticket.State] : null,
                        Answer = ticket.Answer
                    };
                    tickets.Add(ticketDto);
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<TicketDto> GetTicketsPending()
        {
            try
            {
                var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
                var ticketEntities = _context.Tickets.Where(t => t.State == 6);
                var tickets = new List<TicketDto>();
                if (ticketEntities == null)
                    return null;
                foreach (var ticket in ticketEntities)
                {
                    var ticketDto = new TicketDto
                    {
                        IdTicket = ticket.IdTicket,
                        Type = ticket.Type,
                        Affair = ticket.Affair,
                        UserId = ticket.UserId,
                        StateName = states.ContainsKey((int)ticket.State) ? states[(int)ticket.State] : null,
                        Answer = ticket.Answer
                    };
                    tickets.Add(ticketDto);
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public TicketDto Update(TicketDto ticket)
        {
            try
            {
                var ticketEntity = _context.Tickets.Find(ticket.IdTicket);
                if (ticketEntity == null)
                    return null;
                ticketEntity.Type = ticket.Type;
                ticketEntity.Affair = ticket.Affair;
                ticketEntity.UserId = ticket.UserId;
                ticketEntity.State = ticket.State;
                ticketEntity.Answer = ticket.Answer;
                _context.SaveChanges();
                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var ticketEntity = _context.Tickets.Find(id);
                if (ticketEntity == null)
                    return false;
                _context.Tickets.Remove(ticketEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
