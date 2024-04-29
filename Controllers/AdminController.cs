using BioKudi.dto;
using BioKudi.Models;
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
        private readonly ActivityService activityService;
        private readonly PlacesService PlacesService;

		public AdminController(ILogger<AdminController> logger, UserService userService, ActivityService activityService, PlacesService placesService)
		{
			_logger = logger;
			this.userService = userService;
            this.activityService = activityService;
            this.PlacesService = placesService;
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
            var places = PlacesService.GetAllPlaces();
            return View(places);
        }
        public IActionResult ListActivities()
        {
            var activities = activityService.GetAllActivities();
            return View(activities);
        }
        public IActionResult ListPictures()
        {
            return View();
        }
        public IActionResult ListTickets(UserDto user)
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
