using BioKudi.dto;
using BioKudi.Models;

namespace BioKudi.Repository
{
    public class RoleRepository
    {
        private readonly BiokudiDbContext _context;
        public RoleRepository(BiokudiDbContext context)
        {
            _context = context;
        }
        public RoleDto Create(RoleDto role)
        {
            var roleEntity = new Role
            {
                NameRole = role.NameRole
            };
            if (_context.Roles.Any(r => r.NameRole == role.NameRole))
                return null;
            _context.Roles.Add(roleEntity);
            _context.SaveChanges();
            role.RoleId = roleEntity.IdRole;
            return role;
        }

        public RoleDto GetRole(int roleId)
        {
            var roleEntity = _context.Roles.Find(roleId);
            if (roleEntity == null)
                return null;
            var role = new RoleDto
            {
                RoleId = roleEntity.IdRole,
                NameRole = roleEntity.NameRole
            };
            return role;
        }

        public List<RoleDto> GetRoles()
        {
            var roles = _context.Roles.ToList();
            var rolesDto = new List<RoleDto>();
            foreach (var roleEntity in roles)
            {
                var role = new RoleDto
                {
                    RoleId = roleEntity.IdRole,
                    NameRole = roleEntity.NameRole
                };
                rolesDto.Add(role);
            }
            return rolesDto;
        }

        public RoleDto Update(RoleDto role)
        {
            var roleEntity = _context.Roles.Find(role.RoleId);
            if (roleEntity == null)
                return null;
            roleEntity.NameRole = role.NameRole;
            _context.SaveChanges();
            return role;
        }

        public bool Delete(int roleId)
        {
            var roleEntity = _context.Roles.Find(roleId);
            if (roleEntity == null)
                return false;
            _context.Roles.Remove(roleEntity);
            _context.SaveChanges();
            return true;
        }
    }
}
