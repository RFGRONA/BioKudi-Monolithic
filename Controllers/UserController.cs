using Microsoft.AspNetCore.Mvc;
using BioKudi.Models;
using System.Diagnostics;
using BioKudi.dto;
using BioKudi.Repository;
using Microsoft.AspNetCore.Authorization;
using BioKudi.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using BioKudi.Utilities;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
	[Authorize(Roles = "User")]
    public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

        public UserController(ILogger<UserController> logger, UserService userService)
		{
			_logger = logger;
            this.userService = userService;
        }
		
		public IActionResult IndexUser(UserDto user)
		{
			user = userService.GetUser(user.UserId);
            return View(user);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}