using BioKudi.dto;
using BioKudi.Repository;

namespace BioKudi.Services
{
    public class RoleService
    {
        private readonly RoleRepository roleRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RoleService(RoleRepository roleRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.roleRepository = roleRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            return roleRepository.GetRoles();
        }
    }
}
