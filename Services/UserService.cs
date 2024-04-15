using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Repository;
using BioKudi.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BioKudi.Services
{
    public class UserService
    {
        //private UserRepository userRepo = new UserRepository(new BiokudiDbContext());
        //private PasswordUtility passwordUtility = new PasswordUtility();

        public UserService() { }
        public UserDto RegisterUser(UserDto user, ModelStateDictionary model)
        {
            var userRepo = new UserRepository(new BiokudiDbContext());
            var passwordUtility = new PasswordUtility();
            user.Password = passwordUtility.CreatePassword(user.Password);
            user.Key = passwordUtility.GetKeySafe();
            user.Salt = passwordUtility.GetIv();
            user.RoleId = 1;
            user.StateId = 1;
            var result = userRepo.Create(user);
            if (result!=null)
            {
                model.AddModelError("Email", "Correo ya en uso");
                return null;
            }
            return user;
        }

        public UserDto LoginUser(UserDto user, ModelStateDictionary model)
        {
            var userRepo = new UserRepository(new BiokudiDbContext());
            var passwordUtility = new PasswordUtility();
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
    }
}
