using Microsoft.AspNetCore.Mvc;
using BioKudi.dto.ViewModel;
using BioKudi.dto;
using Microsoft.AspNetCore.Authorization;
using BioKudi.Services;
using BioKudi.Utilities;

namespace BioKudi.Controllers
{
    [ValidateAuthentication]
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;
        private readonly MapService mapService;
        private readonly PlacesService placeService;
        public UserController(ILogger<UserController> logger, UserService userService, MapService mapService , PlacesService placeService)
        {
            _logger = logger;
            this.userService = userService;
            this.mapService = mapService;
            this.placeService = placeService;
        }

        public IActionResult IndexUser(UserDto user)
        {
            user = userService.GetUser(user.UserId);
            if (user == null)
                return RedirectToAction("Error", "User");
            return View(user);
        }

        public IActionResult Map()
        {
            var markers = mapService.GetMarkers();
            if (markers == null)
                return RedirectToAction("Error", "User");
            return View(markers);
        }
        public IActionResult Activities()
        {
            var places = placeService.GetAllPlaces();
            if (places == null)
                return RedirectToAction("Error", "User");
            return View(places);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}