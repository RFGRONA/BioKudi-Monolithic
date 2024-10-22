﻿using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;

namespace BioKudi.Repository
{
    public class StateRepository
    {
        private readonly BiokudiDbContext _context;
        public StateRepository(BiokudiDbContext context)
        {
            _context = context;
        }
        public StateDto Create(StateDto state)
        {
            try
            {
                var stateEntity = new State
                {
                    NameState = state.NameState,
                    Table = state.Table
                };
                if (_context.States.Any(s => s.NameState == state.NameState))
                    return null;
                _context.States.Add(stateEntity);
                _context.SaveChanges();
                state.StateId = stateEntity.IdState;
                return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public StateDto GetState(int stateId)
        {
            try
            {
                var stateEntity = _context.States.Find(stateId);
                if (stateEntity == null)
                    return null;
                var state = new StateDto
                {
                    StateId = stateEntity.IdState,
                    NameState = stateEntity.NameState,
                    Table = stateEntity.Table
                };
                return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<StateDto> GetAllStates()
        {
            try
            {
                var states = _context.States.ToList();
                var statesDto = new List<StateDto>();
                foreach (var stateEntity in states)
                {
                    var state = new StateDto
                    {
                        StateId = stateEntity.IdState,
                        NameState = stateEntity.NameState,
                        Table = stateEntity.Table
                    };
                    statesDto.Add(state);
                }
                return statesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<StateDto> GetUserStates()
        {
            try
            {
                var states = _context.States.Where(s => s.Table == "USER").ToList();
                var statesDto = new List<StateDto>();
                foreach (var stateEntity in states)
                {
                    var state = new StateDto
                    {
                        StateId = stateEntity.IdState,
                        NameState = stateEntity.NameState,
                        Table = stateEntity.Table
                    };
                    statesDto.Add(state);
                }
                return statesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<StateDto> GetPlaceStates()
        {
            try
            {
                var states = _context.States.Where(s => s.Table == "PLACE").ToList();
                var statesDto = new List<StateDto>();
                foreach (var stateEntity in states)
                {
                    var state = new StateDto
                    {
                        StateId = stateEntity.IdState,
                        NameState = stateEntity.NameState,
                        Table = stateEntity.Table
                    };
                    statesDto.Add(state);
                }
                return statesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<StateDto> GetTicketStates()
        {
            try
            {
                var states = _context.States.Where(s => s.Table == "TICKET").ToList();
                var statesDto = new List<StateDto>();
                foreach (var stateEntity in states)
                {
                    var state = new StateDto
                    {
                        StateId = stateEntity.IdState,
                        NameState = stateEntity.NameState,
                        Table = stateEntity.Table
                    };
                    statesDto.Add(state);
                }
                return statesDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public StateDto Update(StateDto state)
        {
            try
            {
                var stateEntity = _context.States.Find(state.StateId);
                if (stateEntity == null)
                    return null;
                stateEntity.NameState = state.NameState;
                stateEntity.Table = state.Table;
                _context.SaveChanges();
                return state;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int stateId)
        {
            try
            {
                var stateEntity = _context.States
                .Include(s => s.Places)
                .Include(s => s.Tickets)
                .Include(s => s.Users)
                .SingleOrDefault(s => s.IdState == stateId);
                if (stateEntity == null)
                    return false;
                foreach (var place in stateEntity.Places)
                {
                    place.StateId = null;
                }
                foreach (var ticket in stateEntity.Tickets)
                {
                    ticket.State = 0;
                }
                foreach (var user in stateEntity.Users)
                {
                    user.StateId = 8;
                }
                _context.SaveChanges();
                _context.States.Remove(stateEntity);
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
