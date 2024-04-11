using BioKudi.dto;
using BioKudi.Models;

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
				Email = user.Email,
				Password = user.Password,
				NameUser = user.NameUser,
				RoleId = user.RoleId
			};
			if(_context.Users.Any(u => u.Email == user.Email))
			{
				return null;
			}

			_context.Users.Add(userEntity);
			_context.SaveChanges();
			return user;
		}
	}
}
