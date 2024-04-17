using BioKudi.dto;
using BioKudi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;

namespace BioKudi.Repository
{
    public class UserRepository
    {
        private readonly BiokudiDbContext _context;
        public UserRepository(BiokudiDbContext context)
        {
            _context = context;
        }
        public UserDto Create(UserDto user)
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
            return user;
        }

        public UserDto Login(UserDto user)
        {
            var userEntity = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (userEntity == null)
                return null;
            user.UserId = userEntity.IdUser;
            user.NameUser = userEntity.NameUser;
            user.RoleId = userEntity.RoleId;
            user.StateId = userEntity.StateId;
            return user;
        }

        public UserDto FindUser(UserDto user)
        {
            var userEntity = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userEntity == null)
                return null;
            user.Salt = userEntity.Salt;
            user.Key = userEntity.Key;
            return user;
        }

        public IEnumerable<UserDto> GetAll()
        {
			var users = _context.Users;
			var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                var UserDto = new UserDto
                {
                    UserId = user.IdUser,
                    NameUser = user.NameUser,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    StateId = user.StateId,
                };
			}
			return usersDto;
		}
        public UserDto GetUser(int userId)
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
                StateId = userEntity.StateId
            };
            return user;
        }
    };
}
