using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace BioKudi.Services
{
    public class UserService
    {
        private readonly UserRepository userRepo;
        private readonly PasswordUtility passwordUtility;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(UserRepository userRepo, PasswordUtility passwordUtility, IHttpContextAccessor httpContextAccessor)
        {
            this.userRepo = userRepo;
            this.passwordUtility = passwordUtility;
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserDto RegisterUser(UserDto user, ModelStateDictionary model)
        {
            user.Password = passwordUtility.CreatePassword(user.Password);
            user.Key = passwordUtility.GetKeySafe();
            user.Salt = passwordUtility.GetIv();
            user.RoleId = 1;
            user.StateId = 1;
            user.Email = user.Email.ToLower();
            var result = userRepo.Create(user);
            if (result==null)
            {
                model.AddModelError("Email", "Correo ya en uso");
                return null;
            }
            return user;
        }

        public UserDto LoginUser(UserDto user, ModelStateDictionary model)
        {
            user.Email = user.Email.ToLower();
            user = userRepo.FindUser(user);
            passwordUtility.SetIv(user.Salt);
            passwordUtility.SetKeySafe(user.Key);
            user.Password = passwordUtility.VerifyPassword(user.Password);
            var result = userRepo.Login(user);
            if (result == null)
            {
                model.AddModelError("Password", "Correo o contraseña incorrectos");
                return null;
            }
            return user;
        }
        
        public IEnumerable<UserDto> GetAllUsers()
        {
			return userRepo.GetListUser();
		}

        public UserDto GetUser(int userId)
        {
            return userRepo.GetUser(userId);
        }

        static public void AuthUser(HttpContext httpContext, UserDto user)
        {
            UserRole userRole = (UserRole)user.RoleId;
            string roleName = Enum.GetName(typeof(UserRole), userRole);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.NameUser),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties).Wait();
        }
    }
}
