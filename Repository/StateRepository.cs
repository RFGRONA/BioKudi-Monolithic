using BioKudi.dto;
using BioKudi.Models;

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
            var stateEntity = new State
            {
                NameState = state.NameState
            };
            if (_context.States.Any(s => s.NameState == state.NameState))
                return null;
            _context.States.Add(stateEntity);
            _context.SaveChanges();
            state.StateId = stateEntity.IdState;
            return state;
        }

        public StateDto GetState(int stateId)
        {
            var stateEntity = _context.States.Find(stateId);
            if (stateEntity == null)
                return null;
            var state = new StateDto
            {
                StateId = stateEntity.IdState,
                NameState = stateEntity.NameState
            };
            return state;
        }

        public List<StateDto> GetStates()
        {
            var states = _context.States.ToList();
            var statesDto = new List<StateDto>();
            foreach (var stateEntity in states)
            {
                var state = new StateDto
                {
                    StateId = stateEntity.IdState,
                    NameState = stateEntity.NameState
                };
                statesDto.Add(state);
            }
            return statesDto;
        }

        public StateDto Update(StateDto state)
        {
            var stateEntity = _context.States.Find(state.StateId);
            if (stateEntity == null)
                return null;
            stateEntity.NameState = state.NameState;
            _context.SaveChanges();
            return state;
        }
    }
}
