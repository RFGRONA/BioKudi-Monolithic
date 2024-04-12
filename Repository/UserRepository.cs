using BioKudi.dto;
using BioKudi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BioKudi.Repository
{
	public class UserRepository
	{
		private readonly BiokudiDbContext _context;
		public UserRepository(BiokudiDbContext context)
		{
			_context = context;
		}
		public UserDto Create(UserDto user, ModelStateDictionary model)
		{
			var userEntity = new User
			{
				Email = user.Email,
				Password = user.Password,
				NameUser = user.NameUser,
				RoleId = 1,
				StateId = 1
			};
			if(_context.Users.Any(u => u.Email == user.Email))
			{
				model.AddModelError("Email", "Correo ya en uso");
				return null;
			}

			_context.Users.Add(userEntity);
			_context.SaveChanges();
			return user;
		}

		public UserDto login(UserDto user, ModelStateDictionary model)
		{
			var userEntity = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
			if(userEntity == null)
			{
				model.AddModelError("Password", "Correo o contraseña incorrectos");
				return null;
			}
			return user;
		}
	}
}
