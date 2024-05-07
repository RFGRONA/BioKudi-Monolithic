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
        public IEnumerable<StateDto> GetStates()
        {
            return stateRepo.GetStates();
        }


    }
}
