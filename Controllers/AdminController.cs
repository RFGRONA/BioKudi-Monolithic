using BioKudi.Models;
﻿using BioKudi.dto;
using BioKudi.Models;
using BioKudi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BioKudi.Controllers
{
    [NoCache]   
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
		private readonly UserService userService;

		public AdminController(ILogger<AdminController> logger, UserService userService)
		{
			_logger = logger;
			this.userService = userService;
		}

		public IActionResult IndexAdmin(UserDto user)
        {
            user = userService.GetUser(user.UserId);
            return View(user);
        }
        public IActionResult ListUsers()
        {
            var users = userService.GetAllUsers();
            return View(users);
        }
        public IActionResult ListPlaces()
        {
            return View();
        }
        public IActionResult ListActivities()
        {
            return View();
        }
        public IActionResult ListPictures()
        {
            return View();
        }
        public IActionResult ListTickets()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
