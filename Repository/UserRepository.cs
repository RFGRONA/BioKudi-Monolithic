﻿using BioKudi.dto;
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
            return user;
        }
    };
}