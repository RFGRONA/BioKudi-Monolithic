using BioKudi.dto;
using BioKudi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;

namespace BioKudi.Repository
{
    public class UserRepository
    {
        private readonly BiokudiDbContext _context;
        private readonly RoleRepository _roleRepository;
        private readonly StateRepository _stateRepository;
        public UserRepository(BiokudiDbContext context, RoleRepository roleRepository, StateRepository stateRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            _stateRepository = stateRepository;
        }

        public UserDto Create(UserDto user)
        {
            try
            {
                var userEntity = new User
                {
                    NameUser = user.NameUser,
                    Email = user.Email,
                    Password = user.Password,
                    Key = user.Key,
                    Salt = user.Salt,
                    RoleId = user.RoleId,
                    StateId = user.StateId
                };
                if (_context.Users.Any(u => u.Email == user.Email))
                    return null;
                _context.Users.Add(userEntity);
                _context.SaveChanges();
                user.UserId = userEntity.IdUser;
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserDto Login(UserDto user)
        {
            try
            {
                var userEntity = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (userEntity == null)
                    return null;
                user.UserId = userEntity.IdUser;
                user.NameUser = userEntity.NameUser;
                user.RoleId = userEntity.RoleId;
                user.RoleName = _roleRepository.GetRole(userEntity.RoleId).NameRole;
                user.StateId = userEntity.StateId;
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserDto FindUser(UserDto user)
        {
            try
            {
                var userEntity = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (userEntity == null)
                    return null;
                user.Salt = userEntity.Salt;
                user.Key = userEntity.Key;
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserDto GetUser(int userId)
        {
            try
            {
                var userEntity = _context.Users.Find(userId);
                if (userEntity == null)
                    return null;
                var user = new UserDto
                {
                    UserId = userEntity.IdUser,
                    NameUser = userEntity.NameUser,
                    Email = userEntity.Email,
                    RoleId = userEntity.RoleId,
                    RoleName = _roleRepository.GetRole(userEntity.RoleId).NameRole,
                    StateId = userEntity.StateId,
                    StateName = _stateRepository.GetState(userEntity.StateId).NameState
                };
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<UserDto> GetListUser()
        {
            try
            {
                var users = _context.Users.ToList();
                var roles = _context.Roles.ToDictionary(r => r.IdRole, r => r.NameRole);
                var states = _context.States.ToDictionary(s => s.IdState, s => s.NameState);
                var usersDto = new List<UserDto>();
                foreach (var user in users)
                {
                    var UserDto = new UserDto
                    {
                        UserId = user.IdUser,
                        NameUser = user.NameUser,
                        Email = user.Email,
                        RoleId = user.RoleId,
                        RoleName = roles.ContainsKey(user.RoleId) ? roles[user.RoleId] : null,
                        StateId = user.StateId,
                        StateName = states.ContainsKey(user.StateId) ? states[user.StateId] : null
                    };
                    usersDto.Add(UserDto);
                }
                return usersDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserDto UpdateUser(UserDto user)
        {
            try
            {
                var userEntity = _context.Users.Find(user.UserId);
                if (userEntity == null)
                    return null;
                userEntity.RoleId = user.RoleId;
                userEntity.StateId = user.StateId;
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var userEntity = _context.Users.Find(userId);
                if (userEntity == null)
                    return false;
                _context.Users.Remove(userEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    };
}
