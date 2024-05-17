using BioKudi.dto;
using BioKudi.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public RoleDto GetRole(int roleId)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<RoleDto> GetRoles()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public RoleDto Update(RoleDto role)
        {
            try
            {
                var roleEntity = _context.Roles.Find(role.RoleId);
                if (roleEntity == null)
                    return null;
                roleEntity.NameRole = role.NameRole;
                _context.SaveChanges();
                return role;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int roleId)
        {
            try
            {
                var roleEntity = _context.Roles
                .Include(s => s.Users)
                .SingleOrDefault(s => s.IdRole == roleId);
                if (roleEntity == null)
                    return false;
                foreach (var user in roleEntity.Users)
                {
                    user.RoleId = 1;
                }
                _context.SaveChanges();
                _context.Roles.Remove(roleEntity);
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
