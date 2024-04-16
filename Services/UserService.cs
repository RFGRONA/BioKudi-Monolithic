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
        private readonly UserRepository userRepo;
        private readonly PasswordUtility passwordUtility;

        public UserService(UserRepository userRepo, PasswordUtility passwordUtility)
        {
            this.userRepo = userRepo;
            this.passwordUtility = passwordUtility;
        }

        public UserDto RegisterUser(UserDto user, ModelStateDictionary model)
        {
            user.Password = passwordUtility.CreatePassword(user.Password);
            user.Key = passwordUtility.GetKeySafe();
            user.Salt = passwordUtility.GetIv();
            user.RoleId = 1;
            user.StateId = 1;
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
    }
}
