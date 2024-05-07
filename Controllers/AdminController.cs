using BioKudi.dto;
using BioKudi.dto.ViewModel;
using BioKudi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BioKudi.Utilities;

namespace BioKudi.Controllers
{
	[ValidateAuthentication]
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
