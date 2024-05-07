using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class StateService
    {
        private readonly StateRepository stateRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StateService(StateRepository stateRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.stateRepo = stateRepo;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IEnumerable<StateDto> GetAllStates()
        {
            return stateRepo.GetAllStates();
        }

        public StateDto GetState(int stateId)
        {
            return stateRepo.GetState(stateId);
        }

        public IEnumerable<StateDto> GetUserStates()
        {
            return stateRepo.GetUserStates();
        }

        public IEnumerable<StateDto> GetPlaceStates()
        {
            return stateRepo.GetPlaceStates();
        }

        public IEnumerable<StateDto> GetTicketStates()
        {
            return stateRepo.GetTicketStates();
        }

        public StateDto Create(StateDto state)
        {
            return stateRepo.Create(state);
        }

        public StateDto Update(StateDto state)
        {
            return stateRepo.Update(state);
        }

        public bool Delete(int stateId)
        {
            return stateRepo.Delete(stateId);
        }

    }
}
