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

        public RoleDto GetRole(int roleId)
        {
            return roleRepository.GetRole(roleId);
        }

        public RoleDto CreateRole(RoleDto role)
        {
            return roleRepository.Create(role);
        }

        public RoleDto UpdateRole(RoleDto role)
        {
            return roleRepository.Update(role);
        }

        public bool DeleteRole(int roleId)
        {
            return roleRepository.Delete(roleId);
        }
    }
}
